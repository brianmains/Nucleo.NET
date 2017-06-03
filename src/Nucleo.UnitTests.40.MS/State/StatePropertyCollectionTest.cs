using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.State
{
	[TestClass]
	public class StatePropertyCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void AccessingPropertiesByNameReturnsCorrectReference()
		{
			StatePropertyCollection collection = new StatePropertyCollection();
			collection.Add(new StateProperty("Test", "Test"));
			collection.Add(new StateProperty("ColorScheme", "Blue"));
			collection.Add(new StateProperty("Region", "Northern"));

			Assert.IsNotNull(collection["Test"]);
			Assert.IsNotNull(collection["Region"]);

			Assert.IsNull(collection["First"]);
			Assert.IsNull(collection["ColorScheme2"]);
			
		}

		#endregion
	}
}
