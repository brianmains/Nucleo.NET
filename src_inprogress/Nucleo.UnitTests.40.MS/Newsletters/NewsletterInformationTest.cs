using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Newsletters
{
	[TestClass]
	public class NewsletterInformationTest
	{
		#region " Tests "

		[TestMethod]
		public void InformationInCtorAssignsOK()
		{
			//Arrange
			var info = default(NewsletterInformation);

			//Act
			info = new NewsletterInformation("Test Name", "Test Description");

			//Assert
			Assert.AreEqual("Test Name", info.Name);
			Assert.AreEqual("Test Description", info.Description);
		}

		#endregion
	}
}
