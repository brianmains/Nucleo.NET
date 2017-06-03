using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.HiddenField
{
	public partial class FirstLook : Nucleo.Framework.TestPage
	{
		#region " Methods "

		private void BindGrid()
		{
			DataTable table = new DataTable();
			table.Columns.Add("ID", typeof(int));
			table.Columns.Add("Name", typeof(string));

			DataRow row = table.NewRow();
			row["ID"] = 1;
			row["Name"] = "First";
			table.Rows.Add(row);

			row = table.NewRow();
			row["ID"] = 2;
			row["Name"] = "Second";
			table.Rows.Add(row);

			row = table.NewRow();
			row["ID"] = 3;
			row["Name"] = "Third";
			table.Rows.Add(row);

			row = table.NewRow();
			row["ID"] = 4;
			row["Name"] = "Fourth";
			table.Rows.Add(row);

			row = table.NewRow();
			row["ID"] = 5;
			row["Name"] = "Fifth";
			table.Rows.Add(row);

			this.gvw.DataSource = table;
			this.gvw.DataBind();
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if (!Page.IsPostBack)
			{
				this.BindGrid();

				string[] values = this.hdnManager.GetKeyValues("Numbers");
				foreach (string value in values)
					this.ServerOutput.Text += string.Format("Number Value: {0}<br/>", value);

				string singleValue = this.hdnManager.GetFirstKeyValue("Letters");
				this.ServerOutput.Text += string.Format("Single Value: {0}<br/>", singleValue);

				values = this.hdnManager.GetKeyValues("Grid");
				foreach (string value in values)
					this.ServerOutput.Text += string.Format("Grid Value: {0}<br/>", value);
			}
		}

		#endregion
	}
}
