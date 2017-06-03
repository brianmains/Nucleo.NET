using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web;
using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.Web.Description;


namespace Nucleo.Tests.Ajax
{
	public class AjaxViewsPresenter : BaseWebPresenter<IAjaxViewsView>
	{
		public AjaxViewsPresenter(IAjaxViewsView view)
			: base(view) { }
	}

	public interface IAjaxViewsView : IView
	{
		string Message { get; set; }
	}

	[PresenterBinding(typeof(AjaxViewsPresenter))]
	public partial class AjaxViewsFirstLook : BaseViewPage, IAjaxViewsView, IAjaxScriptableComponent
	{
		//protected override string ClientTypeName
		//{
		//    get { return typeof(AjaxViewsFirstLook).FullName; }
		//}

		public string Message { get; set; }

		//protected override void GetViewScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		//{
		//    base.GetViewScriptDescriptors(registrar, targetControl);

		//    ComponentDescriptor descriptor = this.CreateComponentDescriptor(registrar);
		//    descriptor.RegisterProperty("message", this.Message);
		//    descriptor.RegisterElement("errorContainer", "MessageContainer");
		//    descriptor.RegisterControl("check", this.chk);
		//    descriptor.RegisterExtender("button", this.be);
		//    descriptor.RegisterEvent("changed", "changed");
		//}

		//protected override void GetViewScriptReferences(IContentRegistrar registrar)
		//{
		//    base.GetViewScriptReferences(registrar);

		//    registrar.AddReference(new ScriptReferencingRequestDetails(
		//        "~/Tests/Ajax/AjaxViewsFirstLook.js", ScriptMode.Release));
		//}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			this.Message = "Test Message";
		}

		#region IAjaxScriptableComponent Members

		public void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			ComponentDescriptor descriptor = this.CreateComponentDescriptor(registrar);
			descriptor.RegisterProperty("message", this.Message);
			descriptor.RegisterElement("errorContainer", "MessageContainer");
			descriptor.RegisterControl("check", this.chk);
			descriptor.RegisterExtender("button", this.be);
			descriptor.RegisterEvent("changed", "changed");
		}

		public void GetAjaxScriptReferences(IContentRegistrar registrar)
		{
			registrar.AddReference(new ScriptReferencingRequestDetails(
				"~/Tests/Ajax/AjaxViewsFirstLook.js", ScriptMode.Auto));
		}

		public void GetCssReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}