using System;
using System.Web.UI;

using Nucleo.Web;
using Nucleo.Web.Core;
using Nucleo.Web.Pages.Widgets;
using Nucleo.Web.Description;


namespace Nucleo.Web.Pages
{
	/// <summary>
	/// Represents the base AJAX page class
	/// </summary>
	public abstract class BaseAjaxPage : PageBase, IAjaxScriptableComponent
	{
		private PageWidgetCollection _widgets = null;



		#region " Properties "

		/// <summary>
		/// Gets the client type that will be invoked to create the client-side component for the page.  This defaults to the same type name as the server-side component.
		/// </summary>
		protected virtual string ClientPageType
		{
			get { return this.GetType().FullName; }
		}

		/// <summary>
		/// Gets the number of widgets registered with the system.
		/// </summary>
		public int WidgetCount
		{
			get { return this.Widgets.Count; }
		}

		/// <summary>
		/// Gets the collection of widgets associated with the page.
		/// </summary>
		protected PageWidgetCollection Widgets
		{
			get
			{
				if (_widgets == null)
					_widgets = new PageWidgetCollection();
				return _widgets;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Uses the descriptor to render the attributes of the page.
		/// </summary>
		/// <param name="descriptor">The descriptor used to describe the page.</param>
		protected virtual void DescribePage(ComponentDescriptor descriptor)
		{

		}

		void IAjaxScriptableComponent.GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			this.RegisterPageScriptDescriptors();
		}

		void IAjaxScriptableComponent.GetAjaxScriptReferences(IContentRegistrar registrar)
		{
			this.RegisterPageScriptReferences();
		}

		protected virtual IContentRegistrar GetContentRegistrar()
		{
			NucleoAjaxManager manager = this.CurrentContext.Singletons.GetEntry<NucleoAjaxManager>();
			return manager.Registrar;
		}

		void IAjaxScriptableComponent.GetCssReferences(IContentRegistrar registrar)
		{
			this.RegisterPageCssReferences();
		}

		/// <summary>
		/// Registers the page CSS with the content registrar, including all of the widgets.
		/// </summary>
		/// <param name="registrar">The registrar to register the CSS.</param>
		protected virtual void GetPageCssReferences(IContentRegistrar registrar)
		{
			foreach (PageWidget widget in this.Widgets)
				widget.RegisterCssReferences(registrar);
		}

		private ComponentDescriptor GetPageDescriptorInternal()
		{
			IContentRegistrar registrar = this.GetContentRegistrar();
			ComponentDescriptor pageDescriptor = registrar.AddComponentDescriptor(new ComponentDescriptionRequestDetails(this.ClientPageType));

			this.DescribePage(pageDescriptor);
			pageDescriptor.ComponentType = "Page";

			foreach (PageWidget widget in this.Widgets)
				widget.RegisterAjaxDescriptors(registrar, pageDescriptor);

			return pageDescriptor;
		}

		/// <summary>
		/// Registers the page script references with the content registrar.
		/// </summary>
		/// <param name="registrar">The registrar to register scripts to.</param>
		protected virtual void GetPageScriptReferences(IContentRegistrar registrar)
		{
#if DEBUG
			registrar.AddReference(new ScriptReferencingRequestDetails(
				typeof(BaseAjaxPage), ScriptMode.Debug));
#else
			registrar.AddReference(new ScriptReferencingRequestDetails(
				typeof(BaseAjaxPage), ScriptMode.Release));
#endif

			foreach (PageWidget widget in this.Widgets)
				widget.RegisterAjaxReferences(registrar);
		}

		protected override void OnLoad(EventArgs e)
		{
 			 base.OnLoad(e);

			this.RegisterPageCssReferences();
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			this.RegisterPageScriptReferences();
			this.RegisterPageScriptDescriptors();
		}

		private void RegisterPageCssReferences()
		{
			this.GetPageCssReferences(this.GetContentRegistrar());
		}

		private void RegisterPageScriptDescriptors()
		{
			this.GetPageDescriptorInternal();
		}

		private void RegisterPageScriptReferences()
		{
			this.GetPageScriptReferences(this.GetContentRegistrar());
		}

		/// <summary>
		/// Registers the widget with the page.
		/// </summary>
		/// <param name="widget">The widget to register.</param>
		/// <exception cref="ArgumentNullException">Thrown when the page widget is null.</exception>
		public void RegisterWidget(PageWidget widget)
		{
			if (widget == null)
				throw new ArgumentNullException("widget");

			this.Widgets.Add(widget);
		}

		/// <summary>
		/// Renders the page.
		/// </summary>
		/// <param name="writer">The HTML text writer to render the page.</param>
		protected override void Render(HtmlTextWriter writer)
		{
			//ScriptManager.RegisterStartupScript(this, this.GetType(), "PageRegistration",
			//    "Sys.Application.add_load(function() { $createPage(" + _descriptor.GetScript() + "); });", true);

			IContentRegistrar registrar = this.GetContentRegistrar();
			ComponentDescriptorCollection components = registrar.GetComponentDescriptors();
			string widgetScript = "";

			foreach (ComponentDescriptor component in components)
			{
				//Register page scripts directly; register widgets separately
				if (component.ComponentType == "Page")
					ScriptManager.RegisterStartupScript(this, this.GetType(), "PageRegistration",
						"Sys.Application.add_load(function() { $createPage(" + component.GetScript() + "); });", true);
				else
					widgetScript += " $createWidget(" + component.GetScript() + "); ";
			}

			ScriptManager.RegisterStartupScript(this, this.GetType(), "WidgetRegistration",
				"Sys.Application.add_load(function() { " + widgetScript + " });", true);

			base.Render(writer);
		}

		#endregion
	}
}
