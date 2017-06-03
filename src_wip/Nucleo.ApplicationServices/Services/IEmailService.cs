using System;
using System.Collections.Generic;
using System.Net.Mail;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents the interface used for sending emails.
	/// </summary>
	/// <example>
	/// var context = ApplicationContext.GetCurrent();
	/// var obj = context.GetService&lt;IEmailService>();
	/// //Use object
	/// </example>
	public interface IEmailService
	{
		/// <summary>
		/// Sends an email message to multiple recipients.
		/// </summary>
		/// <param name="to">The collection of recipients to email.</param>
		/// <param name="message">The message to send.</param>
		void SendEmail(IEnumerable<string> to, string subject, string message);

		/// <summary>
		/// Sends an email message to mulitple recipients.
		/// </summary>
		/// <param name="to">The collection of recipients to email.</param>
		/// <param name="message">The message to send.</param>
		/// <param name="isHtml">Whether to send a message using HTML.</param>
		void SendEmail(IEnumerable<string> to, string subject, string message, bool isHtml);

		/// <summary>
		/// Sends an email message using the parameters defined in the MailMessage object.
		/// </summary>
		/// <param name="message">The message to send.</param>
		void SendEmail(MailMessage message);
	}
}
