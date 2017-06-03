using System;
using System.Net.Mail;


namespace Nucleo.Email
{
	public class FakeEmailProvider : EmailProvider
	{
		private MailMessage _sentMessage = null;



		#region " Properties "

		public MailMessage SentMessage
		{
			get { return _sentMessage; }
		}

		#endregion



		#region " Methods "

		public override void SendEmail(MailMessage message)
		{
			_sentMessage = message;
		}

		#endregion
	}
}
