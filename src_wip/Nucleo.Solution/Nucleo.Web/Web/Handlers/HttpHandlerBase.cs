using System;
using System.Web;


namespace Nucleo.Web.Handlers
{
	/// <summary>
	/// Writes the base class for HTTP handlers.
	/// </summary>
	public abstract class HttpHandlerBase : IHttpHandler
	{
		#region " Properties "

		/// <summary>
		/// Gets whether the handler is reusable; returns false, but can be overridden to return true.
		/// </summary>
		public virtual bool IsReusable
		{
			get { return false; }
		}

		#endregion



		#region " Methods "

		public void ProcessRequest(HttpContext context)
		{
			this.ProcessRequest(new HttpContextWrapper(context));
		}

		/// <summary>
		/// Processes the currently handled request.
		/// </summary>
		/// <param name="context">The context.</param>
		public abstract void ProcessRequest(HttpContextBase context);

		#endregion
	}
}
