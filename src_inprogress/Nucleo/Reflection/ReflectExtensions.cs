using System;
using System.Collections.Generic;

using Nucleo.Attributes;


namespace Nucleo.Reflection
{
	public static class ReflectExtensions
	{
		#region " Methods "

		public static ReflectDefinition NonPublic<T>(this T obj)
			where T : class
		{
			return new ReflectDefinition(obj, true);
		}

		public static ReflectDefinition Public<T>(this T obj)
			where T : class
		{
			return new ReflectDefinition(obj, false);
		}

		#endregion
	}
}
