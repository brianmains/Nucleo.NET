using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Email
{
	[TestClass]
	public class EventLogEmailProviderTest
	{
		[TestMethod]
		public void SendingEmailThroughEventLogCallsOK()
		{
			Isolate.Fake.StaticMethods(typeof(EventLog));

			new EventLogEmailProvider().SendEmail(
				new MailMessage("from@from.com", "to@to.com", "Test Message", "Did you get this?"));

			Isolate.Verify.WasCalledWithAnyArguments(() => EventLog.WriteEntry(null, null));
		}
	}
}
