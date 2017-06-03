using System;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Email
{
	[TestClass]
	public class SmtpEmailProviderTest
	{
		#region " Tests "

		[TestMethod]
		public void SendingMessagesWorksCorrectly()
		{
			//Arrange
			var clientFake = Isolate.Fake.Instance<SmtpClient>();
			Isolate.Swap.NextInstance<SmtpClient>().With(clientFake);
			Isolate.WhenCalled(() => clientFake.Host).WillReturn("test.com");
			Isolate.WhenCalled(() => clientFake.Port).WillReturn(25);
			Isolate.WhenCalled(() => clientFake.UseDefaultCredentials).WillReturn(true);
			Isolate.WhenCalled(() => clientFake.Send(null)).IgnoreCall();

			var emailProviderFake = Isolate.Fake.Instance<SmtpEmailProvider>(Members.CallOriginal);
			var mailMessage = new MailMessage("a@test.com", "b@test.com", "Test subject", "Test body");
		
			//Act
			emailProviderFake.SendEmail(mailMessage);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => clientFake.Send(null));
		}

		#endregion
	}
}
