using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;


namespace Nucleo.Context.Services
{
	public class AutofacDependencyInjectionService : IDependencyInjectionService
	{
		private IContainer _container = null;



		#region " Constructors "

		public AutofacDependencyInjectionService(IContainer container)
		{
			_container = container;
		}

		#endregion



		#region " Methods "

		public object Resolve(Type resolvedType)
		{
			if (_container.IsRegistered(resolvedType))
				return _container.Resolve(resolvedType);
			else
				return null;
		}

		public object Resolve(Type resolvedType, string key)
		{
			if (_container.IsRegisteredWithName(key, resolvedType))
				return _container.ResolveNamed(key, resolvedType);
			else
				return null;
		}

		public T Resolve<T>()
		{
			if (_container.IsRegistered<T>())
				return _container.Resolve<T>();
			else
				return default(T);
		}

		public T Resolve<T>(string key)
		{
			if (_container.IsRegisteredWithName<T>(key))
				return _container.ResolveNamed<T>(key);
			else
				return default(T);
		}

		#endregion
	}
}
