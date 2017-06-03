using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Configuration;


namespace Nucleo.Text.Configuration
{
	[TestClass]
	public class StaticMessagesSectionTest
	{
		#region " Tests "

		[TestMethod]
		public void StoringMessagesWorksOK()
		{
			//Arrange
			var section = new StaticMessagesSection();

			//Act
			section.Messages.Add(new NameValueConfigurationElement("Test", "Value"));

			//Assert
			Assert.AreEqual(1, section.Messages.Count);
			Assert.AreEqual("Value", section.Messages["Test"].Value);
		}

		#endregion
	}
}
