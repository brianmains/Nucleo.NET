using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;
using Nucleo.Web;


namespace Nucleo.Web.Description
{
	[TestClass]
	public class ComponentDescriptionRequestDetailsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingRequestDetailsWithNullsThrowsException()
		{
			//Arrange

			//Act
			
			//Assert
			ExceptionTester.CheckException(true, (src) => { new ComponentDescriptionRequestDetails(null); });
			ExceptionTester.CheckException(true, (src) => { new ComponentDescriptionRequestDetails(string.Empty); });
		}

		[TestMethod]
		public void CreatingRequestDetailsWorksOK()
		{
			//Arrange

			//Act
			var details = new ComponentDescriptionRequestDetails("abc");

			//Assert
			Assert.AreEqual("abc", details.ClientTypeName);
		}

		#endregion
	}
}
