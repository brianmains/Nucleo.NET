using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Logs
{
	public class GeneralMessage : LogMessage
	{
		private string _message = null;



		#region " Properties "

		public string Message
		{
			get { return _message; }
			set { _message = value; }
		}

		#endregion



		#region " Constructors "

		public GeneralMessage() { }

		public GeneralMessage(string message)
		{
			_message = message;
		}

		public GeneralMessage(string message, string category)
			: base(category)
		{
			_message = message;
		}

		#endregion



		#region " Methods "

		protected internal override string GetMessage()
		{
			return this.Message;
		}

		#endregion
	}
}
