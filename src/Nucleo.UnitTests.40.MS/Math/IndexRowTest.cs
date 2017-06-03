using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Math
{
	[TestClass]
	public class IndexRowTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingRowWorksSuccessfully()
		{
			IndexRow row = new IndexRow();
			Assert.AreEqual(0, row.Values.Count);

			row = new IndexRow(9);
			Assert.AreEqual(1, row.Values.Count);
			Assert.AreEqual(9, row.Values[0]);

			row = new IndexRow(1, 3, 5, 7, 9, 11);
			Assert.AreEqual(6, row.Values.Count);
			Assert.AreEqual(5, row.Values[2]);
			Assert.AreEqual(11, row.Values[5]);
		}

		#endregion
	}
}