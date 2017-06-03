using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo
{
	public class TypeLoader
	{
		public static object Create(Type objectType, params object[] args)
		{
			return Activator.CreateInstance(objectType, args);
		}

		public static T Create<T>(params object[] args)
		{
			return (T)Activator.CreateInstance(typeof(T), args);
		}
	}
}
