using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.DataServices.Modules
{
	[TestClass]
	public class ModuleIdentifierCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingBulkItemsWOrksOK()
		{
			//Arrange
			var list = new ModuleIdentifierCollection();

			//Act
			list.AddRange(new[]
			{
				new ModuleIdentifier("A"),
				new ModuleIdentifier("B"),
				new ModuleIdentifier("C")
			});

			//Assert
			Assert.AreEqual(3, list.Count);
			Assert.AreEqual("A", list[0].Name);
			Assert.AreEqual("B", list[1].Name);
			Assert.AreEqual("C", list[2].Name);
		}

		#endregion
	}
}
