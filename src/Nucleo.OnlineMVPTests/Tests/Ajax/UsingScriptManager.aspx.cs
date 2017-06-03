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
using Nucleo.Web.Core;
using Nucleo.Web.Description;


namespace Nucleo.Tests.Ajax
{
	public class UsingScriptManagerPresenter : BaseWebPresenter<IUsingScriptManagerView>
	{
		public UsingScriptManagerPresenter(IUsingScriptManagerView view)
			: base(view) { }
	}

	public interface IUsingScriptManagerView : IView
	{
		string Message { get; set; }
	}

	[PresenterBinding(typeof(UsingScriptManagerPresenter))]
	public partial class UsingScriptManager : BaseViewPage, IUsingScriptManagerView, IAjaxScriptableComponent
	{
		//private IContentRegistrar _registrar = new ContentRegistrar();

		//protected override string ClientTypeName
		//{
		//    get { return typeof(UsingScriptManager).FullName; }
		//}

		public string Message { get; set; }


		//protected override IContentRegistrar GetContentRegistrar()
		//{
		//    return _registrar;
		//}

		//protected override void GetViewScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		//{
		//    base.GetViewScriptDescriptors(registrar, targetControl);

		//    var descriptor = this.CreateComponentDescriptor(registrar);
		//    descriptor.RegisterProperty("message", this.Message);
		//}

		//protected override void GetViewScriptReferences(IContentRegistrar registrar)
		//{
		//    base.GetViewScriptReferences(registrar);

		//    registrar.AddReference(new ScriptReferencingRequestDetails("~/Tests/Ajax/UsingScriptManager.js", ScriptMode.Auto));
		//}

		//protected override void OnPostScriptReferences(IContentRegistrar registrar)
		//{
		//    ScriptManager mgr = ScriptManager.GetCurrent(this.Page);
		//    foreach (var reference in registrar.GetScripts())
		//    {
		//        mgr.Scripts.Add(new ScriptReference
		//            {
		//                Assembly = reference.Assembly,
		//                Name = reference.Name,
		//                Path = reference.Path,
		//                ResourceUICultures = reference.ResourceUICultures,
		//                ScriptMode = reference.ScriptMode
		//            });
		//    }
		//}

		#region IAjaxScriptableComponent Members

		public void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control targetControl)
		{
			var descriptor = this.CreateComponentDescriptor(registrar);
			descriptor.RegisterProperty("message", this.Message);
		}

		public void GetAjaxScriptReferences(IContentRegistrar registrar)
		{
			registrar.AddReference(new ScriptReferencingRequestDetails("~/Tests/Ajax/UsingScriptManager.js", ScriptMode.Auto));
		}

		public void GetCssReferences(IContentRegistrar registrar)
		{
			
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			//Have to put here in PreRender; too late would be too late to register scripts.
			//But base.OnPreRender needs called first so that the script registration happens.
			ScriptManager mgr = ScriptManager.GetCurrent(this.Page);
			IWebContext context = WebContext.GetCurrent();

			foreach (var reference in context.ContentRegistrar.GetScripts())
			{
				mgr.Scripts.Add(new ScriptReference
				{
					Assembly = reference.Assembly,
					Name = reference.Name,
					Path = reference.Path,
					ResourceUICultures = reference.ResourceUICultures,
					ScriptMode = reference.ScriptMode
				});
			}
		}

		#endregion
	}
}