using System;
using System.Reflection;

namespace Nucleo.Web
{
	public class PropertyHandler
	{
		public static string Handle(object item, string defaultValue)
		{
			if (item == null)
				return defaultValue;
			else if (DBNull.Value.Equals(item))
				return defaultValue;

			return item.ToString();
		}

		public static string HandleComplex(object complexObject, string propertyName, string defaultValue)
		{
			Type type = complexObject.GetType();
			PropertyInfo prop = type.GetProperty(propertyName);

			if (prop == null)
				return defaultValue;

			return Handle(prop.GetValue(complexObject, null), defaultValue);
		}

		public static string HandleComplex(object complexObject, string propertyName, int index, string defaultValue)
		{
			Type type = complexObject.GetType();
			PropertyInfo prop = type.GetProperty(propertyName);

			if (prop == null)
				return defaultValue;

			return Handle(prop.GetValue(complexObject, new object[] { index }), defaultValue);
		}
	}
}
