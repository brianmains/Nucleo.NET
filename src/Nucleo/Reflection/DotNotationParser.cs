using System;
using System.Reflection;


namespace Nucleo.Reflection
{
	public static class DotNotationParser
	{
		#region " Methods "

		/// <summary>
		/// Gets the property values from an object.
		/// </summary>
		/// <param name="baseObject">The object to parse.</param>
		/// <returns>The returned property value from the object.</returns>
		public static object GetPropertyValue(string dotSeparatedText, object baseObject)
		{
			if (baseObject == null)
				throw new ArgumentNullException("baseObject");

			if (!dotSeparatedText.Contains("."))
			{
				PropertyInfo prop = baseObject.GetType().GetProperty(dotSeparatedText);
				return prop.GetValue(baseObject, null);
			}
			else
			{
				string[] propertyNames = dotSeparatedText.Split('.');
				object lastObject = baseObject;

				foreach (string propertyName in propertyNames)
				{
					PropertyInfo prop = lastObject.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					lastObject = prop.GetValue(lastObject, null);

					//Ensure we don't get a null reference exception
					if (lastObject == null)
						return null;
				}

				return lastObject;
			}
		}

		#endregion
	}
}
