using System;
using System.Web;

using Nucleo.Presentation;
using Nucleo.Presentation.Context;
using Nucleo.Presentation.Context.Caching;


namespace Nucleo.Web.Presentation.Context.Caching
{
	public class HttpContextPresenterContextCache : IPresenterContextCache
	{
		#region " Properties "

		public bool CanCache
		{
			get { return (HttpContext.Current != null); }
		}

		#endregion



		#region " Methods "

		public PresenterContext GetCurrentContext()
		{
			return HttpContext.Current.Items[typeof(PresenterContext)] as PresenterContext;
		}

		public bool UpdateCurrentContext(PresenterContext context)
		{
			HttpContext.Current.Items[typeof(PresenterContext)] = context;
			return true;
		}

		#endregion
	}
}
