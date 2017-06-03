using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Pages;
using Nucleo.Web.Description;


namespace Nucleo.Web.AjaxPages
{
	public partial class FirstLook : BaseAjaxPage
	{
		#region " Properties "

		protected override string ClientPageType
		{
			get { return typeof(FirstLook).FullName; }
		}

		public string ErrorMessage
		{
			get;
			set;
		}

		public string Text
		{
			get { return (string)ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void DescribePage(ComponentDescriptor descriptor)
		{
			descriptor.RegisterProperty("errorMessage", this.ErrorMessage);
			descriptor.RegisterProperty("text", this.Text);

			descriptor.RegisterElement("TitleLabel", "TitleSpan");
			descriptor.RegisterElement("ErrorMessageLabel", "ErrorMessage");
			descriptor.RegisterElement("NameBox", this.txtName.ClientID);
			descriptor.RegisterElement("CityBox", this.txtCity.ClientID);

			descriptor.RegisterControl("SubmitButton", this.btnSubmit);
		}

		protected override void GetPageScriptReferences(IContentRegistrar registrar)
		{
			base.GetPageScriptReferences(registrar);

			registrar.AddReference(new ScriptReferencingRequestDetails("~/Web/AjaxPages/FirstLook.js", ScriptMode.Release));
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (!Page.IsPostBack)
				this.Text = "Initial Text";
		}

		#endregion
	}
}