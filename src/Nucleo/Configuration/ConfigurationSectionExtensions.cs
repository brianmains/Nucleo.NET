using System;
using System.Reflection;
using System.Configuration;


namespace Nucleo.Configuration
{
	public static class ConfigurationSectionExtensions
	{
		#region " Methods "

		public static T Create<T>(this ConfigurationSection section, string propertyName)
		{
			if (string.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException("propertyName");

			PropertyInfo property = section.GetType().GetProperty(propertyName);
			if (property == null)
				throw new ArgumentNullException(propertyName, "The property wasn't found");

			string typeName = (string)property.GetValue(section, null);
			return GetPropertyValue<T>(section, typeName);
		}

		public static T Create<C, T>(this C section, Func<C, string> selector)
			where C : ConfigurationSection
		{
			if (selector == null)
				throw new ArgumentNullException("selector");

			return GetPropertyValue<T>(section, selector(section));
		}

		private static T GetPropertyValue<T>(this ConfigurationSection section, string propertyName)
		{
			Type propertyType = Type.GetType(propertyName);
			if (propertyType == null)
				throw new ArgumentNullException(propertyName, "The property's returning type could not be instantiated");

			try
			{
				return (T)Activator.CreateInstance(propertyType);
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("The property type could not be created, possibly because the type being constructed has constructor parameters.", ex);
			}
		}

		#endregion
	}
}
