using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataFields
{
	public class DropDownField : BaseSingleDataField
	{
		private ListItemCollection _items = null;



		#region " Properties "

		public bool AppendDataBoundItems
		{
			get
			{
				object o = ViewState["AppendDataBoundItems"];
				return (o == null) ? true : (bool)o;
			}
			set { ViewState["AppendDataBoundItems"] = value; }
		}

		[
		IDReferenceProperty(typeof(IDataSource))
		]
		public string DataSourceID
		{
			get
			{
				object o = ViewState["DataSourceID"];
				return (o == null) ? null : o.ToString();
			}
			set { ViewState["DataSourceID"] = value; }
		}

		public string DataSelectedValueField
		{
			get
			{
				object o = ViewState["DataSelectedValueField"];
				return (o == null) ? null : (string)o;
			}
			set { ViewState["DataSelectedValueField"] = value; }
		}

		public string DataTextField
		{
			get
			{
				object o = ViewState["DataTextField"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["DataTextField"] = value; }
		}

		public string DataValueField
		{
			get
			{
				object o = ViewState["DataValueField"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["DataValueField"] = value; }
		}

		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
		PersistenceMode(PersistenceMode.InnerDefaultProperty)
		]
		public ListItemCollection Items
		{
			get
			{
				if (_items == null)
					_items = new ListItemCollection();
				return _items;
			}
		}

		#endregion



		#region " Methods "

		public override void BindEditControl(object control, bool insertMode)
		{
			DropDownList list = control as DropDownList;
			if (!insertMode)
				list.SelectedValue = this.GetDataItemValue<string>(list.NamingContainer, this.DataSelectedValueField);
		}

		protected override string GetDataItemFieldName(DataControlRowState state)
		{
			return this.DataSelectedValueField;
		}

		public override string GetEditControlValue(TableCell cell)
		{
			return this.ExtractControl<DropDownList>(cell).SelectedValue;
		}

		public static string GetUnboundEditValue(TableCell cell)
		{
			if (BasePrimitiveDataField.IsEmptyCell(cell))
				return string.Empty;

			return ((DropDownList)cell.Controls[0]).SelectedValue;
		}

		public override Control SetupEditControl()
		{
			DropDownList list = new DropDownList();
			if (!string.IsNullOrEmpty(this.DataTextField))
				list.DataTextField = this.DataTextField;
			if (!string.IsNullOrEmpty(this.DataValueField))
				list.DataValueField = this.DataValueField;
			if (!string.IsNullOrEmpty(this.DataSourceID))
			{
				list.DataSourceID = this.DataSourceID;
				list.DataBind();
			}
			else if (this.Items != null && this.Items.Count > 0)
			{
				foreach (ListItem item in this.Items)
					list.Items.Add(item);
			}

			return list;
		}

		#endregion
	}
}
