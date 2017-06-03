using System;
using System.Data;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Data
{
	[TestClass]
	public class DataTableUtilityTest
	{
		private DataTable _results = null;



		#region " Methods "

		private void CreateRow(int id, object name, object creationDate)
		{
			DataRow row = _results.NewRow();
			row["ID"] = id;
			row["Name"] = name;
			row["CreationDate"] = creationDate;
			_results.Rows.Add(row);
		}

		#endregion



		#region " Tests "

		[TestInitialize]
		public void Initialize()
		{
			_results = new DataTable();
			_results.Columns.Add("ID", typeof(int));
			_results.Columns.Add("Name", typeof(string));
			_results.Columns.Add("CreationDate", typeof(DateTime));

			this.CreateRow(1, "Brian Mains", new DateTime(2007, 1, 1));
			this.CreateRow(2, "Shelly Mains", new DateTime(2007, 1, 5));
			this.CreateRow(3, "Olivia Mains", DBNull.Value);
			this.CreateRow(4, "John Doe", new DateTime(2007, 2, 1));
			this.CreateRow(5, DBNull.Value, DateTime.Today);
		}

		[TestCleanup]
		public void TestGetColumnAsArrayOfWithIndex()
		{
			int[] ids = DataTableUtility.GetColumnAsArrayOf<int>(_results);
			Assert.IsNotNull(ids);
			Assert.AreEqual(5, ids.Length);
			Assert.AreEqual(1, ids[0]);
			Assert.AreEqual(2, ids[1]);
			Assert.AreEqual(3, ids[2]);
			Assert.AreEqual(4, ids[3]);
			Assert.AreEqual(5, ids[4]);

			string[] names = DataTableUtility.GetColumnAsArrayOf<string>(_results, 1);
			Assert.IsNotNull(names);
			Assert.AreEqual(5, names.Length);
			Assert.AreEqual("Brian Mains", names[0]);
			Assert.AreEqual("Shelly Mains", names[1]);
			Assert.AreEqual("Olivia Mains", names[2]);
			Assert.AreEqual("John Doe", names[3]);
			Assert.IsTrue(string.IsNullOrEmpty(names[4]));

			DateTime[] dates = DataTableUtility.GetColumnAsArrayOf<DateTime>(_results, 2);
			Assert.IsNotNull(dates);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 1, 1), dates[0]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 1, 5), dates[1]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(DateTime.MinValue, dates[2]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 2, 1), dates[3]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(DateTime.Today, dates[4]));

			names = DataTableUtility.GetColumnAsArrayOf<string>(_results, 1, false);
			Assert.IsNotNull(names);
			Assert.AreEqual(4, names.Length);

			dates = DataTableUtility.GetColumnAsArrayOf<DateTime>(_results, 2, false);
			Assert.IsNotNull(dates);
			Assert.AreEqual(4, dates.Length);
		}

		[TestMethod]
		public void TestGetColumnAsArrayOfWithName()
		{
			int[] ids = DataTableUtility.GetColumnAsArrayOf<int>(_results, "ID");
			Assert.IsNotNull(ids);
			Assert.AreEqual(5, ids.Length);
			Assert.AreEqual(1, ids[0]);
			Assert.AreEqual(2, ids[1]);
			Assert.AreEqual(3, ids[2]);
			Assert.AreEqual(4, ids[3]);
			Assert.AreEqual(5, ids[4]);

			string[] names = DataTableUtility.GetColumnAsArrayOf<string>(_results, "Name");
			Assert.IsNotNull(names);
			Assert.AreEqual(5, names.Length);
			Assert.AreEqual("Brian Mains", names[0]);
			Assert.AreEqual("Shelly Mains", names[1]);
			Assert.AreEqual("Olivia Mains", names[2]);
			Assert.AreEqual("John Doe", names[3]);
			Assert.IsTrue(string.IsNullOrEmpty(names[4]));

			DateTime[] dates = DataTableUtility.GetColumnAsArrayOf<DateTime>(_results, "CreationDate");
			Assert.IsNotNull(dates);
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 1, 1), dates[0]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 1, 5), dates[1]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(DateTime.MinValue, dates[2]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(new DateTime(2007, 2, 1), dates[3]));
			Assert.IsTrue(DateTimeEquality.GeneralEquals(DateTime.Today, dates[4]));

			names = DataTableUtility.GetColumnAsArrayOf<string>(_results, "Name", false);
			Assert.IsNotNull(names);
			Assert.AreEqual(4, names.Length);

			dates = DataTableUtility.GetColumnAsArrayOf<DateTime>(_results, "CreationDate", false);
			Assert.IsNotNull(dates);
			Assert.AreEqual(4, dates.Length);
		}

		#endregion
	}
}