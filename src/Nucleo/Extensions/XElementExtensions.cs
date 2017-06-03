#if NET20

#else
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace System.Xml.Linq
{
	/// <summary>
	/// Represents the extensions for the XElement class.
	/// </summary>
	public static class XElementExtensions
	{
		#region " Methods "

		/// <summary>
		/// Gets a child's element value using the name.
		/// </summary>
		/// <param name="element">The element to access inner content values for.</param>
		/// <param name="childName">The child name.</param>
		/// <returns>THe inner element's value.</returns>
		public static string ElementValue(this XElement element, XName childName)
		{
			return ElementValue(element, childName, null);
		}

		/// <summary>
		/// Gets a child's element value using the name.
		/// </summary>
		/// <param name="element">The element to access inner content values for.</param>
		/// <param name="childName">The child name.</param>
		/// <param name="defaultValue">The default value to return if the element isn't found.</param>
		/// <returns>THe inner element's value.</returns>
		public static string ElementValue(this XElement element, XName childName, string defaultValue)
		{
			return (element.Element(childName) != null)
							? element.Element(childName).Value
							: defaultValue;
		}

		/// <summary>
		/// Gets a child's element value, using a lambda to specify the non-null or null values.
		/// </summary>
		/// <typeparam name="T">The type of final value.</typeparam>
		/// <param name="element">The element that's being extended.</param>
		/// <param name="childName">The name of the child.</param>
		/// <param name="nonNullValue">The lambda to return the value when the child exists.</param>
		/// <param name="nullValue">The lambda to return the default value when null.</param>
		/// <returns>The value for the non-null/null lambdas.</returns>
		public static T ElementValue<T>(this XElement element, XName childName, Func<XElement, T> nonNullValue, Func<T> nullValue)
		{
			XElement child = element.Element(childName);

			if (child != null)
				return nonNullValue(child);
			else
				return nullValue();
		}

		#endregion
	}

}
#endif