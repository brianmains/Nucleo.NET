using System;
using System.Net.Mail;
using System.Collections.Generic;

using Nucleo.Email.Configuration;
using Nucleo.Collections;


namespace Nucleo.Email
{
	public static class Emailer
	{
		private static EmailProvider _provider = null;
		static object _lock = new object();



		#region " Properties "

		/// <summary>
		/// Gets a reference to the provider that is setup to send email.
		/// </summary>
		private static EmailProvider DefaultProvider
		{
			get
			{
				if (_provider != null)
					return _provider;


				lock (_lock)
				{
					if (_provider == null)
					{
						if (EmailSection.Instance != null && !string.IsNullOrEmpty(EmailSection.Instance.DefaultProviderType))
						{
							Type providerType = Type.GetType(EmailSection.Instance.DefaultProviderType);
							_provider = (EmailProvider)Activator.CreateInstance(providerType);
						}
						else
							throw new NullReferenceException("The email provider has not been instantiated");
					}
				}

				return _provider;
			}
		}

		#endregion




		#region " Methods "

		/// <summary>
		/// Sends an email message to multiple recipients.
		/// </summary>
		/// <param name="to">The collection of recipients to email.</param>
		/// <param name="message">The textual (non-HTML) message to send.</param>
		public static void SendEmail(IEnumerable<string> to, string subject, string message)
		{
			SendEmail(to, subject, message, false);
		}

		/// <summary>
		/// Sends an email message to one recipient.
		/// </summary>
		/// <param name="to">The recipient to email.</param>
		/// <param name="message">The textual (non-HTML) message to send.</param>
		public static void SendEmail(StringCollection to, string subject, string message)
		{
			SendEmail(to, subject, message, false);
		}

		/// <summary>
		/// Sends an email message to mulitple recipients.
		/// </summary>
		/// <param name="to">The collection of recipients to email.</param>
		/// <param name="message">The message to send.</param>
		/// <param name="isHtml">Whether to send a message using HTML.</param>
		public static void SendEmail(IEnumerable<string> to, string subject, string message, bool isHtml)
		{
			SendEmail(new StringCollection(to), subject, message, isHtml);
		}

		/// <summary>
		/// Sends an email message to one recipient.
		/// </summary>
		/// <param name="to">The recipient to email.</param>
		/// <param name="message">The message to send.</param>
		/// <param name="isHtml">Whether to send a message using HTML.</param>
		public static void SendEmail(StringCollection to, string subject, string message, bool isHtml)
		{
			MailMessage mailMessage = new MailMessage();

			mailMessage.To.Add(to.ToCommaSeparatedList());
			mailMessage.Body = message;
			mailMessage.IsBodyHtml = isHtml;
			mailMessage.Subject = subject;
			SendEmail(mailMessage);
		}

		/// <summary>
		/// Sends an email message using the parameters defined in the MailMessage object.
		/// </summary>
		/// <param name="message">The message to send.</param>
		public static void SendEmail(MailMessage message)
		{
			DefaultProvider.SendEmail(message);
		}

		#endregion
	}
}