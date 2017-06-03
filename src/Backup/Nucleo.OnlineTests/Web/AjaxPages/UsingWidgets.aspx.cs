using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Description;
using Nucleo.Web.Pages;
using Nucleo.Web.Pages.Widgets;
using Nucleo.SampleClasses.Widgets;


namespace Nucleo.Web.AjaxPages
{
	public partial class UsingWidgets : BaseAjaxPage
	{
		#region " Properties "

		protected override string ClientPageType
		{
			get
			{
				return typeof(UsingWidgets).FullName;
			}
		}

		#endregion



		#region " Methods "

		protected override void DescribePage(ComponentDescriptor descriptor)
		{
			base.DescribePage(descriptor);
		}

		protected override void GetPageScriptReferences(IContentRegistrar registrar)
		{
			base.GetPageScriptReferences(registrar);

			registrar.AddReference(new ScriptReferencingRequestDetails("~/Web/AjaxPages/UsingWidgets.js", ScriptMode.Release));
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			LoginWidget widget = new LoginWidget
			{
				SubmitButton = this.btnSubmit,
				PasswordBox = this.txtPassword,
				UserNameBox = this.txtUserName
			};

			this.RegisterWidget(widget);
		}

		#endregion
	}
}