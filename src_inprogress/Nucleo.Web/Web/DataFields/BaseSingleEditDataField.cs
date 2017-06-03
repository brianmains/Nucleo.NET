using System;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataFields
{
	public abstract class BaseSingleEditDataField : BaseSingleDataField
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

		public string InsertDataField
		{
			get
			{
				object o = ViewState["InsertDataField"];
				return (o == null) ? null : (string)o;
			}
			set { ViewState["InsertDataField"] = value; }
		}

		public string SelectDataField
		{
			get
			{
				object o = ViewState["SelectDataField"];
				return (o == null) ? null : (string)o;
			}
			set { ViewState["SelectDataField"] = value; }
		}

		public string UpdateDataField
		{
			get
			{
				object o = ViewState["UpdateDataField"];
				return (o == null) ? null : (string)o;
			}
			set { ViewState["UpdateDataField"] = value; }
		}

		#endregion



		#region " Methods "

		protected override string GetDataItemFieldName(DataControlRowState rowState)
		{
			if (rowState == DataControlRowState.Edit)
			{
				if (!string.IsNullOrEmpty(this.UpdateDataField))
					return this.UpdateDataField;
				else
					return this.DataField;
			}

			if (rowState == DataControlRowState.Insert)
			{
				if (!string.IsNullOrEmpty(this.InsertDataField))
					return this.InsertDataField;
				else
					return this.DataField;
			}

			if (!string.IsNullOrEmpty(this.SelectDataField))
				return this.SelectDataField;
			else
				return this.DataField;
		}

		#endregion
	}
}
