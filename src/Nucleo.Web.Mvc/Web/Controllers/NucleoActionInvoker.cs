using System;
using System.Web.Mvc;
using System.Web.Routing;

using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Lookups;
using Nucleo.Web.Mvc;
using Nucleo.Web.Mvc.Configuration;


namespace Nucleo.Web.Controllers
{
	/// <summary>
	/// Represents the object responsible for invoking actions.
	/// </summary>
	public class NucleoActionInvoker : ControllerActionInvoker
	{
		private IViewEngine _engine = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the engine used for the action invoker; some features use a view engine.
		/// </summary>
		public IViewEngine Engine
		{
			get 
			{ 
				if (_engine == null)
				{
					if (ViewEngines.Engines.Count > 0)
						_engine = ViewEngines.Engines[0];
				}

				return _engine; 
			}
			set { _engine = value; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Check for the existence of a view that will display the page in an offline state.
		/// </summary>
		/// <param name="controllerContext">The context of the controller.</param>
		/// <returns>Whether the offline view exists.</returns>
		protected virtual bool CheckForOfflineView(ControllerContext controllerContext)
		{
			if (this.Engine == null)
				return false;

			ViewEngineResult result = this.Engine.FindView(controllerContext, "App_Offline", null, false);
			if (result == null || result.View == null)
				return false;

			return true;
		}

		/// <summary>
		/// Actually invokes the action method.
		/// </summary>
		/// <param name="controllerContext">The context for the controller.</param>
		/// <param name="actionName">The name of the action method to invoke.</param>
		/// <returns>Whether the action invoked correctly.</returns>
		protected virtual bool DoInvokeAction(ControllerContext controllerContext, string actionName)
		{
			return base.InvokeAction(controllerContext, actionName);
		}

		/// <summary>
		/// Calls <see cref="DoInvokeAction">the DoInvokeAction method</see> to actually invoke the action.  If an error occurs, it is logged and the error rethrown.
		/// </summary>
		/// <param name="controllerContext">The context for the controller.</param>
		/// <param name="actionName">The name of the action method to invoke.</param>
		/// <returns>Whether the action invoked correctly.</returns>
		public override bool InvokeAction(ControllerContext controllerContext, string actionName)
		{
			//Check whether the offline view redirects
			if (this.CheckForOfflineView(controllerContext))
			{
				ViewResult result = new ViewResult();
				result.ViewName = "App_Offline";

				this.InvokeActionResult(controllerContext, result);
				return true;
			}

			try
			{
				bool value = this.DoInvokeAction(controllerContext, actionName);
				if (!value)
				{
					//Log when an action method can't be found
					ApplicationContext context = ApplicationContext.GetCurrent();
					ILoggerService logger = context.GetService<ILoggerService>();

					logger.LogMessage(string.Format("Action '{0}' could not be found.", actionName), "Action Invoker",
						logger.GetMessageTypes().GetHighest(),
						logger.GetVerbosityTypes().GetLowest());
				}

				return value;
			}
			catch (System.Threading.ThreadAbortException aex)
			{
				//Log a thread abort exception
				ApplicationContext context = ApplicationContext.GetCurrent();
				ILoggerService logger = context.GetService<ILoggerService>();

				if (logger != null)
				{
					logger.LogError(aex, "Action Invoker",
						logger.GetMessageTypes().GetHighest(),
						logger.GetVerbosityTypes().GetLowest());
				}

				if (!this.RedirectToErrorView(controllerContext, aex))
					throw;
				else
					return true;
			}
			catch (Exception ex)
			{
				//Log any general exception
				ApplicationContext context = ApplicationContext.GetCurrent();
				ILoggerService logger = context.GetService<ILoggerService>();

				if (logger != null)
				{
					logger.LogError(ex, "Action Invoker",
						logger.GetMessageTypes().GetHighest(),
						logger.GetVerbosityTypes().GetLowest());
				}

				if (!this.RedirectToErrorView(controllerContext, ex))
					throw;
				else
					return true;
			}
		}

		protected override void InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
		{
			base.InvokeActionResult(controllerContext, actionResult);
		}

		/// <summary>
		/// Gets a parameter value; looks for attributes define at the class level.
		/// </summary>
		/// <param name="controllerContext">The context of the controller.</param>
		/// <param name="parameterDescriptor">The descriptor for the parameter.</param>
		/// <returns>The object value for the parameter.</returns>
		protected override object GetParameterValue(ControllerContext controllerContext, ParameterDescriptor parameterDescriptor)
		{
			object[] attributes = parameterDescriptor.GetCustomAttributes(true);

			if (attributes == null || attributes.Length == 0)
				return base.GetParameterValue(controllerContext, parameterDescriptor);

			foreach (object attribute in attributes)
			{
				if (attribute is LookupAttribute)
				{
					string lookupName = ((LookupAttribute)attribute).LookupName;
					return LookupManager.Create().GetLookupRepository(lookupName).GetAllValues(null);
				}
			}

			return base.GetParameterValue(controllerContext, parameterDescriptor);
		}

		protected virtual bool RedirectToErrorView(ControllerContext controllerContext, Exception ex)
		{
			MvcSettingsSection section = MvcSettingsSection.Instance;
			if (section == null)
				return false;
			if (string.IsNullOrEmpty(section.ErrorViewName))
				return false;

			ViewResult result = new ViewResult();
			result.ViewName = section.ErrorViewName;
			result.ViewData.Model = ex;

			this.InvokeActionResult(controllerContext, result);
			return true;
		}

		#endregion
	}
}
