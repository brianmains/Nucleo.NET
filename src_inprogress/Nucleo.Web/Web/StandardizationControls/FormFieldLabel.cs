using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.StandardizationControls
{
	public class FormFieldLabel : BaseWebControl, ITextControl
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the control ID that its associated with.
		/// </summary>
		public string AssociatedControlID
		{
			get { return (string)ViewState["AssociatedControlID"]; }
			set { ViewState["AssociatedControlID"] = value; }
		}

		public override string CssClass
		{
			get { return "NucleoFormFieldLabel"; }
			set { }
		}

		/// <summary>
		/// Gets or sets the image URL of the label.
		/// </summary>
		public string ImageUrl
		{
			get { return (string)ViewState["ImageUrl"]; }
			set { ViewState["ImageUrl"] = value; }
		}

		/// <summary>
		/// Gets or sets whether to include a colon at the end.  This does an explicit check.
		/// </summary>
		public bool IncludeColonAtEnd
		{
			get { return (bool)(ViewState["IncludeColonAtEnd"] ?? false); }
			set { ViewState["IncludeColonAtEnd"] = value; }
		}

		/// <summary>
		/// Gets or sets the text of the label.
		/// </summary>
		public string Text
		{
			get { return (string)ViewState["Text"]; }
			set { ViewState["Text"] = value; }
		}

		#endregion
		


		#region " Methods "

		public string GetText()
		{
			if (string.IsNullOrEmpty(this.Text))
				return null;

			string text = this.Text.Trim();

			if (!this.IncludeColonAtEnd)
				return text;
			
			if (!text.EndsWith(":"))
				text += ":";

			return text;
		}

		protected virtual void RenderImageUrl(BaseControlWriter writer)
		{
			writer.Write("<img src=\"" + this.ImageUrl + "\" />");
		}

		public override void RenderUI(BaseControlWriter writer)
		{
			if (!string.IsNullOrEmpty(this.AssociatedControlID))
			{
				writer.WriteUnclosedBeginTag("label", this.ClientID, this.UniqueID);

				Control control = ControlUtility.FindControl(this, this.AssociatedControlID);
				writer.Write(" for='" + control.ClientID + "'");
			}
			else
			{
				writer.WriteUnclosedBeginTag("span");
			}

			writer.Write(" class='" + this.CssClass + "'>");

			if (!string.IsNullOrEmpty(this.ImageUrl))
				this.RenderImageUrl(writer);

			writer.Write(this.GetText());

			if (!string.IsNullOrEmpty(this.AssociatedControlID))
				writer.WriteEndTag("label");
			else
				writer.WriteEndTag("span");
		}

		#endregion
	}
}
