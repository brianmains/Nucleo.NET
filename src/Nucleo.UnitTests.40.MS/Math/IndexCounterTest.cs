using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Math
{
	[TestClass]
	public class IndexCounterTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingHorizontalRepeatableSequencesWorksCorrectly1()
		{
			var rows = IndexCounter.CreateRepeatableIndexes(5, 25, 3, IndexRepeatDirection.Horizontal);
			Assert.AreEqual(7, rows.Count);
			Assert.AreEqual(3, rows[6].Values.Count);

			Assert.AreEqual(5, rows[0].Values[0]);
			Assert.AreEqual(7, rows[0].Values[2]);
			Assert.AreEqual(11, rows[2].Values[0]);
			Assert.AreEqual(13, rows[2].Values[2]);
			Assert.AreEqual(23, rows[6].Values[0]);
			Assert.AreEqual(25, rows[6].Values[2]);
		}

		[TestMethod]
		public void GettingHorizontalRepeatableSequencesWorksCorrectly2()
		{
			var rows = IndexCounter.CreateRepeatableIndexes(1, 10, 5, IndexRepeatDirection.Horizontal);
			Assert.AreEqual(2, rows.Count);
			Assert.AreEqual(1, rows[0].Values[0]);
			Assert.AreEqual(3, rows[0].Values[2]);
			Assert.AreEqual(5, rows[0].Values[4]);
			Assert.AreEqual(6, rows[1].Values[0]);
			Assert.AreEqual(8, rows[1].Values[2]);
			Assert.AreEqual(10, rows[1].Values[4]);
		}

		[TestMethod]
		public void GettingVerticalRepeatableSequencesWorksCorrectly()
		{
			var rows = IndexCounter.CreateRepeatableIndexes(1, 10, 2, IndexRepeatDirection.Vertical);
			Assert.AreEqual(5, rows.Count);
			Assert.AreEqual(1, rows[0].Values[0]);
			Assert.AreEqual(6, rows[0].Values[1]);
			Assert.AreEqual(3, rows[2].Values[0]);
			Assert.AreEqual(8, rows[2].Values[1]);
			Assert.AreEqual(5, rows[4].Values[0]);
			Assert.AreEqual(10, rows[4].Values[1]);
		}

		#endregion
	}
}