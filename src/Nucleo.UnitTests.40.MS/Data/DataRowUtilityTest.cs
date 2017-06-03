using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Data
{
	[TestClass]
	public class DataRowUtilityTest
	{
		#region " Methods "

		private DataTable GetTable()
		{
			DataTable table = new DataTable();
			table.Columns.Add("ID", typeof(int));
			table.Columns.Add("Code", typeof(string));
			table.Columns.Add("Name", typeof(string));

			DataRow row = table.NewRow();
			row["ID"] = 1;
			row["Code"] = "PDF";
			row["Name"] = "Adobe PDF";
			table.Rows.Add(row);

			row = table.NewRow();
			row["ID"] = 2;
			row["Code"] = "XML";
			row["Name"] = "Excel";
			table.Rows.Add(row);

			return table;
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void TestGetDatabaseValue()
		{
			DateTime testDate = DateTime.MinValue;
			Assert.AreEqual(DBNull.Value, DataRowUtility.GetDatabaseValue(testDate));

			testDate = new DateTime(1753, 1, 1);
			Assert.IsInstanceOfType(DataRowUtility.GetDatabaseValue(testDate), typeof(DateTime));

			testDate = new DateTime(1752, 12, 31);
			Assert.AreEqual(DBNull.Value, DataRowUtility.GetDatabaseValue(testDate));

			string testString = string.Empty;
			Assert.AreEqual(DBNull.Value, DataRowUtility.GetDatabaseValue(testString));

			testString = null;
			Assert.AreEqual(DBNull.Value, DataRowUtility.GetDatabaseValue(testString));

			testString = "a";
			Assert.AreEqual("a", DataRowUtility.GetDatabaseValue(testString));

			int testInt = 0;
			Assert.AreEqual(0, DataRowUtility.GetDatabaseValue(testInt));

			testInt = 1;
			Assert.AreEqual(1, DataRowUtility.GetDatabaseValue(testInt));

			testInt = -1;
			Assert.AreEqual(-1, DataRowUtility.GetDatabaseValue(testInt));
		}

		[TestMethod]
		public void TestGetValue()
		{
			Assert.AreEqual(1, DataRowUtility.GetValue(this.GetTable().Rows[0], 0));
			Assert.AreEqual("PDF", DataRowUtility.GetValue(this.GetTable().Rows[0], 1));
			Assert.AreEqual("Adobe PDF", DataRowUtility.GetValue(this.GetTable().Rows[0], 2));

			Assert.AreEqual(2, DataRowUtility.GetValue(this.GetTable().Rows[1], "ID"));
			Assert.AreEqual("XML", DataRowUtility.GetValue(this.GetTable().Rows[1], "Code"));
			Assert.AreEqual("Excel", DataRowUtility.GetValue(this.GetTable().Rows[1], "Name"));
		}

		[TestMethod]
		public void TestGetValueAs()
		{
			Assert.AreEqual(1, DataRowUtility.GetValueAs<int>(this.GetTable().Rows[0], 0));
			Assert.AreEqual("PDF", DataRowUtility.GetValueAs<string>(this.GetTable().Rows[0], 1));
			Assert.AreEqual("Adobe PDF", DataRowUtility.GetValueAs<string>(this.GetTable().Rows[0], 2));

			Assert.AreEqual(2, DataRowUtility.GetValueAs<int>(this.GetTable().Rows[1], "ID"));
			Assert.AreEqual("XML", DataRowUtility.GetValueAs<string>(this.GetTable().Rows[1], "Code"));
			Assert.AreEqual("Excel", DataRowUtility.GetValueAs<string>(this.GetTable().Rows[1], "Name"));
		}

		[TestMethod]
		public void TestGetValueAsString()
		{
			Assert.AreEqual("1", DataRowUtility.GetValueAsString(this.GetTable().Rows[0], 0));
			Assert.AreEqual("PDF", DataRowUtility.GetValueAsString(this.GetTable().Rows[0], 1));
			Assert.AreEqual("Adobe PDF", DataRowUtility.GetValueAsString(this.GetTable().Rows[0], 2));

			Assert.AreEqual("2", DataRowUtility.GetValueAsString(this.GetTable().Rows[1], "ID"));
			Assert.AreEqual("XML", DataRowUtility.GetValueAsString(this.GetTable().Rows[1], "Code"));
			Assert.AreEqual("Excel", DataRowUtility.GetValueAsString(this.GetTable().Rows[1], "Name"));
		}

		#endregion
	}
}
