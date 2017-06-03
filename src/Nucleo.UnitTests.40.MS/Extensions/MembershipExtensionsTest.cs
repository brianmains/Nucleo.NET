using System;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class MembershipExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingMessageForInvalidEmailReturnsCorrectMessage()
		{
			//Arrange
			var status = MembershipCreateStatus.InvalidEmail;

			//Act
			var message = status.GetFriendlyMessage();

			//Assert
			Assert.AreEqual("The email address provided is not valid.", message);
		}

		[TestMethod]
		public void GettingMessageForInvalidUserNameReturnsCorrectMessage()
		{
			//Arrange
			var status = MembershipCreateStatus.InvalidUserName;

			//Act
			var message = status.GetFriendlyMessage();

			//Assert
			Assert.AreEqual("The user name provided is not valid.", message);
		}

		[TestMethod]
		public void GettingMessageForOtherCodesReturnsCorrectMessage()
		{
			//Arrange
			var status = MembershipCreateStatus.DuplicateProviderUserKey;

			//Act
			var message = status.GetFriendlyMessage();

			//Assert
			Assert.AreEqual("An error occurred when trying to create the user account.  Please review your information, and try again.", message);
		}

		[TestMethod]
		public void GettingMessageForSuccessReturnsCorrectMessage()
		{
			//Arrange
			var status = MembershipCreateStatus.Success;

			//Act
			var message = status.GetFriendlyMessage();

			//Assert
			Assert.AreEqual("The user was created successfully.", message);
		}

		#endregion
	}
}
