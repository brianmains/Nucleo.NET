using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.DataMapper
{
	[TestClass]
	public class RangesValueTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingValueReturnsArray()
		{
			//Arrange
			var range = new RangesValue(2, 10, 1);

			//Act
			var value = range.GetValue() as object[];

			//Assert
			Assert.IsNotNull(value);
		}

		[TestMethod]
		public void GettingValuesWhenSteppingBy1FromRangeWorksOK()
		{
			//Arrange
			var range = new RangesValue(2, 10, 1);

			//Act
			var values = range.GetValues();

			//Assert
			Assert.AreEqual(9, values.Length);
			Assert.AreEqual(2L, values[0]);
			Assert.AreEqual(4L, values[2]);
			Assert.AreEqual(6L, values[4]);
			Assert.AreEqual(8L, values[6]);
			Assert.AreEqual(10L, values[8]);
		}

		[TestMethod]
		public void GettingValuesWhenSteppingBy2FromRangeWorksOK()
		{
			//Arrange
			var range = new RangesValue(2, 10, 2);

			//Act
			var values = range.GetValues();

			//Assert
			Assert.AreEqual(5, values.Length);
			Assert.AreEqual(2L, values[0]);
			Assert.AreEqual(4L, values[1]);
			Assert.AreEqual(6L, values[2]);
			Assert.AreEqual(8L, values[3]);
		}

		#endregion
	}
}
