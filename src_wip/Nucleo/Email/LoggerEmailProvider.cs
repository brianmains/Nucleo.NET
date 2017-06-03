using System;
using System.Net.Mail;

using Nucleo.Logs;


namespace Nucleo.Email
{
	/// <summary>
	/// Represents the email provider using the <see cref="Logger"/> interface.
	/// </summary>
	public class LoggerEmailProvider : EmailProvider
	{
		private LoggerOptions _options = null;



		/// <summary>
		/// Creates the email provider with no options.
		/// </summary>
		public LoggerEmailProvider() { }

		/// <summary>
		/// Creates the email provider with a valid set of options.
		/// </summary>
		/// <param name="options">The options to use.</param>
		public LoggerEmailProvider(LoggerOptions options)
		{
			Guard.NotNull(options);

			_options = options;
		}



		/// <summary>
		/// Sends the email message.
		/// </summary>
		/// <param name="message">The message to send.</param>
		public override void SendEmail(MailMessage message)
		{
			var logger = (_options != null)
				? Logger.Create(_options)
				: Logger.Create();

			logger.LogMessage(string.Format(@"From: {0}\r\n
					To: {1}\r\n
					Subject: {2}\r\n
					Message: {3}",
						message.From.ToString(), message.To.ToString(),
						message.Subject, message.Body), "Email",
						LogMessageTypes.Default.GetLowest(),
						LogVerbosityTypes.Default.GetLowest());
		}
	}
}
