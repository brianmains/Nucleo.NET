using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Nucleo.Context.Services;


namespace Nucleo.Web.Context.Services
{
	public class HttpContextDependencyInjectionService : IDependencyInjectionService
	{
		#region " Methods "

		public object Resolve(Type resolvedType)
		{
			return HttpContext.Current.Items[resolvedType];
		}

		public object Resolve(Type resolvedType, string key)
		{
			return HttpContext.Current.Items[resolvedType];
		}

		public T Resolve<T>()
		{
			return (T)HttpContext.Current.Items[typeof(T)];
		}

		public T Resolve<T>(string key)
		{
			return (T)HttpContext.Current.Items[typeof(T)];
		}

		#endregion
	}
}
