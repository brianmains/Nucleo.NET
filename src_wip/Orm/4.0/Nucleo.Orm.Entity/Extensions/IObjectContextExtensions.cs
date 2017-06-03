using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;


namespace Nucleo.Orm.Entities
{
	public static class IObjectContextExtensions
	{
		/// <summary>
		/// Creates the object set by the given type.
		/// </summary>
		/// <param name="context">The context to query.</param>
		/// <param name="type">The type of object to get the object set for.</param>
		/// <returns>The object set.</returns>
		public static ObjectEntitySet CreateObjectSet(this IObjectContext context, Type type)
		{
			MethodInfo method = context.GetType().GetMethod("CreateObjectSet", new Type[] { });
			if (method == null)
				return null;

			return new ObjectEntitySet(method.MakeGenericMethod(type).Invoke(context, new object[] { }));
		}

		/// <summary>
		/// Creates the object set by the given type.
		/// </summary>
		/// <param name="context">The context to query.</param>
		/// <param name="type">The type of object to get the object set for.</param>
		/// <param name="entitySet">The name of the entity set.</param>
		/// <returns>The object set.</returns>
		public static ObjectEntitySet CreateObjectSet(this IObjectContext context, Type type, string entitySet)
		{
			MethodInfo method = context.GetType().GetMethod("CreateObjectSet", new Type[] { typeof(string) });
			if (method == null)
				return null;

			return new ObjectEntitySet(method.MakeGenericMethod(type).Invoke(context, new object[] { entitySet }));
		}
	}
}
