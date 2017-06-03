using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Email;


namespace Nucleo.Services
{
	[TestClass]
	public class EmailServiceTest
	{
		#region " Tests "

		[TestMethod]
		public void SendingMessageWithMessageObjectWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(Emailer));
			Isolate.WhenCalled(() => Emailer.SendEmail(default(MailMessage))).IgnoreCall();

			//Act
			var service = new EmailService();
			service.SendEmail(new MailMessage("a@a.com", "b@b.com", "Test", "Test"));

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => Emailer.SendEmail(default(MailMessage)));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SendingMessageWithSubjectMessageHtmlWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(Emailer));
			Isolate.WhenCalled(() => Emailer.SendEmail(default(IEnumerable<string>), null, null, true)).IgnoreCall();

			//Act
			var service = new EmailService();
			service.SendEmail(new string[] { "a@a.com", "b@b.com" }, "Test", "Test Message", true);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => Emailer.SendEmail(default(IEnumerable<string>), null, null, true));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SendingMessageWithSubjectMessageWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(Emailer));
			Isolate.WhenCalled(() => Emailer.SendEmail(default(IEnumerable<string>), null, null)).IgnoreCall();

			//Act
			var service = new EmailService();
			service.SendEmail(new string[] { "a@a.com", "b@b.com" }, "Test", "Test Message");

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => Emailer.SendEmail(default(IEnumerable<string>), null, null));

			Isolate.CleanUp();
		}

		#endregion
	}
}
