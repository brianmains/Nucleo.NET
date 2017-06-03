using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Web.Controls;
using Nucleo.Web.ButtonControls.ClientSettings;


namespace Nucleo.Web.ButtonControls
{
	/// <summary>
	/// A button control that functions in one of many ways.  
	/// </summary>
	/// <remarks>
	/// For more information, check out the following resources:
	/// http://msmvps.com/blogs/bmains/archive/2009/10/27/using-the-nucleo-button.aspx
	/// </remarks>
	[
	WebRenderer(typeof(ButtonRenderer)),
	WebScriptMetadata(typeof(ButtonScriptMetadata))
	]
	public class Button : BaseAjaxControl, IButtonControl, IPostBackEventHandler
	{
		private ButtonClientEvents _buttonClientEvents = null;
		private ButtonList _parentList = null;
		private string _text = string.Empty;



		#region " Events "

		public event EventHandler Click;
		public event CommandEventHandler Command;

		#endregion



		#region " Properties "

		/// <summary>
		/// Represents the client-side AJAX events that the button allows for developers to tap into.  The events get rendered in-line as part of the target object.
		/// </summary>
		[
		MergableProperty(false),
		PersistenceMode(PersistenceMode.InnerProperty),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Description("Represents the client-side AJAX events that the button allows for developers to tap into.  The events get rendered in-line as part of the target object.")
		]
		public ButtonClientEvents ButtonClientEvents
		{
			get
			{
				if (_buttonClientEvents == null)
					_buttonClientEvents = new ButtonClientEvents();
				return _buttonClientEvents;
			}
		}

		/// <summary>
		/// Gets or sets whether the button triggers client-side validation, using the standard ASP.NET validators.
		/// </summary>
		[
		Description("Gets or sets whether the button triggers client-side validation, using the standard ASP.NET validators."),
		DefaultValue(false)
		]
		public bool CausesValidation
		{
			get { return (bool)(ViewState["CausesValidation"] ?? false); }
			set { ViewState["CausesValidation"] = value; }
		}

		/// <summary>
		/// Gets or sets the argument for the button command.
		/// </summary>
		[
		Description("Gets or sets the argument for the button command.")
		]
		public string CommandArgument
		{
			get { return (string)ViewState["CommandArgument"]; }
			set { ViewState["CommandArgument"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the command, the command to fire when the button is clicked.
		/// </summary>
		[
		Description("Gets or sets the name of the command, the command to fire when the button is clicked.")
		]
		public string CommandName
		{
			get { return (string)ViewState["CommandName"]; }
			set { ViewState["CommandName"] = value; }
		}

		/// <summary>
		/// Gets or sets whether to disable the button when the button is first clicked.  This can be permanent or temporary.
		/// </summary>
		[
		Description("Gets or sets whether to disable the button when the button is first clicked.  This can be permanent or temporary."),
		DefaultValue(false)
		]
		public bool DisableOnFirstClick
		{
			get { return (bool)(ViewState["DisableOnFirstClick"] ?? false); }
			set { ViewState["DisableOnFirstClick"] = value; }
		}

		/// <summary>
		/// Gets or sets the client-side timeout to use to re-enable the button after X number of milliseconds.  Requires that the button renders not in server-side only mode.
		/// </summary>
		[
		Description("Gets or sets the client-side timeout to use to re-enable the button after X number of milliseconds.  Requires that the button renders not in server-side only mode."),
		DefaultValue(0)
		]
		public int DisableOnFirstClickTimeout
		{
			get { return (int)(ViewState["DisableOnFirstClickTimeout"] ?? 0); }
			set { ViewState["DisableOnFirstClickTimeout"] = value; }
		}

		/// <summary>
		/// Gets or sets whether the button disabled itself until page load, using ASP.NET AJAX client-side page load event.  If rendering mode set to server-only, this will not work as expected (disabled permanently).
		/// </summary>
		/// <remarks>It is recommended to allow the the user to work, but prevent them from saving or performing some button-based action, until the page has loaded (other scripts have loaded).</remarks>
		[
		Description("Gets or sets whether the button disabled itself until page load, using ASP.NET AJAX client-side page load event.  If rendering mode set to server-only, this will not work as expected (disabled permanently)."),
		DefaultValue(false)
		]
		public bool DisableUntilPageLoad
		{
			get { return (bool)(ViewState["DisableUntilPageLoad"] ?? false); }
			set { ViewState["DisableUntilPageLoad"] = value; }
		}

		/// <summary>
		/// Gets or sets the alternate text to display when the button is in image mode.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(""),
		Description("Gets or sets the alternate text to display when the button is in image mode.")
		]
		public string ImageAlternateText
		{
			get { return (string)ViewState["ImageAlternateText"]; }
			set { ViewState["ImageAlternateText"] = value; }
		}

		/// <summary>
		/// Gets or sets the image url to show when in image mode.
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(""),
		UrlProperty,
		Description("Gets or sets the image url to show when in image mode.")
		]
		public string ImageUrl
		{
			get { return (string)ViewState["ImageUrl"]; }
			set { ViewState["ImageUrl"] = value; }
		}

		/// <summary>
		/// Gets or sets the format of the button, whether it is a link, button, or image.
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(ButtonType.Link),
		Description("Gets or sets the format of the button, whether it is a link, button, or image.")
		]
		public ButtonType Mode
		{
			get { return (ButtonType)(ViewState["Mode"] ?? ButtonType.Link); }
			set { ViewState["Mode"] = value; }
		}

		/// <summary>
		/// Gets or sets the script that will run client-side.
		/// </summary>
		[
		Category("Client Features"),
		DefaultValue(""),
		Description("Gets or sets the script that will run client-side.")
		]
		public string OnClientClick
		{
			get { return (string)ViewState["OnClientClick"]; }
			set { ViewState["OnClientClick"] = value; }
		}

		internal ButtonList ParentList
		{
			get { return _parentList; }
			set { _parentList = value; }
		}

		/// <summary>
		/// Gets or sets whether to postback to the server always.  In client-side mode, it's not always easy to distinguish when to postback to the server.  This property makes that determination (as one option).
		/// </summary>
		[
		Category("Behavior"),
		Description("Gets or sets whether to postback to the server always.  In client-side mode, it's not always easy to distinguish when to postback to the server.  This property makes that determination (as one option).")
		]
		public bool PostBackAlways
		{
			get { return (bool)(ViewState["PostBackAlways"] ?? false); }
			set { ViewState["PostBackAlways"] = value; }
		}

		/// <summary>
		/// Gets or sets the URL to post back to when the button is clicked.
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(""),
		UrlProperty("*.aspx"),
		Description("Gets or sets the URL to post back to when the button is clicked.")
		]
		public string PostBackUrl
		{
			get { return (string)ViewState["PostBackUrl"]; }
			set { ViewState["PostBackUrl"] = value; }
		}

		/// <summary>
		/// Gets or sets the text of the button.
		/// </summary>
		[
		Category("Data"),
		DefaultValue(""),
		Description("Gets or sets the text of the button.")
		]
		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}

		/// <summary>
		/// Gets or sets whether, in mode of button, a submit button is used instead of a regular button.
		/// </summary>
		[
		Category("Validation"),
		DefaultValue(""),
		Description("Gets or sets the group that the control is within to trigger validation for.")
		]
		public bool UseSubmitBehavior
		{
			get 
			{
				if (this.Mode == ButtonType.Button)
					return (bool)(ViewState["UseSubmitBehavior"] ?? (this.RenderingMode == RenderMode.ServerOnly ? true : false));
				else
					return false;
			}
			set { ViewState["UseSubmitBehavior"] = value; }
		}

		/// <summary>
		/// Gets or sets the group that the control is within to trigger validation for.
		/// </summary>
		[
		Category("Validation"),
		DefaultValue(""),
		Description("Gets or sets the group that the control is within to trigger validation for.")
		]
		public string ValidationGroup
		{
			get { return (string)ViewState["ValidationGroup"]; }
			set { ViewState["ValidationGroup"] = value; }
		}

		/// <summary>
		/// Gets or sets the visibility group to group this button in.  Used only when in a ButtonList, this property sets the group of buttons to link visibility wise.
		/// </summary>
		[
		Description("Gets or sets the visibility group to group this button in.  Used only when in a ButtonList, this property sets the group of buttons to link visibility wise.")
		]
		public string VisibilityGroup
		{
			get { return (string) ViewState["VisibilityGroup"]; }
			set { ViewState["VisibilityGroup"] = value; }
		}

		#endregion



		#region " Methods "

		protected override void AddScriptComponents()
		{
			base.AddScriptComponents();

			this.ScriptComponents.Add(this.ButtonClientEvents);
		}

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(Button), this.ClientID));
			descriptor.AddProperty("causesValidation", this.CausesValidation);
			descriptor.AddPropertyIfExists("commandArgument", this.CommandArgument);
			descriptor.AddPropertyIfExists("commandName", this.CommandName);
			if (this.DisableUntilPageLoad)
				descriptor.AddProperty("disableUntilPageLoad", this.DisableUntilPageLoad);

			if (this.DisableOnFirstClick)
			{
				descriptor.AddProperty("disableOnFirstClick", this.DisableOnFirstClick);
				descriptor.AddProperty("disableOnFirstClickTimeout", this.DisableOnFirstClickTimeout);
			}
			if (!string.IsNullOrEmpty(this.ImageUrl))
				descriptor.AddProperty("imageUrl", Page.ResolveClientUrl(this.ImageUrl));
			descriptor.AddPropertyIfExists("imageAlternateText", this.ImageAlternateText);

			if (this.ParentList != null)
				descriptor.AddComponentProperty("parentList", this.ParentList.ClientID);
			if (this.PostBackAlways)
				descriptor.AddProperty("postBackAlways", this.PostBackAlways);
			descriptor.AddProperty("postBackUrl", this.PostBackUrl);
			descriptor.AddProperty("text", this.Text);
			descriptor.AddPropertyIfExists("validationGroup", this.ValidationGroup);
			descriptor.AddPropertyIfExists("visibilityGroup", this.VisibilityGroup);
		}

		public string GetOnClickScript()
		{
			if (!string.IsNullOrEmpty(this.PostBackUrl))
			{
				PostBackOptions options = new PostBackOptions(this, "");
				options.ActionUrl = this.PostBackUrl;

				return Page.ClientScript.GetPostBackEventReference(options);
			}

			if (!string.IsNullOrEmpty(this.OnClientClick))
				return this.OnClientClick;

			if (this.RenderingMode == RenderMode.ServerOnly)
			{
				if (!this.UseSubmitBehavior)
					return string.Format("__doPostBack('{0}', '{1}');", this.UniqueID, this.CommandName);
			}

			return null;
		}

		protected string GetPostBackEventReference(bool registerForEventReference)
		{
			PostBackOptions options = new PostBackOptions(this, string.Empty);
			options.ClientSubmit = false;
			if (this.Page != null)
			{
				if (this.CausesValidation && (this.Page.GetValidators(this.ValidationGroup).Count > 0))
				{
					options.PerformValidation = true;
					options.ValidationGroup = this.ValidationGroup;
				}
				if (!string.IsNullOrEmpty(this.PostBackUrl))
				{
					options.ActionUrl = base.ResolveClientUrl(this.PostBackUrl);
				}
				options.ClientSubmit = !this.UseSubmitBehavior;
			}
			return Page.ClientScript.GetPostBackEventReference(options, registerForEventReference);

			//PostBackOptions options = new PostBackOptions(this, this.CommandArgument);

			//if (!string.IsNullOrEmpty(this.PostBackUrl) && this.PostBackAlways)
			//{
			//    options.ActionUrl = this.PostBackUrl;
			//}

			//options.ClientSubmit = (this.RenderingMode != RenderMode.ServerOnly);

			//if (this.CausesValidation && Page.GetValidators(this.ValidationGroup).Count > 0)
			//{
			//    options.PerformValidation = true;
			//    options.ValidationGroup = this.ValidationGroup;
			//}

			//options.RequiresJavaScriptProtocol = true;

			//return Page.ClientScript.GetPostBackEventReference(options, registerForEventReference);
		}

		/// <summary>
		/// Creates a script for the appropriate property within the button.
		/// </summary>
		public string GetPostbackScript()
		{
			if (this.RenderingMode == RenderMode.ServerOnly && (this.UseSubmitBehavior || this.PostBackAlways))
				return this.GetPostBackEventReference(false);
			else
			{
				if (!string.IsNullOrEmpty(this.OnClientClick))
					return JavaScriptUtility.AppendSemiColon(this.OnClientClick.Trim());
				else
					return string.Empty;
			}
		}

		/// <summary>
		/// Loads any state that was stored back into the control.
		/// </summary>
		/// <param name="savedState">The state that was last saved for the control.</param>
		protected override void LoadControlState(object savedState)
		{
			object[] state = (object[])savedState;

			if (state != null && state.Length == 2)
			{
				base.LoadControlState(state[0]);
				_text = state[1].ToString();
			}
		}

		/// <summary>
		/// Raises the click event.
		/// </summary>
		/// <param name="e">The arguments related to the click.</param>
		protected virtual void OnClick(EventArgs e)
		{
			if (Click != null)
				Click(this, e);
		}

		/// <summary>
		/// Raises the command event, and also bubbles up this event with the command arguments.
		/// </summary>
		/// <param name="e">The arguments related to the command trigger.</param>
		protected virtual void OnCommand(CommandEventArgs e)
		{
			if (Command != null)
				Command(this, e);
			base.OnBubbleEvent(this, e);
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			Page.RegisterRequiresControlState(this);
		}

		/// <summary>
		/// Handles triggering the postback event.  Triggers the appropriate validation group if one is provided.
		/// </summary>
		/// <param name="eventArgument">The argument that was posted back to the server, for processing.</param>
		public void RaisePostBackEvent(string eventArgument)
		{
			if (this.CausesValidation)
				Page.Validate(this.ValidationGroup);

			this.OnClick(EventArgs.Empty);
			if (!string.IsNullOrEmpty(this.CommandName))
				this.OnCommand(new CommandEventArgs(this.CommandName, this.CommandArgument));
		}

		/// <summary>
		/// Saves the target values to control state.
		/// </summary>
		/// <returns>The collection of objects to store in control state.</returns>
		protected override object SaveControlState()
		{
			object[] state = new object[2];
			state[0] = base.SaveControlState();
			state[1] = _text;

			return state;
		}

		#endregion
	}
}
