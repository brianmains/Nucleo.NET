using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Nucleo;


namespace Nucleo.Services
{
	/// <summary>
	/// Represents a dependency injection service using the HttpContext.Items collection as its source.
	/// </summary>
	public class HttpContextDependencyInjectionService : IDependencyInjectionService
	{
		#region " Methods "

		public object Resolve(Type resolvedType)
		{
			return HttpContext.Current.Items[resolvedType];
		}

		public object Resolve(Type resolvedType, string key)
		{
			var result = HttpContext.Current.Items[resolvedType.FullName] as IDictionary;
			if (result == null)
				return null;

			return result[key];
		}

		public T Resolve<T>()
		{
			return (T)HttpContext.Current.Items[typeof(T)];
		}

		public T Resolve<T>(string key)
		{
			var result = HttpContext.Current.Items[typeof(T)] as IDictionary;
			if (result == null)
				return default(T);

			return (T)result[key];
		}

		#endregion
	}
}
