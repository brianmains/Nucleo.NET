using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataFields
{
	/// <summary>
	/// The HyperlinkTextField is useful for editing a URL directly; it is not a link control, but rather a means to edit the URL of a link.
	/// </summary>
	public class HyperlinkTextField : BaseSingleDataField
	{
		#region " Properties "

		public string DataNavigateUrlField
		{
			get
			{
				object o = ViewState["DataNavigateUrlField"];
				return (o == null) ? null : (string)o;
			}
			set { ViewState["DataNavigateUrlField"] = value; }
		}

		public string Text
		{
			get
			{
				object o = ViewState["Text"];
				return (o == null) ? string.Empty : o.ToString();
			}
			set { ViewState["Text"] = value; }
		}

		#endregion



		#region " Methods "

		public override void BindEditControl(object control, bool insertMode)
		{
			TextBox box = control as TextBox;
			if (!insertMode)
				box.Text = this.GetDataItemValue<string>(box.NamingContainer, this.DataNavigateUrlField);
		}

		protected override string GetDataItemFieldName(DataControlRowState state)
		{
			return this.DataNavigateUrlField;
		}

		public override string GetEditControlValue(TableCell cell)
		{
			return this.ExtractControl<TextBox>(cell).Text;
		}

		protected override string GetReadOnlyValue(TableCell cell, object initialValue)
		{
			if (initialValue == null || initialValue == string.Empty)
				return string.Empty;

			string text = !string.IsNullOrEmpty(this.Text) ? this.Text : initialValue.ToString();
			return string.Format("<a href=\"{0}\">{1}</a>", initialValue, text);
		}

		public static string GetUnboundEditValue(TableCell cell)
		{
			if (BasePrimitiveDataField.IsEmptyCell(cell))
				return string.Empty;

			return ((TextBox)cell.Controls[0]).Text;
		}

		public override Control SetupEditControl()
		{
			return new TextBox();
		}

		#endregion
	}
}
