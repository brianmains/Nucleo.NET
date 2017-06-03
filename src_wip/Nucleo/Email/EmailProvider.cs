using System;
using System.Net.Mail;


namespace Nucleo.Email
{
	/// <summary>
	/// Represents the base class for the email provider, which is responsible for sending a mail message through some medium.
	/// </summary>
	public abstract class EmailProvider
	{
		/// <summary>
		/// Sends the email to a recipient(s).
		/// </summary>
		/// <param name="message">The message to send.</param>
		public abstract void SendEmail(MailMessage message);
	}
}
