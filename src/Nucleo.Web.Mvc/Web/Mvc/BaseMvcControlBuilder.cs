using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;

using Nucleo.Web.ClientState;
using Nucleo.Web.Styles;
using Nucleo.Web.Tags;
using Nucleo.Web.Tags.Custom;


namespace Nucleo.Web.Mvc
{
	public abstract class BaseMvcControlBuilder<TComponent, TBuilder>
		where TComponent : BaseAjaxControl
		where TBuilder: BaseMvcControlBuilder<TComponent, TBuilder>
	{
		private TComponent _control = null;
		private NucleoControlFactory _controlFactory = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the control reference.
		/// </summary>
		private TComponent Control
		{
			get { return _control; }
			set { _control = value; }
		}

		/// <summary>
		/// Gets the control factory for the framework.
		/// </summary>
		protected internal NucleoControlFactory ControlFactory
		{
			get { return _controlFactory; }
		}

		#endregion



		#region " Constructors "

		public BaseMvcControlBuilder(NucleoControlFactory controlFactory)
		{
			_controlFactory = controlFactory;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Disables the control.
		/// </summary>
		/// <returns>The builder.</returns>
		public TBuilder Disable()
		{
			this.GetControl().Enabled = false;
			return this as TBuilder;
		}

		/// <summary>
		/// Enables the control.
		/// </summary>
		/// <returns>The builder.</returns>
		public TBuilder Enable()
		{
			this.GetControl().Enabled = true;
			return this as TBuilder;
		}

		/// <summary>
		/// Gets a reference to the control.
		/// </summary>
		/// <returns>The control reference.</returns>
		protected virtual TComponent GetControl()
		{
			if (this.Control == null)
			{
				this.Control = Activator.CreateInstance<TComponent>();
				this.Control.Page = _controlFactory.Page();

				this.Control.RenderingMode = RenderMode.ClientAndServer;
				this.Control.RegisterWithScriptManager = false;
			}

			return this.Control;
		}

		/// <summary>
		/// Gets the underlying control writer to write the content out to.
		/// </summary>
		/// <returns></returns>
		protected virtual BaseControlWriter GetControlWriter()
		{
			return new HtmlStreamControlWriter(HttpContext.Current.Request.Browser.CreateHtmlTextWriter(
				_controlFactory.Html.ViewContext.HttpContext.Response.Output));
			//return new StringControlWriter();
		}

		/// <summary>
		/// Initializes the component after it is created for the first time.
		/// </summary>
		protected virtual void Initialize() { }

		/// <summary>
		/// Loads the builder object from JSON that's stored on the client.
		/// </summary>
		/// <param name="json">The JSON to load.</param>
		/// <returns></returns>
		public virtual TBuilder LoadFromJson(string json)
		{
			((IClientStateControl)this.GetControl()).LoadClientState(ClientStateData.FromJson(json));
			return this as TBuilder;
		}

		/// <summary>
		/// Sets the name of the control.
		/// </summary>
		/// <param name="name">The name of the control.</param>
		/// <returns>The builder.</returns>
		public TBuilder Name(string name)
		{
			this.GetControl().ID = name;
			return this as TBuilder;
		}

		protected internal virtual void RegisterComponentCss(ContentRegistrar registrar)
		{
			((IAjaxScriptableComponent)this.GetControl()).GetCssReferences(registrar);
		}

		protected internal virtual void RegisterComponentDescriptors(ContentRegistrar registrar)
		{
			((IAjaxScriptableComponent)this.GetControl()).GetAjaxScriptDescriptors(registrar, this.GetControl());
		}

		/// <summary>
		/// Registers component scripts using the <see cref="ContentRegistrar">Content Registrar component</see>.
		/// </summary>
		/// <param name="registrar">The registrar to register component scripts with.</param>
		protected internal virtual void RegisterComponentScripts(ContentRegistrar registrar)
		{
			((IAjaxScriptableComponent)this.GetControl()).GetAjaxScriptReferences(registrar);
		}

		public void Render()
		{
			_controlFactory.Content().RegisterComponent(this);

			BaseControlWriter writer = this.GetControlWriter();
			this.RenderUI(writer);
			this.RenderClientState(writer);

			if (!writer.AutoFlush)
				_controlFactory.Html.ViewContext.HttpContext.Response.Output.WriteLine(writer.ToString());
		}

		private void RenderClientState(BaseControlWriter writer)
		{
			writer.Write(TagElementBuilder.Create(HiddenTagBuilder.Create(this.GetControl().ID + "_ClientState", this.SaveToJson())).ToHtmlString());
		}

		public string RenderCss()
		{
			ContentRegistrar tempRegistrar = new ContentRegistrar();
			this.RegisterComponentCss(tempRegistrar);
			
			CssReferenceCollection cssFiles = tempRegistrar.GetCssReferences();
			return this.RenderCssFiles(cssFiles);
		}

		protected virtual string RenderCssFiles(CssReferenceCollection cssFiles)
		{
			string html = "";

			foreach (CssReference cssFile in cssFiles)
				html += ContentRendering.CreateCssReference(cssFile);

			return html;
		}

		public TBuilder RenderingMode(RenderMode mode)
		{
			this.GetControl().RenderingMode = mode;
			return this as TBuilder;
		}

		protected virtual void RenderUI(BaseControlWriter writer)
		{
			((IRenderableControl)this.GetControl()).RenderUI(writer);
		}

		/// <summary>
		/// Saves the object's state to JSON.
		/// </summary>
		/// <param name="data">The data to save.</param>
		/// <returns>The JSON data.</returns>
		public virtual string SaveToJson()
		{
			return ((IClientStateControl)this.GetControl()).SaveClientState().ToJson();
		}

		#endregion
	}
}
