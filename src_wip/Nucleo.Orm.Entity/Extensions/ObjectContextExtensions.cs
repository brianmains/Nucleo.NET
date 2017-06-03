using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;

using Nucleo.Orm.Entities;


namespace System.Data.Objects
{
	/// <summary>
	/// Represents helpful extensions against the ObjectContext.
	/// </summary>
	public static class ObjectContextExtensions
	{
		/// <summary>
		/// Represents an extension method to create an object set in a generic fashion, by type.
		/// </summary>
		/// <param name="context">The context instance.</param>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		public static ObjectEntitySet CreateObjectSet(this ObjectContext context, Type type)
		{
			MethodInfo method = context.GetType().GetMethod("CreateObjectSet", new Type[] { });
			if (method == null)
				return null;

			return new ObjectEntitySet(method.MakeGenericMethod(type).Invoke(context, new object[] { }));
		}

		public static ObjectEntitySet CreateObjectSet(this ObjectContext context, Type type, string entitySet)
		{
			MethodInfo method = context.GetType().GetMethod("CreateObjectSet", new Type[] { typeof(string) });
			if (method == null)
				return null;

			return new ObjectEntitySet(method.MakeGenericMethod(type).Invoke(context, new object[] { entitySet }));
		}
	}
}
