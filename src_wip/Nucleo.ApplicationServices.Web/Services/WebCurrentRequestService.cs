using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Nucleo.Services
{
	/// <summary>
	/// Gets the current request information from the web form.
	/// </summary>
	public class WebCurrentRequestService : ICurrentRequestService
	{
		/// <summary>
		/// Gets the raw URL of the executing request.
		/// </summary>
		public string RawUrl
		{
			get { return HttpContext.Current.Request.RawUrl; }
		}
	}
}
