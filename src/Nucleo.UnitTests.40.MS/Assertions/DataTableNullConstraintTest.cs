using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;

using Nucleo.TestingTools;


namespace Nucleo.Assertions
{
	[TestClass]
	public class DataTableNullConstraintTest
	{
		private DataTableNullConstraint _constraint = null;
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
		public void TestMatching()
		{
			_constraint = new DataTableNullConstraint("Name", true);
			Assert.IsTrue(_constraint.Matches(_dataSource));

			_constraint = new DataTableNullConstraint("Hobby", true);
			Assert.IsTrue(_constraint.Matches(_dataSource));

			DataTable copy = _dataSource.Copy();
			foreach (DataRow row in copy.Rows)
			{
				row.BeginEdit();
				row["FavoriteColor"] = DBNull.Value;
				row.EndEdit();
			}

			_constraint = new DataTableNullConstraint(2, false);
			Assert.IsFalse(_constraint.Matches(_dataSource));
		}

		[Test]
		public void TestMatchingFailure()
		{
			try
			{
				_constraint = new DataTableNullConstraint("FavoriteColor", true);
				Assert.That(_dataSource, _constraint);
			}
			catch (AssertionException aex) { return; }

			Assert.Fail();
		}

		#endregion
	}
}