using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Assertions
{
	[TestClass]
	public class DataTableAssertTest
	{
		private DataTable _dataSource = null;



		#region " Methods "

		private void CreateDataSource()
		{
			_dataSource = new DataTable();
			_dataSource.Columns.Add("Name", typeof(string));
			_dataSource.Columns.Add("Hobby", typeof(string));
			_dataSource.Columns.Add("FavoriteColor", typeof(string));
		}

		private void CreateDataSourceRow(object name, object hobby, object favoriteColor)
		{
			DataRow row = _dataSource.NewRow();
			row["Name"] = name;
			row["Hobby"] = hobby;
			row["FavoriteColor"] = favoriteColor;
			_dataSource.Rows.Add(row);
		}

		#endregion



		#region " Tests "

		[TestFixtureSetUp]
		public void Initialize()
		{
			this.CreateDataSource();
			this.CreateDataSourceRow("Brian", "Cars", "Blue");
			this.CreateDataSourceRow("Shelly", "Sign Language", "Purple");
			this.CreateDataSourceRow("Jamie", "Coding", "Blue");
			this.CreateDataSourceRow("Archie", "Eating", "Red");
			this.CreateDataSourceRow("David", "Harp Playing", "White");
			this.CreateDataSourceRow("Sidney", "Movies", DBNull.Value);
			this.CreateDataSourceRow("Eddie", "Photography", DBNull.Value);
		}

		[Test]
		public void TestNullAssertions()
		{
			DataTableAssert.ColumnIsNotNull(_dataSource, "Name");
			DataTableAssert.ColumnIsNotNull(_dataSource, 1);
		}

		[Test, Sequential]
		public void EnsureContainsRowThatWorksCorrectly()
		{
			DataTableAssert.ContainsRowThat(_dataSource, 0, Is.EqualTo("David"));
			DataTableAssert.ContainsRowThat(_dataSource, "Name", Is.EqualTo("Sidney"));
			DataTableAssert.ContainsRowThat(_dataSource, 1, Is.EqualTo("Coding"));
			DataTableAssert.ContainsRowThat(_dataSource, "Hobby", Is.EqualTo("Harp Playing"));
			DataTableAssert.ContainsRowThat(_dataSource, 2, Is.EqualTo("Red"));
			DataTableAssert.ContainsRowThat(_dataSource, "FavoriteColor", Is.EqualTo("Purple"));
		}

		#endregion
	}
}