using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Collections;


namespace Nucleo.DataServices.Modules
{
	[TestClass]
	public class DataServiceModuleCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingRangeOfItemsAddsToList()
		{
			//Arrange
			var coll = new DataServiceModuleCollection();

			//Act
			coll.AddRange(new[]
			{
				FakeDataServiceModule.Create("Success"),
				FakeDataServiceModule.Create("Failed"),
				FakeDataServiceModule.Create("OK")
			});

			//Assert
			Assert.AreEqual(3, coll.Count);
			Assert.IsTrue(coll.IsNotNull(i => i), "One item was null");
		}

		#endregion
	}
}
