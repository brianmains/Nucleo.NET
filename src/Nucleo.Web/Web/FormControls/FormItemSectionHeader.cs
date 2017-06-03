using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

using Nucleo.Exceptions;
using Nucleo.Web.Pages;
using Nucleo.Web.Searching;


namespace Nucleo.Web.FormControls
{
	/// <summary>
	/// Represents a header to display above a section to state what the current mode is.
	/// </summary>
	public class FormItemSectionHeader : BaseWebControl 
	{
		#region " Properties "
		
		/// <summary>
		/// Gets or sets the appearance of the header.
		/// </summary>
		public SectionHeaderAppearance Appearance
		{
			get { return (SectionHeaderAppearance)(ViewState["Appearance"] ?? SectionHeaderAppearance.None); }
			set { ViewState["Appearance"] = value; }
		}

		/// <summary>
		/// Gets or sets the text when in update mode.
		/// </summary>
		public string EditText
		{
			get { return (string)ViewState["EditText"]; }
			set { ViewState["EditText"] = value; }
		}

		/// <summary>
		/// Gets or sets the text when in insert mode.
		/// </summary>
		public string InsertText
		{
			get { return (string)ViewState["InsertText"]; }
			set { ViewState["InsertText"] = value; }
		}

		/// <summary>
		/// Gets or sets the text when in readonly mode.
		/// </summary>
		public string ReadonlyText
		{
			get { return (string)ViewState["InsertText"]; }
			set { ViewState["InsertText"] = value; }
		}

		#endregion



		#region " Methods "

		private FormCurrentView GetCurrentView()
		{
			IControlSearcher searcher = null;

			if (this.Page is IPageDriver)
			{
				IPageDriver page = (IPageDriver)this.Page;
				if (page.CurrentContext.ControlSearcher != null)
					searcher = page.CurrentContext.ControlSearcher;
			}

			if (searcher == null)
				searcher = new WebControlSearcher();

			FormItemSection section = searcher.FindParent<FormItemSection>(this);
			if (section != null)
				return section.CurrentView;
			else
				throw new InvalidOperationException("A form item section header cannot be anywhere but in a form section.");
		}

		private string GetTagName()
		{
			if (this.Appearance == SectionHeaderAppearance.None)
				return "";

			return this.Appearance.ToString();
		}

		protected virtual void RenderHeaderText(BaseControlWriter writer)
		{
			var currentView = this.GetCurrentView();
			if (currentView == FormCurrentView.Insert)
				writer.Write(this.InsertText);
			else if (currentView == FormCurrentView.Edit)
				writer.Write(this.EditText);
			else if (currentView == FormCurrentView.ReadOnly)
				writer.Write(this.ReadonlyText);
			else
				throw new ValueImplementationException("FormItemSectionHeader.RenderHeaderText", currentView);
		}

		public override void RenderUI(BaseControlWriter writer)
		{
			string tag = this.GetTagName();

			writer.Write(tag.Length > 0 ? "<" + tag + ">" : "");

			this.RenderHeaderText(writer);			

			writer.Write(tag.Length > 0 ? "</" + tag + ">" : "");
		}

		#endregion
	}
}
