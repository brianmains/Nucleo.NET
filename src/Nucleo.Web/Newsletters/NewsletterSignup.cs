using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Newsletters;
using Nucleo.Web.Controls;


namespace Nucleo.Web.Newsletters
{
	[
	ValidationProperty("EmailAddress"),
	DefaultProperty("EmailAddress"),
	DefaultEvent("SigningUp")
	]
	public class NewsletterSignup : WebControl, IPostBackDataHandler, IPostBackEventHandler
	{
		#region " Events "

		public event EventHandler EmailAddressChanged;
		public event EventHandler SignedUp;
		public event CancelEventHandler SigningUp;

		#endregion



		#region " Properties "

		[
		DefaultValue("Signup"),
		Localizable(true)
		]
		public string ButtonText
		{
			get
			{
				object o = ViewState["ButtonText"];
				return (o == null) ? "Signup" : o.ToString();
			}
			set { ViewState["ButtonText"] = value; }
		}

		[Localizable(true)]
		public string Description
		{
			get
			{
				object o = ViewState["Description"];
				return (o == null) ? null : o.ToString();
			}
			set { ViewState["Description"] = value; }
		}

		public string EmailAddress
		{
			get
			{
				object o = ViewState["EmailAddress"];
				return (o == null) ? null : o.ToString();
			}
			set { ViewState["EmailAddress"] = value; }
		}

		public string NewsletterName
		{
			get
			{
				object o = ViewState["NewsletterName"];
				return (o == null) ? null : o.ToString();
			}
			set { ViewState["NewsletterName"] = value; }
		}

		#endregion



		#region " Methods "

		public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			this.EmailAddress = postCollection[this.UniqueID];
			return false;
		}

		protected virtual void OnEmailAddressChanged(EventArgs e)
		{
			if (EmailAddressChanged != null)
				EmailAddressChanged(this, e);
		}

		protected virtual void OnSignedUp(EventArgs e)
		{
			if (SignedUp != null)
				SignedUp(this, e);

			//Clear the email address after signing up 
			this.EmailAddress = null;
		}

		protected virtual void OnSigningUp(CancelEventArgs e)
		{
			if (SigningUp != null)
				SigningUp(this, e);
		}

		public void RaisePostBackEvent(string eventArgument)
		{
			//Prevent any sort of event hijacking 
			if (eventArgument != "signup")
				return;

			if (SigningUp == null && string.IsNullOrEmpty(this.NewsletterName))
				throw new Exception("If no newsletter name is provided, the SigningUp event must be handled.");

			CancelEventArgs args = new CancelEventArgs(false);
			this.OnSigningUp(args);

			if (!args.Cancel)
			{
				if (string.IsNullOrEmpty(this.NewsletterName))
					throw new NullReferenceException("The newsletter name has not been provided");
				if (!Newsletter.NewsletterExists(this.NewsletterName))
					throw new Exception("The newsletter provided does not exist");

				Newsletter.AddSubscription(this.EmailAddress, this.NewsletterName);
				this.OnSignedUp(EventArgs.Empty);
			}
		}

		public void RaisePostDataChangedEvent()
		{
			this.OnEmailAddressChanged(EventArgs.Empty);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.AddAttributesToRender(writer);
			writer.RenderBeginTag(HtmlTextWriterTag.Span);
			writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
			writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
			writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
			writer.AddAttribute(HtmlTextWriterAttribute.Value, this.EmailAddress);
			writer.RenderBeginTag(HtmlTextWriterTag.Input);
			writer.RenderEndTag(); //input 

			writer.Write("&nbsp;&nbsp;");

			writer.AddAttribute(HtmlTextWriterAttribute.Id, this.UniqueID + "signup");
			writer.AddAttribute(HtmlTextWriterAttribute.Href, Page.ClientScript.GetPostBackClientHyperlink(this, "signup", true));
			writer.RenderBeginTag(HtmlTextWriterTag.A);
			writer.Write(this.ButtonText);
			writer.RenderEndTag(); //a 

			//If the description exists, render it below the textbox. 
			if (!string.IsNullOrEmpty(this.Description))
			{
				writer.Write("<br>");
				writer.Write(this.Description);
			}

			writer.RenderEndTag(); //span 
		}

		#endregion
	}
}