using System;
using System.Net.Mail;


namespace Nucleo.Email
{
	/// <summary>
	/// The provider that sends the email through the SMTP client.  No specific settings are established here; instead, it is highly recommended to establish the settings within the configuration file.
	/// </summary>
	public class SmtpEmailProvider : EmailProvider
	{
		/// <summary>
		/// Sends a mail message to the target recipient, and using the settings defined in the system.net namespace.
		/// </summary>
		/// <param name="message">The message to send.</param>
		public override void SendEmail(MailMessage message)
		{
			SmtpClient client = new SmtpClient();
			client.Send(message);
		}
	}
}
