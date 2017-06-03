using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Logs
{
	[TestClass]
	public class LogMessageTypeCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingCommonMessageTypesUsingEnumReturnsCorrectReference()
		{
			//Arrange
			var collection = new LogMessageTypeCollection();
			collection.Add(new LogMessageType("Information", 0));
			collection.Add(new LogMessageType("Warning", 127));
			collection.Add(new LogMessageType("Error", 255));

			//Act
			var infoEntry = collection.GetByEnum(CommonLogMessageTypes.Information);
			var warnEntry = collection.GetByEnum(CommonLogMessageTypes.Warning);
			var errEntry = collection.GetByEnum(CommonLogMessageTypes.Error);

			//Assert
			Assert.AreEqual("Information", infoEntry.Name);
			Assert.AreEqual("Warning", warnEntry.Name);
			Assert.AreEqual("Error", errEntry.Name);
		}

		[TestMethod]
		public void GettingMessageTypeByInvalidNameReturnsNull()
		{
			//Arrange
			var collection = new LogMessageTypeCollection();
			
			//Act
			collection.Add(new LogMessageType("First", 1));
			collection.Add(new LogMessageType("Second", 2));
			collection.Add(new LogMessageType("Third", 3));
			collection.Add(new LogMessageType("Fourth", 4));

			//Assert
			Assert.AreEqual(null, collection["Fifth"]);
			Assert.AreEqual(null, collection["Firs"]);
			Assert.AreEqual(null, collection["Zero"]);
		}

		[TestMethod]
		public void GettingMessageTypeByNameReturnsCorrectValue()
		{
			//Arrange
			var collection = new LogMessageTypeCollection();

			//Act
			collection.Add(new LogMessageType("First", 1));
			collection.Add(new LogMessageType("Second", 2));
			collection.Add(new LogMessageType("Third", 3));
			collection.Add(new LogMessageType("Fourth", 4));

			//Assert
			Assert.AreEqual(1, collection["First"].Value);
			Assert.AreEqual(4, collection["Fourth"].Value);
			Assert.AreEqual(2, collection["SeCoNd"].Value);
			Assert.AreEqual(3, collection["third"].Value);
		}

		#endregion
	}
}
