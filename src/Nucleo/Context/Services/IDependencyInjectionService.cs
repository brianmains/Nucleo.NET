using System;
using System.Collections.Generic;


namespace Nucleo.Context.Services
{
	public interface IDependencyInjectionService : IService
	{
		#region " Methods "

		object Resolve(Type resolvedType);

		object Resolve(Type resolvedType, string key);

		T Resolve<T>();

		T Resolve<T>(string key);

		#endregion
	}
}
