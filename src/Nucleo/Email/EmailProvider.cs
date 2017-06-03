using System;
using System.Net.Mail;


namespace Nucleo.Email
{
	public abstract class EmailProvider
	{
		public abstract void SendEmail(MailMessage message);
	}
}
