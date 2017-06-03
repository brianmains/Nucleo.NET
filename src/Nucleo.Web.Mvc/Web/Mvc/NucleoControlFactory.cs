using System;
using System.Web.UI;
using System.Web.Mvc;

using Nucleo.Web.Mvc.ButtonControls;
using Nucleo.Web.Mvc.Content;
using Nucleo.Web.Mvc.Controls;
using Nucleo.Web.Mvc.DataControls;
using Nucleo.Web.Mvc.DropDownControls;
using Nucleo.Web.Mvc.EditorControls;
using Nucleo.Web.Mvc.ListControls;
using Nucleo.Web.Mvc.ValidationControls;


namespace Nucleo.Web.Mvc
{
	public class NucleoControlFactory
	{
		private ContentManager _content = null;
		private HtmlHelper _html = null;



		#region " Properties "

		public HtmlHelper Html
		{
			get { return _html; }
		}

		#endregion



		#region " Constructors "

		public NucleoControlFactory(HtmlHelper html)
		{
			_html = html;
			_content = new ContentManager(this);
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets a binding panel, which can easily display a no-data template on data binding.
		/// </summary>
		/// <typeparam name="T">The type of component being bound.</typeparam>
		/// <param name="data">The data.</param>
		/// <returns>The component builder.</returns>
		public BindingPanelComponentBuilder<T> BindingPanel<T>(T data)
		{
			return new BindingPanelComponentBuilder<T>(this, data);
		}

		/// <summary>
		/// Gets a button (image, link, or standard) that can fire a client-side event or fire back to the server.
		/// </summary>
		/// <returns>The control builder.</returns>
		public ButtonControlBuilder Button()
		{
			return new ButtonControlBuilder(this);
		}

		/// <summary>
		/// Gets a check control that has a yes, no, and empty state (latter one optional).
		/// </summary>
		/// <returns>The control builder.</returns>
		public CheckControlBuilder Check()
		{
			return new CheckControlBuilder(this);
		}

		/// <summary>
		/// Gets the content manager, which manages the content for the controls.
		/// </summary>
		/// <returns>The content manager.</returns>
		public ContentManager Content()
		{
			return _content;
		}

		public DropDownControlBuilder DropDown()
		{
			return new DropDownControlBuilder(this);
		}

		public LinkControlBuilder Link()
		{
			return new LinkControlBuilder(this);
		}

		protected internal Page Page()
		{
			if (this.Html.ViewDataContainer is ViewPage)
				return (ViewPage)this.Html.ViewDataContainer;
			else if (this.Html.ViewDataContainer is ViewUserControl)
				return ((ViewUserControl)this.Html.ViewDataContainer).Page;
			else if (this.Html.ViewDataContainer is ViewMasterPage)
				return ((ViewMasterPage)this.Html.ViewDataContainer).Page;
			else
				return null;
		}

		public PageableListControlBuilder PageableList()
		{
			return new PageableListControlBuilder(this);
		}

		public TextEditorControlBuilder TextEditor()
		{
			return new TextEditorControlBuilder(this);
		}

		public ValidationResultsControlBuilder ValidationResults()
		{
			return new ValidationResultsControlBuilder(this);
		}

		#endregion
	}
}
