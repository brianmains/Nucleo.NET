using System;
using System.IO;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using Nucleo.Web.Styles;
using Nucleo.Web.Tags;
using Nucleo.Web.Tags.Custom;
using Nucleo.Web.ClientState;


namespace Nucleo.Web.Mvc
{
	public abstract class BaseMvcComponentBuilder<TComponent, TBuilder>
		where TComponent : BaseMvcComponent
		where TBuilder : BaseMvcComponentBuilder<TComponent, TBuilder>
	{
		private TComponent _control = null;
		private NucleoControlFactory _controlFactory = null;
		


		#region " Constructors "

		public BaseMvcComponentBuilder(NucleoControlFactory controlFactory)
		{
			_controlFactory = controlFactory;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets a reference to the component; if the component doesn't exist, it is created for the first time.
		/// </summary>
		/// <returns>The instance of the MVC component.</returns>
		protected virtual TComponent GetControl()
		{
			if (_control == null)
			{
				_control = Activator.CreateInstance<TComponent>();
				_control.Initialize();
			}

			return _control;
		}

		/// <summary>
		/// Gets the writer component associated with the control.  Looks for a <see cref="WebRendererAttribute">WebRenderer attribute</see> within the component's attribute definition to see if it has an associated renderer component.
		/// </summary>
		/// <returns>The control writer reference for the specific control.</returns>
		protected virtual BaseMvcComponentWriter<TComponent> GetWriter()
		{
			return new WebRendererComponentWriter<TComponent>();
		}
		
		/// <summary>
		/// Loads the builder object from JSON that's stored on the client.
		/// </summary>
		/// <param name="json">The JSON to load.</param>
		/// <returns></returns>
		public virtual TBuilder LoadFromJson(string json)
		{
			this.GetControl().ClientState = ClientStateData.FromJson(json).Values;
			return this as TBuilder;
		}

		/// <summary>
		/// Sets the name of the control.
		/// </summary>
		/// <param name="name">The name of the control.</param>
		/// <returns>The builder.</returns>
		public TBuilder Name(string name)
		{
			this.GetControl().Name = name;
			
			return this as TBuilder;
		}

		/// <summary>
		/// Registers any CSS for the component.
		/// </summary>
		/// <param name="registrar">The registrar to register with.</param>
		protected internal virtual void RegisterComponentCss(ContentRegistrar registrar)
		{
			
		}

		/// <summary>
		/// Registers any component descriptors, which render a client-side component and its associated properties and events.
		/// </summary>
		/// <param name="registrar"></param>
		protected internal virtual void RegisterComponentDescriptors(ContentRegistrar registrar)
		{
			
		}

		/// <summary>
		/// Registers component scripts using the <see cref="ContentRegistrar">Content Registrar component</see>.
		/// </summary>
		/// <param name="registrar">The registrar to register component scripts with.</param>
		protected internal virtual void RegisterComponentScripts(ContentRegistrar registrar)
		{
			WebScriptMetadata[] scripts = ControlScriptMetadata.GetWebScriptMetadata(this);

			foreach (WebScriptMetadata script in scripts)
				registrar.AddReferences(script.GetPrimaryScripts());
		}

		/// <summary>
		/// Renders the component, using a component writer.  Writes the content to the output stream.
		/// </summary>
		public void Render()
		{
			_controlFactory.Content().RegisterComponent(this);

			BaseMvcComponentWriter<TComponent> writer = this.GetWriter();
			if (writer == null)
				throw new ArgumentNullException("writer", "The writer associated with the control could not be loaded");

			TagElement componentTag = writer.Render(this.GetControl());
			if (componentTag == null)
				throw new ArgumentNullException("componentTag", "The component's tag could not be created");

			_controlFactory.Html.ViewContext.HttpContext.Response.Output.Write(componentTag.ToHtmlString());
			this.RenderClientState(_controlFactory.Html.ViewContext.HttpContext.Response.Output);
		}

		/// <summary>
		/// Renders the client state for the control.
		/// </summary>
		/// <param name="htmlWriter">The html writer to write client state to.</param>
		private void RenderClientState(TextWriter htmlWriter)
		{
			if (!this.GetControl().HasClientState)
			{
				htmlWriter.Write(TagElementBuilder.Create(HiddenTagBuilder.Create(this.GetControl().Name + "_ClientState", "")));
				return;
			}

			htmlWriter.Write(TagElementBuilder.Create(HiddenTagBuilder.Create(this.GetControl().Name + "_ClientState", 
				this.SaveToJson())).ToHtmlString());
		}

		/// <summary>
		/// Saves the object's state to JSON.
		/// </summary>
		/// <returns>The JSON data.</returns>
		public virtual string SaveToJson()
		{
			return new ClientStateData(this.GetControl().ClientState).ToJson();
		}

		#endregion
	}
}
