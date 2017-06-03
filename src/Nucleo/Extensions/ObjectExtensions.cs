using System;
using System.Reflection;
using System.Collections.Generic;
#if NET20
#else
using System.Linq.Expressions;
#endif


namespace Nucleo.Extensions
{
	/// <summary>
	/// Represents extensions for the object type.
	/// </summary>
	public static class ObjectExtensions
	{
		#region " Methods "

		/// <summary>
		/// Performs a bulk range of actions on an object.
		/// </summary>
		/// <typeparam name="T">The type to perform an action on.</typeparam>
		/// <param name="obj">The object to extend.</param>
		/// <param name="action">The action to perform.</param>
		/// <returns>The acted on object.</returns>
#if NET20
		public static T Action<T>(T obj, Action<T> action)
#else
		public static T Action<T>(this T obj, Action<T> action)
#endif
			where T: class, new()
		{
			action(obj);
			return obj;
		}

		/// <summary>
		/// Copies data from one object to another.
		/// </summary>
		/// <typeparam name="T">The type of object to convert.</typeparam>
		/// <param name="target">The target object.</param>
		/// <param name="source">The source object.</param>
#if NET20
		public static void CopyFrom<T>(T target, T source)
#else
		public static void CopyFrom<T>(this T target, T source)
#endif
			where T: class
		{
			PropertyInfo[] properties = typeof(T).GetProperties();

			foreach (PropertyInfo property in properties)
			{
				if (property.CanRead && property.CanWrite)
				{
					object value = property.GetValue(source, null);
					property.SetValue(target, value, null);
				}
			}
		}

		/// <summary>
		/// Copies data from one object to another.
		/// </summary>
		/// <typeparam name="T">The type of object to convert.</typeparam>
		/// <param name="target">The target object.</param>
		/// <param name="source">The source object.</param>
#if NET20
		public static void CopyFrom<T>(T target, object source)
#else
		public static void CopyFrom<T>(this T target, object source)
#endif
 where T : class
		{
			PropertyInfo[] properties = typeof(T).GetProperties();
			Type sourceType = source.GetType();

			foreach (PropertyInfo property in properties)
			{
				PropertyInfo sourceProperty = sourceType.GetProperty(property.Name);
				if (sourceProperty == null)
					continue;

				if (sourceProperty.CanRead && property.CanWrite)
				{
					object value = sourceProperty.GetValue(source, null);
					property.SetValue(target, value, null);
				}
			}
		}

#if NET20
		public static void CopyFrom<T>(T target, IDictionary<string, object> source)
#else
		public static void CopyFrom<T>(this T target, IDictionary<string, object> source)
#endif
			where T : class
		{
			PropertyInfo[] properties = typeof(T).GetProperties();

			foreach (PropertyInfo property in properties)
			{
				if (source.ContainsKey(property.Name) && property.CanWrite)
					property.SetValue(target, source[property.Name], null);
			}
		}

#if NET20
#else
		public static TOut Get<TIn, TOut>(this TIn obj, Expression<Func<TIn, TOut>> fn)

		{
			PropertyInfo member = ((MemberExpression)fn.Body).Member as PropertyInfo;
			if (member == null)
				throw new ArgumentNullException("member", "The property information could not be found.");

			object value = member.GetValue(obj, null);
			if (value != null)
				return (TOut)value;
			else
			{
				TOut final = (TOut)Activator.CreateInstance(member.PropertyType);
				member.SetValue(obj, final, null);

				return final;
			}
		}
#endif

		#endregion
	}
}
