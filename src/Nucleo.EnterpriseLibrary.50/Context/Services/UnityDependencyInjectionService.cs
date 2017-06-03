using System;

using Microsoft.Practices.Unity;


namespace Nucleo.Context.Services
{
	public class UnityDependencyInjectionService : IDependencyInjectionService
	{
		private IUnityContainer _container = null;



		#region " Constructors "

		public UnityDependencyInjectionService(IUnityContainer container)
		{
			_container = container;
		}

		#endregion



		#region " Methods "
		
		public object Resolve(Type resolvedType)
		{
			return _container.Resolve(resolvedType);
		}

		public object Resolve(Type resolvedType, string key)
		{
			return _container.Resolve(resolvedType, key);
		}

		public T Resolve<T>()
		{
			return _container.Resolve<T>();
		}

		public T Resolve<T>(string key)
		{
			return _container.Resolve<T>(key);
		}

		#endregion
	}
}
