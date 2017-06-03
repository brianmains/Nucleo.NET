using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Providers
{
	[TestClass]
	public class ProviderCollectionTest : ProviderCollection<ProviderBaseTest>
	{
		#region " Tests "

		[TestMethod]
		public void AddingItemsToListWorksOK()
		{
			//Arrange
			var collection = new ProviderCollectionTest();

			//Act
			collection.Add(new ProviderBaseTest { FriendlyName = "A" });
			collection.Add(new ProviderBaseTest { FriendlyName = "B" });

			//Assert
			Assert.AreEqual(2, collection.Count);
		}

		[TestMethod]
		public void CopyingItemsToArrayWorksOK()
		{
			//Arrange
			var collection = new ProviderCollectionTest();
			collection.Add(new ProviderBaseTest { FriendlyName = "A" });
			collection.Add(new ProviderBaseTest { FriendlyName = "B" });

			//Act
			ProviderBaseTest[] array = new ProviderBaseTest[2];
			collection.CopyTo(array, 0);

			//Assert
			Assert.AreEqual(2, array.Length);
		}

		#endregion
	}
}
