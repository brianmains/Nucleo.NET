using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Validation;


namespace Nucleo.Web.ValidationControls
{
	[TestClass]
	public class ValidationResultsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var results = new ValidationResults();

			//Act
			results.HeaderMessage = "M";

			//Assert
			Assert.AreEqual("M", results.HeaderMessage);
		}

		#endregion
	}
}
