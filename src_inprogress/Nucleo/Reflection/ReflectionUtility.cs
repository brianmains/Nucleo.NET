using System;
using System.Collections.Generic;
using System.Reflection;


namespace Nucleo.Reflection
{
	[Obsolete("This will be going away soon")]
	public static class ReflectionUtility
	{
		#region " Properties "

		public static BindingFlags InstanceFlags
		{
			get { return BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic; }
		}

		public static BindingFlags NonPublicInstanceFlags
		{
			get { return BindingFlags.Instance | BindingFlags.NonPublic; }
		}

		public static BindingFlags NonPublicStaticFlags
		{
			get { return BindingFlags.Static | BindingFlags.NonPublic; }
		}

		public static BindingFlags PublicInstanceFlags
		{
			get { return BindingFlags.Instance | BindingFlags.Public; }
		}

		public static BindingFlags PublicStaticFlags
		{
			get { return BindingFlags.Static | BindingFlags.Public; }
		}

		public static BindingFlags StaticFlags
		{
			get { return BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic; }
		}



		#endregion



		#region " Methods "

		public static BindingFlags CreateBindingFlags(bool includeInstance, bool includeStatic, bool includePublic, bool includeNonPublic)
		{
			BindingFlags flags = BindingFlags.Default;
			if (includeInstance) flags |= BindingFlags.Instance;
			if (includeStatic) flags |= BindingFlags.Static;
			if (includePublic) flags |= BindingFlags.Public;
			if (includePublic) flags |= BindingFlags.NonPublic;

			return flags;
		}

		/// <summary>
		/// Gets an array of methods, defined for a specific type, that contains a specified attribute.
		/// </summary>
		/// <typeparam name="T">The type to inspect.</typeparam>
		/// <param name="attributeType">The type of attribute to look for.</param>
		/// <returns>An array of method objects that contain the specified attribute.</returns>
		/// <remarks>Calls the overloaded version to actually perform the collection.</remarks>
		public static MethodInfo[] GetMethodsContainingAttributes<T>(Type attributeType)
		{
			return GetMethodsContainingAttributes(typeof(T), attributeType);
		}

		/// <summary>
		/// Gets an array of methods, defined for a specific type, that contains a specified attribute.
		/// </summary>
		/// <param name="sourceType">The source object to inspect for methods.</param>
		/// <param name="attributeType">The type of attribute to look for.</param>
		/// <returns>An array of method objects that contain the specified attribute.</returns>
		public static MethodInfo[] GetMethodsContainingAttributes(Type sourceType, Type attributeType)
		{
			MethodInfo[] methods = sourceType.GetMethods(ReflectionUtility.InstanceFlags);
			List<MethodInfo> methodsList = new List<MethodInfo>();

			foreach (MethodInfo method in methods)
			{
				if (Attribute.IsDefined(method, attributeType))
					methodsList.Add(method);
			}

			return methodsList.ToArray();
		}

		#endregion
	}
}
