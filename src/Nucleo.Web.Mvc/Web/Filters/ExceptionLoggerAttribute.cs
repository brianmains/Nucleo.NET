using System;
using System.Web.Mvc;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Logs;


namespace Nucleo.Web.Filters
{
	public class ExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
	{
		private bool _handleException = false;
		private string _source = null;



		#region " Properties "

		public bool HandleException
		{
			get { return _handleException; }
			set { _handleException = value; }
		}

		public string Source
		{
			get { return _source; }
			set { _source = value; }
		}

		#endregion



		#region " Methods "

		public void OnException(ExceptionContext filterContext)
		{
			filterContext.ExceptionHandled = this.HandleException;

			ApplicationContext context = ApplicationContext.GetCurrent();
			if (context == null)
				return;

			ILoggerService service = context.GetService<ILoggerService>();
			if (service == null)
				return;

			service.LogError(filterContext.Exception, this.Source,
				service.GetMessageTypes().GetHighest(),
				service.GetVerbosityTypes().GetLowest());
		}

		#endregion
	}
}
