using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Collections
{
	[TestClass]
	public class TripletItemTest
	{
		#region " Tests "

		[TestMethod]
		public void ChangingValuesWorksOK()
		{
			//Arrange
			var item = new TripletItem<string, bool, int>("Test", true, 1);

			//Act
			item.Value1 = false;
			item.Value2 = 10;

			//Assert
			Assert.AreEqual(false, item.Value1);
			Assert.AreEqual(10, item.Value2);
		}

		[TestMethod]
		public void CreatingItemWorksOK()
		{
			//Arrange
			var item = default(TripletItem<string, bool, int>);

			//Act
			item = new TripletItem<string, bool, int>("Test", true, 1);

			//Assert
			Assert.AreEqual("Test", item.Key);
			Assert.AreEqual(true, item.Value1);
			Assert.AreEqual(1, item.Value2);
		}

		#endregion
	}
}
