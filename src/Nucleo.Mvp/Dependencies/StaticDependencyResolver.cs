using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Dependencies
{
	public class StaticDependencyResolver : IDependencyResolver
	{
		public object GetDependency(Type type)
		{
			return Activator.CreateInstance(type);
		}

		public T GetDependency<T>()
		{
			return (T)GetDependency(typeof(T));
		}
	}
}
