using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Logs;


namespace Nucleo.Email
{
	[TestClass]
	public class LoggerEmailProviderTest
	{
		[TestMethod]
		public void CreatingWithDefaultConstructorWorksOK()
		{
			new LoggerEmailProvider();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullOptionsThrowsExceptions()
		{
			new LoggerEmailProvider(null);
		}

		[TestMethod]
		public void CreatingWithValidOptionsWorksOK()
		{
			var options = Isolate.Fake.Instance<LoggerOptions>();

			new LoggerEmailProvider(options);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SendingMessageThroughLoggerUsesOptions()
		{
			var options = Isolate.Fake.Instance<LoggerOptions>();
			var logger = Isolate.Fake.Instance<Logger>();

			Isolate.Fake.StaticMethods<Logger>();
			Isolate.WhenCalled(() => Logger.Create(options)).WithExactArguments().WillReturn(logger);

			new LoggerEmailProvider(options).SendEmail(new MailMessage("from@from.com", "to@to.com", "Test Message", "Did you get this?"));

			Isolate.Verify.WasCalledWithExactArguments(() => Logger.Create(options));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SendingMessageThroughLoggerWorksOK()
		{
			var logger = Isolate.Fake.Instance<Logger>();

			Isolate.Fake.StaticMethods<Logger>();
			Isolate.WhenCalled(() => Logger.Create()).WillReturn(logger);

			new LoggerEmailProvider().SendEmail(new MailMessage("from@from.com", "to@to.com", "Test Message", "Did you get this?"));

			Isolate.Verify.WasCalledWithAnyArguments(() => logger.LogMessage(null, null, null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void SendingMessageThroughLoggerWithoutOptionsWorksOK()
		{
			var logger = Isolate.Fake.Instance<Logger>();

			Isolate.Fake.StaticMethods<Logger>();
			Isolate.WhenCalled(() => Logger.Create()).WithExactArguments().WillReturn(logger);

			new LoggerEmailProvider().SendEmail(new MailMessage("from@from.com", "to@to.com", "Test Message", "Did you get this?"));

			Isolate.Verify.WasCalledWithExactArguments(() => Logger.Create());
			Isolate.CleanUp();
		}
	}
}
