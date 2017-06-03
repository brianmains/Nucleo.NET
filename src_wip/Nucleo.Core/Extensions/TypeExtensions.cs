using System;
using System.Collections.Generic;


namespace System
{
	public static class TypeExtensions
	{
		#region " Methods "

#if NET20
		public static object Instantiate(Type type)
#else
		public static object Instantiate(this Type type)
#endif
		{
			return Activator.CreateInstance(type);
		}

#if NET20
		public static T Instantiate<T>(Type type)
#else
		public static T Instantiate<T>(this Type type)
#endif
		{
			return (T)Activator.CreateInstance(type);
		}

		#endregion
	}
}
