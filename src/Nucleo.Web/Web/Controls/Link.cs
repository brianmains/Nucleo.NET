using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Context;
using Nucleo.Web.Context.Services;
using Nucleo.EventArguments;
using Nucleo.Web.NavigationControls;


namespace Nucleo.Web.Controls
{
	/// <summary>
	/// Represents a link control.
	/// </summary>
	/// <remarks>The control uses format strings for navigation url and text.  This is a nice benefit to use when binding in web forms.  For instance, the user can supply a format string to the <see cref="NavigateUrlFormatString">NavigateUrlFormatString</see> property, and supply a data bound value to the <see cref="NavigateUrl">NavigateUrl</see> property.  For information, check out my blog at:
	/// http://msmvps.com/blogs/bmains/archive/2009/10/31/nucleo-link-control-overview.aspx
	/// </remarks>
	[
	WebScriptMetadata(typeof(LinkScriptMetadata)),
	WebRenderer(typeof(LinkRenderer))
	]
	public class Link : BaseAjaxControl, IPostBackEventHandler
	{
		#region " Events "

		public event EventHandler Clicked;
		public event RedirectEventHandler Redirecting;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets how the control acts when clicked.  By default, it fires an event whenever the link is clicked.  Alternatively, the link can redirect to another page.
		/// </summary>
		[
		DefaultValue(LinkClickAction.FireEvent)
		]
		public LinkClickAction ClickAction
		{
			get { return (LinkClickAction) (ViewState["ClickAction"] ?? LinkClickAction.FireEvent); }
			set { ViewState["ClickAction"] = value; }
		}

		/// <summary>
		/// Gets or sets the URL to navigate to when the link is clicked and the <see cref="ClickAction">ClickAction property</see> is set to Redirect.
		/// </summary>
		public string NavigateUrl
		{
			get { return (string)ViewState["NavigateUrl"]; }
			set { ViewState["NavigateUrl"] = value; }
		}

		/// <summary>
		/// Gets or sets a format string of the URL to navigate to.  This allows the core URL to be entered as a format string, and an alternative value bound to the <see cref="NavigateUrl">NavigateUrl</see> property.
		/// </summary>
		/// <example>
		/// &lt;!-- NavigateUrl supplies bound value to format string -->
		/// &lt;n:Link .. NavigateUrlFormatString="products.aspx?id={0}" NavigateUrl='&lt;%# Eval("Key") %>' />
		/// </example>
		public string NavigateUrlFormatString
		{
			get { return (string)ViewState["NavigateUrlFormatString"]; }
			set { ViewState["NavigateUrlFormatString"] = value; }
		}

		/// <summary>
		/// Gets or sets the target for the button.  The options are to use the same window, or a new window.
		/// </summary>
		/// <remarks>This property directly maps to the target property for the hyperlink.</remarks>
		public LinkTargetOptions Target
		{
			get { return (LinkTargetOptions) (ViewState["Target"] ?? LinkTargetOptions.SameWindow); }
			set { ViewState["Target"] = value; }
		}

		/// <summary>
		/// Gets or sets the text for the link.
		/// </summary>
		public string Text
		{
			get { return (string) ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		/// <summary>
		/// Gets or sets the text format for the link.  When this value is supplied, the text is imposed within the text format.
		/// </summary>
		public string TextFormat
		{
			get { return (string)ViewState["TextFormat"]; }
			set { ViewState["TextFormat"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(Link), this.ClientID));
			descriptor.AddProperty("clickAction", this.ClickAction);
			descriptor.AddPropertyIfExists("navigateUrl", this.GetUrl());
			descriptor.AddProperty("target", this.GetTarget());
			descriptor.AddPropertyIfExists("text", this.GetText());
		}

		/// <summary>
		/// Gets the target attribute for the hyperlink, based upon the <see cref="Target">Target property</see>.
		/// </summary>
		/// <returns>The target attribute.</returns>
		public string GetTarget()
		{
			if (this.Target == LinkTargetOptions.NewWindow)
				return "_blank";
			else if (this.Target == LinkTargetOptions.SameWindow)
				return "_self";
			else
				throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the text of the link, using the <see cref="Text">Text</see> and the <see cref="TextFormat">TextFormat</see> properties.
		/// </summary>
		/// <returns>The text, whether formatted or not.</returns>
		public string GetText()
		{
			if (!string.IsNullOrEmpty(this.TextFormat))
				return string.Format(this.TextFormat, this.Text);
			else
				return this.Text;
		}

		/// <summary>
		/// Gets the URL to the link, using the <see cref="NavigateUrlFormatString">NavigateUrlFormatString</see> and the <see cref="NavigateUrl">NavigateUrl</see> properties.
		/// </summary>
		/// <returns>The URL, formatted or not.</returns>
		public string GetUrl()
		{
			if (!string.IsNullOrEmpty(this.NavigateUrl))
			{
				if (!string.IsNullOrEmpty(this.NavigateUrlFormatString))
					return string.Format(this.NavigateUrlFormatString, this.NavigateUrl);
				else
					return this.NavigateUrl;
			}

			return null;
		}

		protected void OnClicked(EventArgs e)
		{
			if (Clicked != null)
				Clicked(this, e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.ClickAction == LinkClickAction.Redirect)
			{
				if (string.IsNullOrEmpty(this.NavigateUrl) && string.IsNullOrEmpty(this.NavigateUrlFormatString))
					throw new ArgumentException("The navigation url/format string has not been set, which is required in redirect mode.");
			}
		}

		protected void OnRedirecting(RedirectEventArgs e)
		{
			if (Redirecting != null)
				Redirecting(this, e);
		}

		void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
		{
			if (eventArgument == "click")
			{
				this.OnClicked(System.EventArgs.Empty);
			}
			else if (eventArgument == "redirect")
			{
				RedirectEventArgs args = new RedirectEventArgs(this.GetUrl());

				this.OnRedirecting(args);

				if (!args.CancelRedirect)
				{
					ApplicationContext context = ApplicationContext.GetCurrent();
					if (context != null)
					{
						INavigationService service = context.GetService<INavigationService>();
						if (service != null)
						{
							service.NavigateTo(new WebFormsNavigationRoute(this.GetUrl()));
							return;
						}
					}

					try
					{
						this.Page.Response.Redirect(this.GetUrl());
					}
					catch (System.Threading.ThreadAbortException ex) { }
				}
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.HandleManualScriptRegistering();

			base.AddAttributesToRender(writer);
			if (this.RenderingMode == RenderMode.ClientAndServer)
				writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
			writer.RenderBeginTag(HtmlTextWriterTag.Span);

			if (this.ClickAction == LinkClickAction.Redirect)
				this.RenderRedirectLink(writer);
			else
				this.RenderDefaultLink(writer);

			writer.RenderEndTag(); //span
		}

		protected virtual void RenderDefaultLink(HtmlTextWriter writer)
		{
			if (this.RenderingMode != RenderMode.ClientOnly)
				writer.AddAttribute(HtmlTextWriterAttribute.Href, NucleoAjaxManager.GetPostbackClientHyperlink(this, "click"));
			else
				writer.AddAttribute(HtmlTextWriterAttribute.Href, "javascript:void(0);");
			
			writer.RenderBeginTag(HtmlTextWriterTag.A);

			writer.Write(this.GetText());

			writer.RenderEndTag(); //a
		}

		protected virtual void RenderRedirectLink(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Href, this.GetUrl());
			writer.AddAttribute(HtmlTextWriterAttribute.Target, this.GetTarget());
			writer.RenderBeginTag(HtmlTextWriterTag.A);

			writer.Write(this.GetText());

			writer.RenderEndTag(); //a
		}

		#endregion
	}
}
