using Nucleo.Presentation;
using Nucleo.Presentation.Caching;
using System;
using System.Web;
using Nucleo.Presentation;

namespace Nucleo.Web.Presentation
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
