using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataFields
{
	public class BooleanField : BaseSingleDataField
	{
		#region " Properties "

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
		Category("Appearance"),
		DefaultValue("False"),
		Description("The string that appears when the value is false")
		]
		public string FalseString
		{
			get
			{
				object o = ViewState["FalseString"];
				return (o == null) ? bool.FalseString : o.ToString();
			}
			set { ViewState["FalseString"] = value; }
		}

		[
		Category("Appearance"),
		DefaultValue("True"),
		Description("The string that appears when the value is true")
		]
		public string TrueString
		{
			get
			{
				object o = ViewState["TrueString"];
				return (o == null) ? bool.TrueString : o.ToString();
			}
			set { ViewState["TrueString"] = value; }
		}

		#endregion



		#region " Methods "

		public override void BindEditControl(object control, bool insertMode)
		{
			CheckBox box = control as CheckBox;
			if (!insertMode)
				box.Checked = this.GetDataItemValue<bool>(box.NamingContainer, this.DataField);
		}

		protected override string GetDataItemFieldName(DataControlRowState state)
		{
			return this.DataField;
		}

		protected override string GetReadOnlyValue(TableCell cell, object initialValue)
		{
			if (initialValue == null)
				return bool.FalseString;

			bool value = (bool)initialValue;
			return value ? this.TrueString : this.FalseString;
		}

		public override string GetEditControlValue(TableCell cell)
		{
			return this.ExtractControl<CheckBox>(cell).Checked.ToString();
		}

		public static string GetUnboundEditValue(TableCell cell)
		{
			if (BasePrimitiveDataField.IsEmptyCell(cell))
				return string.Empty;

			return ((CheckBox)cell.Controls[0]).Checked.ToString();
		}

		public override Control SetupEditControl()
		{
			return new CheckBox();
		}

		#endregion
	}
}
