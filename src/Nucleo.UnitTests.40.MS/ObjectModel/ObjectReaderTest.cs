using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.ObjectModel
{
	[TestClass]
	public class ObjectReaderTest
	{
		#region " Tests "

		[TestMethod]
		public void ReadingObjectWorksOK()
		{
			//Arrange
			var reader = new ObjectReader();

			//Act
			reader.ReadAttributes(new { Name = "Ted", Preference = "Music" });

			//Assert
			Assert.AreEqual(2, reader.Attributes.Count);
			Assert.AreEqual("Ted", reader.Attributes["Name"]);
			Assert.AreEqual("Music", reader.Attributes["Preference"]);
		}

		#endregion
	}
}
