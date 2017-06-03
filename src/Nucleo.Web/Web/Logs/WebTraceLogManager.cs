using System;
using System.Web;
using System.Web.UI;

using Nucleo.Logs;


namespace Nucleo.Web.Logs
{
	public class WebTraceLogManager : ILogManager
	{
		#region " Methods "

		private Page GetPage()
		{
			if (HttpContext.Current.Handler is Page)
				return (Page)HttpContext.Current.Handler;
			else
				return null;
		}

		public void LogError(Exception ex, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			Page page = this.GetPage();
			if (page != null)
				page.Trace.Warn(source, ex.Message, ex);
		}

		public void LogMessage(string message, string source, LogMessageType messageType, LogVerbosityType verbosity)
		{
			Page page = this.GetPage();
			if (page != null)
				page.Trace.Write(source, message);
		}

		#endregion
	}
}
