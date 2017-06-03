using System;
using System.Web;
using System.Web.Management;


namespace Nucleo.Web.Logs
{
	public class LoggerErrorEvent : WebErrorEvent
	{
		#region " Constructors "

		public LoggerErrorEvent(string source, Exception ex)
			: base(ex.Message, source, 110000, ex) { }

		#endregion



		#region " Methods "

		public static LoggerErrorEvent Raise(string source, Exception ex)
		{
			LoggerErrorEvent eventInfo = new LoggerErrorEvent(source, ex);
			eventInfo.Raise();

			return eventInfo;
		}

		#endregion
	}
}
