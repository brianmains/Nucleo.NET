using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nucleo.Web;

using Nucleo.Web.Pages;
using Nucleo.Web.Description;
using Nucleo.Web.Pages.Widgets;


namespace Nucleo.SampleClasses.Widgets
{
	public class LoginWidget : PageWidget
	{

		#region " Properties "

		public TextBox PasswordBox
		{
			get;
			set;
		}

		public Button SubmitButton
		{
			get;
			set;
		}

		public TextBox UserNameBox
		{
			get;
			set;
		}

		#endregion



		#region " Methods "

		protected override void RegisterAjaxDescriptors(IContentRegistrar registrar, ComponentDescriptor pageDescriptor)
		{
			base.RegisterAjaxDescriptors(registrar, pageDescriptor);

			ComponentDescriptor descriptor = registrar.AddComponentDescriptor(new ComponentDescriptionRequestDetails(typeof(LoginWidget).FullName));
			descriptor.RegisterElement("userNameBox", this.UserNameBox.ClientID);
			descriptor.RegisterElement("passwordBox", this.PasswordBox.ClientID);
			descriptor.RegisterElement("submitButton", this.SubmitButton.ClientID);
		}

		protected override void RegisterAjaxReferences(IContentRegistrar registrar)
		{
			base.RegisterAjaxReferences(registrar);

			registrar.AddReference(new ScriptReferencingRequestDetails("~/SampleClasses/Widgets/LoginWidget.js", ScriptMode.Release));
		}

		protected override void RegisterCssReferences(IContentRegistrar registrar)
		{
			base.RegisterCssReferences(registrar);
		}

		#endregion
	}
}