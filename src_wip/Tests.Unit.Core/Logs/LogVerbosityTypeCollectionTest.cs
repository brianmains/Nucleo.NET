using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Logs
{
	[TestClass]
	public class LogVerbosityTypeCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingCommonVerbositiesUsingEnumReturnsCorrectReference()
		{
			//Arrange
			var collection = new LogVerbosityTypeCollection();
			collection.Add(new LogVerbosityType("Minimal", 0));
			collection.Add(new LogVerbosityType("Normal", 127));
			collection.Add(new LogVerbosityType("Verbose", 255));

			//Act
			var minEntry = collection.GetByEnum(CommonLogVerbosityTypes.Minimal);
			var normEntry = collection.GetByEnum(CommonLogVerbosityTypes.Normal);
			var verbEntry = collection.GetByEnum(CommonLogVerbosityTypes.Verbose);

			//Assert
			Assert.AreEqual("Minimal", minEntry.Name);
			Assert.AreEqual("Normal", normEntry.Name);
			Assert.AreEqual("Verbose", verbEntry.Name);
		}

		[TestMethod]
		public void GettingVerbosityByInvalidNameReturnsNull()
		{
			var collection = new LogVerbosityTypeCollection();
			collection.Add(new LogVerbosityType("First", 1));
			collection.Add(new LogVerbosityType("Second", 2));
			collection.Add(new LogVerbosityType("Third", 3));
			collection.Add(new LogVerbosityType("Fourth", 4));

			Assert.AreEqual(null, collection["Fifth"]);
			Assert.AreEqual(null, collection["Firs"]);
			Assert.AreEqual(null, collection["Zero"]);
		}

		[TestMethod]
		public void GettingVerbosityByNameReturnsCorrectValue()
		{
			var collection = new LogVerbosityTypeCollection();
			collection.Add(new LogVerbosityType("First", 1));
			collection.Add(new LogVerbosityType("Second", 2));
			collection.Add(new LogVerbosityType("Third", 3));
			collection.Add(new LogVerbosityType("Fourth", 4));

			Assert.AreEqual(1, collection["First"].Level);
			Assert.AreEqual(4, collection["Fourth"].Level);
			Assert.AreEqual(2, collection["SeCoNd"].Level);
			Assert.AreEqual(3, collection["third"].Level);
		}

		#endregion
	}
}
