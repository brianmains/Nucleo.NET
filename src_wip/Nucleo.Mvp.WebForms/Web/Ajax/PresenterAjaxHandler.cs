using System;
using System.Reflection;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;

using Nucleo.Presentation;


namespace Nucleo.Web.Ajax
{
	/// <summary>
	/// Represents the handler that handles Presenter AJAX requests.
	/// </summary>
	public class PresenterAjaxHandler : IHttpHandler
	{
		#region " Properties "

		/// <summary>
		/// Gets whether the presenter is reusable.
		/// </summary>
		public bool IsReusable
		{
			get { return true; }
		}

		#endregion



		#region " Methods "

		public virtual object ProcessPresenter(HttpContext context, Type presenterType, string operation)
		{
			if (presenterType == null)
				throw new ArgumentNullException("presenterType", "The presenter type was not provided.");
			if (string.IsNullOrEmpty(operation))
				throw new ArgumentNullException("operation");

			MethodInfo method = presenterType.GetMethod(operation);
			if (method == null)
				throw new ArgumentException(string.Format("The method '{0}' could not be found that's an instance/static method and public.", operation));
			PresenterWebMethodAttribute attributes = method.GetCustomAttribute<PresenterWebMethodAttribute>(false);

			List<object> values = new List<object>();
			object result = null;

			if (context.Request.QueryString.Count > 2)
			{
				ParameterInfo[] parms = method.GetParameters();
				foreach (ParameterInfo parm in parms)
				{
					object value = context.Request.QueryString.Get(parm.Name);
					if (value != null)
						values.Add(Convert.ChangeType(value, parm.ParameterType));
				}

				if (method.IsStatic)
					result = method.Invoke(null, values.ToArray());
				else
					throw new NotImplementedException("Instance methods have not yet been implemented.");
			}
			else
			{
				if (method.IsStatic)
					result = method.Invoke(null, new object[] { });
				else
					throw new NotImplementedException("Instance methods have not yet been implemented.");
			}

			if (result == null)
				return null;
			
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			return serializer.Serialize(result);
		}

		/// <summary>
		/// Processes the presenter AJAX request.
		/// </summary>
		/// <param name="context">The HTTP context.</param>
		public void ProcessRequest(HttpContext context)
		{
			string presenter = context.Server.HtmlDecode(context.Request.QueryString.Get("presenter"));
			string operation = context.Request.QueryString.Get("operation");

			if (string.IsNullOrEmpty(presenter) || string.IsNullOrEmpty(operation))
				return;

			Type presenterType = Type.GetType(presenter);
			context.Response.ContentType = "application/json";
			context.Response.Write(this.ProcessPresenter(context, presenterType, operation));
		}

		#endregion
	}
}
