using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.Core;
using Nucleo.Web.Description;


namespace Nucleo.Web.Views
{
	public class BaseAjaxViewUserControl : BaseViewUserControl, IAjaxScriptableComponent
	{
		#region " Properties "

		protected virtual string ClientTypeName
		{
			get { return this.GetType().FullName; }
		}

		#endregion



		#region " Methods "

		public virtual ComponentDescriptor CreateComponentDescriptor(IContentRegistrar registrar)
		{
			ComponentDescriptor descriptor = registrar.AddComponentDescriptor(new ComponentDescriptionRequestDetails(this.ClientTypeName));
			descriptor.ComponentType = "View";

			return descriptor;
		}

		void IAjaxScriptableComponent.GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			this.GetViewScriptDescriptors(registrar, targetControl);
		}

		void IAjaxScriptableComponent.GetAjaxScriptReferences(IContentRegistrar registrar)
		{
#if DEBUG
			ScriptReferencingRequestDetails reference = new ScriptReferencingRequestDetails(
				typeof(BaseAjaxViewPage).Assembly.GetName().Name, "Nucleo.Web.Views.BaseAjaxView.js", ScriptMode.Debug);
#else
			ScriptReferencingRequestDetails reference = new ScriptReferencingRequestDetails(
				typeof(BaseAjaxViewPage).Assembly.GetName().Name, "Nucleo.Web.Views.BaseAjaxView.js", ScriptMode.Release);
			
#endif
			registrar.AddReference(reference);

			this.GetViewScriptReferences(registrar);
		}

		protected virtual IContentRegistrar GetContentRegistrar()
		{
			NucleoAjaxManager manager = WebSingletonManager.GetCurrent().GetEntry<NucleoAjaxManager>();
			return manager.Registrar;
		}

		void IAjaxScriptableComponent.GetCssReferences(IContentRegistrar registrar)
		{
			this.GetViewCssReferences(registrar);
		}

		protected virtual void GetViewCssReferences(IContentRegistrar registrar)
		{

		}

		protected virtual void GetViewScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{

		}

		protected virtual void GetViewScriptReferences(IContentRegistrar registrar)
		{

		}

		protected virtual void OnPostScriptDescriptors(IContentRegistrar registrar) { }

		protected virtual void OnPostScriptReferences(IContentRegistrar registrar) { }

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			IContentRegistrar registrar = this.GetContentRegistrar();

			((IAjaxScriptableComponent)this).GetAjaxScriptReferences(registrar);
			this.OnPostScriptReferences(registrar);
			((IAjaxScriptableComponent)this).GetAjaxScriptDescriptors(registrar, this);
			this.OnPostScriptDescriptors(registrar);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			//IContentRegistrar registrar = this.GetContentRegistrar();
			//ComponentDescriptorCollection components = registrar.GetComponentDescriptors();
			//string script = string.Empty;

			//foreach (ComponentDescriptor component in components)
			//{
			//    //Register page scripts directly; register widgets separately
			//    if (component.ComponentType == "View")
			//        script += "Sys.Application.add_load(function() { $createView(" + component.GetScript() + "); });";
			//}

			//ScriptManager.RegisterStartupScript(this, this.GetType(), "ViewRegistration", script, true);

			base.Render(writer);
		}

		#endregion
	}
}
