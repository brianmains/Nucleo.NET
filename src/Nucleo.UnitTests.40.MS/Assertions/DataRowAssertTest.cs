using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Assertions
{
	[TestClass]
	public class DataRowAssertTest
	{
		private DataTable _dataSource = null;



		#region " Tests "

		[TestFixtureSetUp]
		public void Initialize()
		{
			_dataSource = new DataTable();
			_dataSource.Columns.Add("Name", typeof(string));
			_dataSource.Columns.Add("Email", typeof(string));
			_dataSource.Columns.Add("Phone", typeof(string));

			DataRow row = _dataSource.NewRow();
			row["Name"] = "Brian";
			row["Email"] = "bgmst5@yahoo.com";
			row["Phone"] = "2221113333";
			_dataSource.Rows.Add(row);
		}

		[Test]
		public void TestNullAssertions()
		{
			DataRow row = _dataSource.Rows[0];

			DataRowAssert.ItemsAreNotNull(row);
			DataRowAssert.ItemIsNotNull(row, "Name");
			DataRowAssert.ItemIsNotNull(row, 1);
			DataRowAssert.ItemIsNotNull(row, "Phone");

			row.BeginEdit();
			row["Phone"] = DBNull.Value;
			row.EndEdit();
			DataRowAssert.ItemIsNull(row, "Phone");
			DataRowAssert.ItemIsNull(row, 2);
		}

		#endregion
	}
}