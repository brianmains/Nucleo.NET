using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Logs
{
	public abstract class LogMessage
	{
		private string _category = null;



		#region " Properties "

		public string Category
		{
			get { return _category; }
		}

		#endregion



		#region " Constructors "

		public LogMessage() { }

		public LogMessage(string category)
		{
			_category = category;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Returns the message to assign to the log.
		/// </summary>
		/// <returns>Returns the message.</returns>
		protected internal abstract string GetMessage();

		#endregion
	}
}
