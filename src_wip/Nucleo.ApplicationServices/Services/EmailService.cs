using System;
using System.Collections.Generic;
using System.Net.Mail;

using Nucleo.Email;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents a service used to send emails.
	/// </summary>
	public class EmailService : IEmailService
	{
		#region " Methods "

		/// <summary>
		/// Sends an email to a specified number of recipients.  Uses the <see cref="Emailer">Emailer helper object</see> to do the work.
		/// </summary>
		/// <param name="to">The recipients of the email.</param>
		/// <param name="subject">The subject of the email.</param>
		/// <param name="message">The message of the email.</param>
		public void SendEmail(IEnumerable<string> to, string subject, string message)
		{
			Emailer.SendEmail(to, subject, message);
		}

		/// <summary>
		/// Sends an email to a specified number of recipients.  Uses the <see cref="Emailer">Emailer helper object</see> to do the work.
		/// </summary>
		/// <param name="to">The recipients of the email.</param>
		/// <param name="subject">The subject of the email.</param>
		/// <param name="message">The message of the email.</param>
		/// <param name="isHtml">Whether the email contains HTML.</param>
		public void SendEmail(IEnumerable<string> to, string subject, string message, bool isHtml)
		{
			Emailer.SendEmail(to, subject, message, isHtml);
		}

		/// <summary>
		/// Sends an email to a specified number of recipients.  Uses the <see cref="Emailer">Emailer helper object</see> to do the work.
		/// </summary>
		/// <param name="message">The mail message information of the actual message.  Use this for direct access to all message available options (such as attachments, etc.).</param>
		public void SendEmail(MailMessage message)
		{
			Emailer.SendEmail(message);
		}

		#endregion
	}
}
