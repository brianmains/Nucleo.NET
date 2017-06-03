using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataFields
{
	public class TextField : BaseSingleDataField
	{
		#region " Properties "

		[
		DefaultValue(0)
		]
		public int Columns
		{
			get
			{
				object o = ViewState["Columns"];
				return (o == null) ? 0 : (int)o;
			}
			set { ViewState["Columns"] = value; }
		}

		public string DataField
		{
			get
			{
				object o = ViewState["DataField"];
				return (o == null) ? null : (string)o;
			}
			set { ViewState["DataField"] = value; }
		}

		[
		DefaultValue(0)
		]
		public int MaximumLength
		{
			get
			{
				object o = ViewState["MaximumLength"];
				return (o == null) ? 0 : (int)o;
			}
			set { ViewState["MaximumLength"] = value; }
		}

		[
		DefaultValue(0)
		]
		public int Rows
		{
			get
			{
				object o = ViewState["Rows"];
				return (o == null) ? 0 : (int)o;
			}
			set { ViewState["Rows"] = value; }
		}

		[
		DefaultValue(TextBoxMode.SingleLine)
		]
		public TextBoxMode TextMode
		{
			get
			{
				object o = ViewState["TextMode"];
				return (o == null) ? TextBoxMode.SingleLine : (TextBoxMode)o;
			}
			set { ViewState["TextMode"] = value; }
		}

		#endregion



		#region " Methods "

		public override void BindEditControl(object control, bool insertMode)
		{
			TextBox box = control as TextBox;
			//If not in insert mode, set the text property
			if (!insertMode)
				box.Text = this.GetDataItemValue<string>(box.NamingContainer, this.DataField);
		}

		protected override string GetDataItemFieldName(DataControlRowState state)
		{
			return this.DataField;
		}

		public override string GetEditControlValue(TableCell cell)
		{
			return this.ExtractControl<TextBox>(cell).Text;
		}

		public static string GetUnboundEditValue(TableCell cell)
		{
			if (BasePrimitiveDataField.IsEmptyCell(cell))
				return string.Empty;

			return ((TextBox)cell.Controls[0]).Text;
		}

		public override Control SetupEditControl()
		{
			TextBox box = new TextBox();
			box.TextMode = this.TextMode;
			box.Rows = this.Rows;
			box.Columns = this.Columns;
			box.MaxLength = this.MaximumLength;
			box.ToolTip = this.HeaderText;
			return box;
		}

		#endregion
	}
}
