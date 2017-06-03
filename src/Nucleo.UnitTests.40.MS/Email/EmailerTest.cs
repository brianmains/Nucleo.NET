using System;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.Email.Configuration;


namespace Nucleo.Email
{
	[TestClass]
	public class EmailerTest
	{
		#region " Tests "

		[TestMethod]
		public void SendingEmailAsMailMessageSendsMessage()
		{
			//Arrange
			var provider = new FakeEmailProvider();

			Isolate.Fake.StaticMethods(typeof(Emailer), Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(typeof(Emailer), "DefaultProvider").WillReturn(provider);

			var mailMessage = new MailMessage("a@test.com", "b@test.com", "Sub", "Bod");
			mailMessage.BodyEncoding = new System.Text.UTF32Encoding();

			//Act
			Emailer.SendEmail(mailMessage);

			//Assert
			Assert.AreEqual("a@test.com", provider.SentMessage.From.Address);
			Assert.AreEqual("b@test.com", provider.SentMessage.To[0].Address);
			Assert.AreEqual("Sub", provider.SentMessage.Subject);
			Assert.AreEqual("Bod", provider.SentMessage.Body);
			Assert.IsInstanceOfType(provider.SentMessage.BodyEncoding, typeof(System.Text.UTF32Encoding));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SendingEmailWithToCollectionAndMessageSendsMessage()
		{
			//Arrange
			var provider = new FakeEmailProvider();

			Isolate.Fake.StaticMethods(typeof(Emailer), Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(typeof(Emailer), "DefaultProvider").WillReturn(provider);

			//Act
			Emailer.SendEmail(new StringCollection { "f1@test.com", "f2@test.com", "f3@test.com" }, "My Subject", "My message");

			//Assert
			Assert.AreEqual(3, provider.SentMessage.To.Count, "To count isn't 3");
			Assert.AreEqual("My Subject", provider.SentMessage.Subject, "Subject isn't correct");
			Assert.AreEqual("My message", provider.SentMessage.Body, "Body isn't correct");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SendingEmailWithToListAndMessageSendsMessage()
		{
			//Arrange
			var provider = new FakeEmailProvider();

			Isolate.Fake.StaticMethods(typeof(Emailer), Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(typeof(Emailer), "DefaultProvider").WillReturn(provider);

			//Act
			Emailer.SendEmail(new string[] { "f1@test.com", "f2@test.com", "f3@test.com" }, "My Subject", "My message");

			//Assert
			Assert.AreEqual(3, provider.SentMessage.To.Count, "To count isn't 3");
			Assert.AreEqual("My Subject", provider.SentMessage.Subject, "Subject isn't correct");
			Assert.AreEqual("My message", provider.SentMessage.Body, "Body isn't correct");

			Isolate.CleanUp();
		}

		public void SendingEmailWithToCollectionIsHtmlAndMessageSendsMessage()
		{
			//Arrange
			var provider = new FakeEmailProvider();

			Isolate.Fake.StaticMethods(typeof(Emailer), Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(typeof(Emailer), "DefaultProvider").WillReturn(provider);

			//Act
			Emailer.SendEmail(new StringCollection { "f1@test.com", "f2@test.com", "f3@test.com" }, "My Subject", "My message", true);

			//Assert
			Assert.AreEqual(3, provider.SentMessage.To.Count, "To count isn't 3");
			Assert.AreEqual("My Subject", provider.SentMessage.Subject, "Subject isn't correct");
			Assert.AreEqual("My message", provider.SentMessage.Body, "Body isn't correct");
			Assert.AreEqual(true, provider.SentMessage.IsBodyHtml, "Body isn't html");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SendingEmailWithToListIsHtmlAndMessageSendsMessage()
		{
			//Arrange
			var provider = new FakeEmailProvider();

			Isolate.Fake.StaticMethods(typeof(Emailer), Members.CallOriginal);
			Isolate.NonPublic.Property.WhenGetCalled(typeof(Emailer), "DefaultProvider").WillReturn(provider);

			//Act
			Emailer.SendEmail(new string[] { "f1@test.com", "f2@test.com", "f3@test.com" }, "My Subject", "My message", true);

			//Assert
			Assert.AreEqual(3, provider.SentMessage.To.Count, "To count isn't 3");
			Assert.AreEqual("My Subject", provider.SentMessage.Subject, "Subject isn't correct");
			Assert.AreEqual("My message", provider.SentMessage.Body, "Body isn't correct");
			Assert.AreEqual(true, provider.SentMessage.IsBodyHtml, "Body isn't html");

			Isolate.CleanUp();
		}

		#endregion
	}
}
