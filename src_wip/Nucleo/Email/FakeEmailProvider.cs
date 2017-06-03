using System;
using System.Net.Mail;


namespace Nucleo.Email
{
	/// <summary>
	/// Represents the provider that is a fake, solely for unit testing.  All sent messages write the last message to a public property named <see cref="SentMessage"/>.
	/// </summary>
	public class FakeEmailProvider : EmailProvider
	{
		private MailMessage _sentMessage = null;



		#region " Properties "

		/// <summary>
		/// Gets the last sent message for testing purposes.
		/// </summary>
		public MailMessage SentMessage
		{
			get { return _sentMessage; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Writes the mesage to the local <see cref="SentMessage"/> property.
		/// </summary>
		/// <param name="message">The message to send.</param>
		public override void SendEmail(MailMessage message)
		{
			_sentMessage = message;
		}

		#endregion
	}
}
