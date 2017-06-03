using System;
using System.Web.Mvc;

using Nucleo.Context;
using Nucleo.Logs;
using Nucleo.Context.Services;


namespace Nucleo.Web.Filters
{
	public class ExecutionLoggerAttribute : ActionFilterAttribute
	{
		#region " Methods "

		private ILoggerService GetService()
		{
			ApplicationContext context = ApplicationContext.GetCurrent();
			if (context == null)
				return null;

			return context.GetService<ILoggerService>();
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			ILoggerService service = GetService();
			if (service == null)
				return;

			if (filterContext.Exception != null)
			{

				service.LogMessage(string.Format("The '{0}.{1}' action method was executed with a failure: '{2}'.",
					filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
					filterContext.ActionDescriptor.ActionName,
					filterContext.Exception.ToString()), "MVC",
					service.GetMessageTypes().GetByEnum(CommonLogMessageTypes.Error),
					service.GetVerbosityTypes().GetByEnum(CommonLogVerbosityTypes.Normal));
			}
			else
			{
				service.LogMessage(string.Format("The '{0}.{1}' action method was executed successfully.",
					filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
					filterContext.ActionDescriptor.ActionName), "MVC",
					service.GetMessageTypes().GetByEnum(CommonLogMessageTypes.Information),
					service.GetVerbosityTypes().GetByEnum(CommonLogVerbosityTypes.Normal));
			}
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			ILoggerService service = GetService();
			if (service == null)
				return;

			service.LogMessage(string.Format("The '{0}.{1}' action method is executing.", 
				filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
				filterContext.ActionDescriptor.ActionName), "MVC",
				service.GetMessageTypes().GetByEnum(CommonLogMessageTypes.Information),
				service.GetVerbosityTypes().GetByEnum(CommonLogVerbosityTypes.Normal));
		}

		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			ILoggerService service = GetService();
			if (service == null)
				return;

			if (filterContext.Exception != null)
			{
				service.LogMessage(string.Format("The view for '{0}.{1}' action, of type '{2}' raised an exception: {3}.",
					filterContext.RouteData.GetRequiredString("controller"),
					filterContext.RouteData.GetRequiredString("action"),
					filterContext.Result.GetType().Name,
					filterContext.Exception.ToString()), "MVC",
					service.GetMessageTypes().GetByEnum(CommonLogMessageTypes.Error),
					service.GetVerbosityTypes().GetByEnum(CommonLogVerbosityTypes.Normal));
			}
			else
			{
				service.LogMessage(string.Format("The view for '{0}.{1}' action, of type '{2}', was executed successfully.", 
					filterContext.RouteData.GetRequiredString("controller"),
					filterContext.RouteData.GetRequiredString("action"),
					filterContext.Result.GetType().Name), "MVC",
					service.GetMessageTypes().GetByEnum(CommonLogMessageTypes.Information),
					service.GetVerbosityTypes().GetByEnum(CommonLogVerbosityTypes.Normal));
			}
		}

		public override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			ILoggerService service = GetService();
			if (service == null)
				return;

			service.LogMessage(string.Format("The view for '{0}.{1}' action, of type '{2}', is executing.",
				filterContext.RouteData.GetRequiredString("controller"),
				filterContext.RouteData.GetRequiredString("action"),
				filterContext.Result.GetType().Name), "MVC",
				service.GetMessageTypes().GetByEnum(CommonLogMessageTypes.Information),
				service.GetVerbosityTypes().GetByEnum(CommonLogVerbosityTypes.Normal));
		}

		#endregion
	}
}
