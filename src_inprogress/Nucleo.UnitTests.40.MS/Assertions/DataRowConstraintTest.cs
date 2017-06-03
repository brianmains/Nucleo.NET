using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;


namespace Nucleo.Assertions
{
	[TestClass]
	public class DataRowConstraintTest
	{
		private DataRowConstraint _constraint = null;
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
		public void TestMatching()
		{
			_constraint = new DataRowConstraint("Name", true);
			Assert.IsTrue(_constraint.Matches(_dataSource.Rows[0]));

			_constraint = new DataRowConstraint("Name", false);
			Assert.IsFalse(_constraint.Matches(_dataSource.Rows[0]));

			_constraint = new DataRowConstraint(1, true);
			Assert.IsTrue(_constraint.Matches(_dataSource.Rows[0]));

			_constraint = new DataRowConstraint(1, false);
			Assert.IsFalse(_constraint.Matches(_dataSource.Rows[0]));

			_constraint = new DataRowConstraint();
			Assert.IsTrue(_constraint.Matches(_dataSource.Rows[0]));
		}

		#endregion
	}
}