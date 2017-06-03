using System;
using System.ComponentModel;
using System.Web.UI;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Web.Context;
using Nucleo.Web.Context.Services;

namespace Nucleo.Web.Controls
{
	/// <summary>
	/// Represents a check based interface control.
	/// </summary>
	[
	WebScriptMetadata(typeof(CheckScriptMetadata)),
	WebRenderer(typeof(CheckRenderer))
	]
	public class Check : BaseAjaxControl, ITextControl, IPostBackEventHandler
	{
		private CheckImage _emptyImage = null;
		private CheckImage _falseImage = null;
		private CheckImage _trueImage = null;



		#region " Events "

		public event EventHandler CheckChanged;

		#endregion

		

		#region " Properties "

		/// <summary>
		/// Gets or sets whether an empty check state (null) is allowed.
		/// </summary>
		public bool AllowEmptyCheckState
		{
			get { return (bool)(ViewState["AllowEmptyCheckState"] ?? false); }
			set { ViewState["AllowEmptyCheckState"] = value; }
		}

		/// <summary>
		/// Gets or sets the checked status of the checkbox.
		/// </summary>
		public bool? Checked
		{
			get
			{
				if (ViewState["Checked"] != null)
					return (bool)ViewState["Checked"];

				if (this.AllowEmptyCheckState)
					return null;
				else
					return false;
			}
			set { ViewState["Checked"] = value; }
		}

		/// <summary>
		/// Gets the image that represents the empty option.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public CheckImage EmptyImage
		{
			get
			{
				if (_emptyImage == null)
					_emptyImage = new CheckImage(null);
				return _emptyImage;
			}
		}

		/// <summary>
		/// Gets the image that represents the false option.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public CheckImage FalseImage
		{
			get
			{
				if (_falseImage == null)
					_falseImage = new CheckImage(false);
				return _falseImage;
			}
		}

		public bool HasEmptyImage
		{
			get { return (_emptyImage != null); }
		}

		public bool HasFalseImage
		{
			get { return (_falseImage != null); }
		}

		public bool HasTrueImage
		{
			get { return (_trueImage != null); }
		}

		/// <summary>
		/// Gets the check image that's selected.
		/// </summary>
		public CheckImage SelectedImage
		{
			get
			{
				if (this.Checked == true)
					return this.TrueImage;
				else if (this.Checked == false)
					return this.FalseImage;
				else
					return this.EmptyImage;
			}
		}

		/// <summary>
		/// Gets or sets the text to use for the check area.
		/// </summary>
		public string Text
		{
			get { return (string) ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		/// <summary>
		/// Gets or sets the text format to use for the check area.
		/// </summary>
		public string TextFormat
		{
			get { return (string) ViewState["TextFormat"]; }
			set { ViewState["TextFormat"] = value; }
		}

		/// <summary>
		/// Gets the image that represents the true option.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public CheckImage TrueImage
		{
			get
			{
				if (_trueImage == null)
					_trueImage = new CheckImage(true);
				return _trueImage;
			}
		}

		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(Check), this.ClientID));
			descriptor.AddProperty("checked", this.Checked);
			descriptor.AddProperty("text", this.GetText());
			if (this.AllowEmptyCheckState)
				descriptor.AddProperty("allowEmptyCheckState", this.AllowEmptyCheckState);

			if (_emptyImage != null)
				descriptor.AddProperty("emptyImage", new CheckImage(
					Page.ResolveClientUrl(_emptyImage.ImageUrl),
					Page.ResolveClientUrl(_emptyImage.DisabledImageUrl ?? _emptyImage.ImageUrl), null));

			if (_falseImage != null)
				descriptor.AddProperty("falseImage", new CheckImage(
					Page.ResolveClientUrl(_falseImage.ImageUrl),
					Page.ResolveClientUrl(_falseImage.DisabledImageUrl ?? _falseImage.ImageUrl), false));

			if (_trueImage != null)
				descriptor.AddProperty("trueImage", new CheckImage(
					Page.ResolveClientUrl(_trueImage.ImageUrl),
					Page.ResolveClientUrl(_trueImage.DisabledImageUrl ?? _trueImage.ImageUrl), true));
		}

		/// <summary>
		/// Gets a collection of all of the images related to the check options.
		/// </summary>
		/// <returns>The collection of check images.</returns>
		public CheckImageCollection GetCheckImages()
		{
			CheckImageCollection images = new CheckImageCollection();
			images.Add(this.TrueImage);
			images.Add(this.FalseImage);
			if (this.AllowEmptyCheckState)
				images.Add(this.EmptyImage);

			return images;
		}

		/// <summary>
		/// Gets the default image to use for the empty option.
		/// </summary>
		/// <param name="page">The control to use for the web resource url (general reference).</param>
		/// <returns>The URL to the image.</returns>
		public static string GetDefaultEmptyImageUrl(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			return NucleoAjaxManager.GetWebResourceUrl(page, typeof(Check), "Nucleo.Web.Controls.checkempty.png");
		}

		/// <summary>
		/// Gets the default image to use for the no option, when disabled.
		/// </summary>
		/// <param name="page">The control to use for the web resource url (general reference).</param>
		/// <returns>The URL to the image.</returns>
		public static string GetDefaultDisabledNoImageUrl(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			return NucleoAjaxManager.GetWebResourceUrl(page, typeof(Check), "Nucleo.Web.Controls.checknodisabled.png");
		}

		/// <summary>
		/// Gets the default image to use for the no option.
		/// </summary>
		/// <param name="page">The control to use for the web resource url (general reference).</param>
		/// <returns>The URL to the image.</returns>
		public static string GetDefaultNoImageUrl(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			return NucleoAjaxManager.GetWebResourceUrl(page, typeof(Check), "Nucleo.Web.Controls.checkno.png");
		}

		/// <summary>
		/// Gets the default image to use for the yes option, when disabled.
		/// </summary>
		/// <param name="page">The control to use for the web resource url (general reference).</param>
		/// <returns>The URL to the image.</returns>
		public static string GetDefaultDisabledYesImageUrl(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			return NucleoAjaxManager.GetWebResourceUrl(page, typeof(Check), "Nucleo.Web.Controls.checkyesdisabled.png");
		}

		/// <summary>
		/// Gets the default image to use for the yes option.
		/// </summary>
		/// <param name="page">The control to use for the web resource url (general reference).</param>
		/// <returns>The URL to the image.</returns>
		public static string GetDefaultYesImageUrl(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			return NucleoAjaxManager.GetWebResourceUrl(page, typeof(Check), "Nucleo.Web.Controls.checkyes.png");
		}

		/// <summary>
		/// Gets the image url for the check that's selected in the list.
		/// </summary>
		/// <returns>The image url for the check image.</returns>
		public string GetSelectedImageUrl()
		{
			CheckImage image = this.SelectedImage;
			if (image == null)
				return null;

			string url = (this.Enabled) ? image.ImageUrl :
				(!string.IsNullOrEmpty(image.DisabledImageUrl)) ? image.DisabledImageUrl : image.ImageUrl;

			ApplicationContext context = ApplicationContext.GetCurrent();
			if (context != null)
			{
				Nucleo.Web.Context.Services.IUrlResolutionService service = context.GetService<Nucleo.Web.Context.Services.IUrlResolutionService>();
				if (service != null)
					return service.GetClientBasedUrl(url);
			}

			return NucleoAjaxManager.ResolveClientUrl(url);
		}

		/// <summary>
		/// Gets the text for the check, using the format string to place the text or using the text directly.
		/// </summary>
		/// <returns>Returns the text for the check.</returns>
		public string GetText()
		{
			if (!string.IsNullOrEmpty(this.TextFormat))
				return string.Format(this.TextFormat, this.Text);
			else
				return this.Text;
		}

		protected override void LoadClientState(ClientState.ClientStateData stateData)
		{
			base.LoadClientState(stateData);

			if (stateData.Values.ContainsKey("hasChanges") && ((bool)stateData.Values["hasChanges"]) == true)
				this.OnCheckChanged(EventArgs.Empty);
		}

		protected virtual void OnCheckChanged(EventArgs e)
		{
			if (CheckChanged != null)
				CheckChanged(this, e);
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (string.IsNullOrEmpty(this.TrueImage.ImageUrl))
				this.TrueImage.ImageUrl = GetDefaultYesImageUrl(this.Page);
			if (string.IsNullOrEmpty(this.TrueImage.DisabledImageUrl))
				this.TrueImage.DisabledImageUrl = GetDefaultDisabledYesImageUrl(this.Page);
			if (string.IsNullOrEmpty(this.FalseImage.ImageUrl))
				this.FalseImage.ImageUrl = GetDefaultNoImageUrl(this.Page);
			if (string.IsNullOrEmpty(this.FalseImage.DisabledImageUrl))
				this.FalseImage.DisabledImageUrl = GetDefaultDisabledNoImageUrl(this.Page);
			if (string.IsNullOrEmpty(this.EmptyImage.ImageUrl))
				this.EmptyImage.ImageUrl = GetDefaultEmptyImageUrl(this.Page);
			if (string.IsNullOrEmpty(this.EmptyImage.DisabledImageUrl))
				this.EmptyImage.DisabledImageUrl = GetDefaultEmptyImageUrl(this.Page);
		}

		/// <summary>
		/// Receives a toggle event, in server-side mode, when the check is clicked.
		/// </summary>
		/// <param name="eventArgument">The toggle event argument.</param>
		void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
		{
			if (eventArgument.ToLower() == "toggle")
				this.ToggleCheckedValue();
		}

		/// <summary>
		/// Toggles the checked value by toggling the selection of the images.
		/// </summary>
		public void ToggleCheckedValue()
		{
			if (!this.Checked.HasValue)
				this.Checked = true;
			else if (this.Checked == true)
				this.Checked = false;
			else if (this.Checked == false)
			{
				if (this.AllowEmptyCheckState)
					this.Checked = null;
				else
					this.Checked = true;
			}
		}

		#endregion
	}
}
