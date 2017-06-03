using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Net.Mail;


namespace Nucleo.Email
{
	/// <summary>
	/// Represents the email provider that writes the email to the event log.  This is typically used for testing purposes.
	/// </summary>
	public class EventLogEmailProvider : EmailProvider
	{
		/// <summary>
		/// Sends the email to a recipient(s).
		/// </summary>
		/// <param name="message">The message to send.</param>
		public override void SendEmail(MailMessage message)
		{
			EventLog.WriteEntry("Application",
				string.Format(@"From: {0}\r\n
					To: {1}\r\n
					Subject: {2}\r\n
					Message: {3}",
						message.From.ToString(), message.To.ToString(),
						message.Subject, message.Body));

		}		
	}
}
