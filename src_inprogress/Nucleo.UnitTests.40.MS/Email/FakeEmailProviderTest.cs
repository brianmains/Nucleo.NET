using System;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Email
{
	[TestClass]
	public class FakeEmailProviderTest
	{
		#region " Tests "

		[TestMethod]
		public void SendingFakeEmailMarksEmailSent()
		{
			//Arrange
			var provider = new FakeEmailProvider();
			var mailMessage = new MailMessage("a@test.com", "b@test.com", "Test", "Body");
			
			//Act
			provider.SendEmail(mailMessage);

			//Assert
			Assert.AreEqual(mailMessage, provider.SentMessage);
		}

		#endregion
	}
}
