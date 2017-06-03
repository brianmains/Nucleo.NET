using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Formatting
{
	[TestClass]
	public class DefaultFormPostKeyFormatterTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingNullIDFormatsOK()
		{
			//Arrange
			var format = new DefaultFormPostKeyFormatter();

			//Act
			var id = format.GetId("TestID");

			//Assert
			Assert.AreEqual("TestID", id);
		}

		[TestMethod]
		public void GettingValidIDFormatsOK()
		{
			//Arrange
			var format = new DefaultFormPostKeyFormatter();

			//Act
			var id = format.GetId("TestID");

			//Assert
			Assert.AreEqual("TestID", id);
		}

		#endregion
	}
}
