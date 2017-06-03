using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using Nucleo.Context;
using Nucleo.Web.Core;
using Nucleo.Web.Pages;
using Nucleo.Web.Tags;
using Nucleo.Web.Tags.Custom;


namespace Nucleo.Web.Styles
{
	/// <summary>
	/// Represents the manager that manages Nucleo stylesheets, or other external stylesheets.
	/// </summary>
	public class StylesheetManager : BaseAjaxControl
	{
		private AjaxComponentCollection _components = null;
		private StylesheetCollection _stylesheets = null;



		#region " Properties "

		/// <summary>
		/// Gets the collection of AJAX components internally.
		/// </summary>
		public AjaxComponentCollection Components
		{
			get
			{
				if (_components == null)
					_components = new AjaxComponentCollection();

				return _components;
			}
		}

		/// <summary>
		/// Gets or sets the default file to the theme.  This is the path for Nucleo-specific controls.  Only one file is used for a custom theme.
		/// </summary>
		[
		Description("Gets or sets the default file to the theme.  This is the path for Nucleo-specific controls.  Only one file is used for a custom theme.")
		]
		public string DefaultThemeFile
		{
			get { return (string)ViewState["DefaultThemePath"]; }
			set { ViewState["DefaultThemePath"] = value; }
		}

		public override bool EnableClientState
		{
			get { return false; }
			set { }
		}

		/// <summary>
		/// Gets the collection of stylesheets, that are your own personal stylesheets.
		/// </summary>
		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false),
		Description("Gets the collection of stylesheets, that are your own personal stylesheets.")
		]
		public StylesheetCollection Stylesheets
		{
			get
			{
				if (_stylesheets == null)
					_stylesheets = new StylesheetCollection();

				return _stylesheets;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds the component to the underlying component collection.
		/// </summary>
		/// <param name="component">The component to add locally.</param>
		public void AddComponent(IAjaxComponent component)
		{
			this.Components.Add(component);
		}

		/// <summary>
		/// Adds the component's stylesheets to the header.
		/// </summary>
		/// <param name="header">The header.</param>
		private void AddComponentStylesheets(HtmlHead header)
		{
			this.AddLink(header, this.DefaultThemeFile);
		}

		/// <summary>
		/// Adds the external stylesheets to the header.
		/// </summary>
		/// <param name="header">The header to add to.</param>
		private void AddExternalStylesheets(HtmlHead header)
		{
			foreach (Stylesheet stylesheet in this.Stylesheets)
			{
				string path = null;

				if (!string.IsNullOrEmpty(Page.ResolveClientUrl(stylesheet.Path)))
					path = stylesheet.Path;
				else
					path = Page.ClientScript.GetWebResourceUrl(stylesheet.ReferenceType, stylesheet.ReferenceName);

				this.AddLink(header, path);
			}
		}

		/// <summary>
		/// Gets the instance of the stylesheet manager stored within the page.
		/// </summary>
		/// <param name="page">The page to get the manager from.</param>
		/// <returns>The manager, or null if not found.</returns>
		public static StylesheetManager GetInstance(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			return page.Items[typeof(StylesheetManager)] as StylesheetManager;
		}

		/// <summary>
		/// Adds a link to the header.
		/// </summary>
		/// <param name="header">The header to add the link to.</param>
		/// <param name="path">The path to reference.</param>
		private void AddLink(HtmlHead header, string path)
		{
			//Create the HTML link
			HtmlLink link = new HtmlLink();
			link.Href = path;
			link.Attributes.Add("type", "text/css");
			link.Attributes.Add("rel", "stylesheet");
			header.Controls.Add(link);
		}

		protected override void OnInit(EventArgs e)
		{
			PageRequestContext context = PageRequestContext.GetCurrent(this);
			if (context != null && context.Singletons != null)
			{
				if (context.Singletons.HasEntry<StylesheetManager>())
					throw new InvalidOperationException("Only one stylesheet manager can exist on a page");

				context.Singletons.AddEntry<StylesheetManager>(this);
			}

			base.OnInit(e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			this.AddComponentStylesheets(this.Page.Header);
			this.AddExternalStylesheets(this.Page.Header);
		}

		protected internal override void OnValidateState(EventArguments.ValidateEventArgs e)
		{
			base.OnValidateState(e);

			if (this.Page.Header == null)
				throw new Exception("The <head> attribute is missing or doesn't define the runat='server' attribute");
		}

		protected override void RenderUI(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create(HiddenTagBuilder.Create(this.ClientID, ""));
			writer.Write(tag.ToHtmlString());
		}

		#endregion
	}
}
