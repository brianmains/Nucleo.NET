using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Text.Configuration
{
	[TestClass]
	public class MessagesSectionTest
	{
		[TestMethod]
		public void AssigningWorksOK()
		{
			//Arrange
			var section = new MessagesSection();

			//Act
			section.DefaultProvider = "Test";
			section.KeepOldMessages = true;

			//Assert
			Assert.AreEqual("Test", section.DefaultProvider);
			Assert.AreEqual(true, section.KeepOldMessages);
		}
	}
}
