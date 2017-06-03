using System;
using System.Reflection;
using System.Configuration;


namespace Nucleo.Configuration
{
	/// <summary>
	/// Represents a base class for configuration sections.
	/// </summary>
	public abstract class ConfigurationSectionBase : ConfigurationSection
	{
		#region " Methods "

		/// <summary>
		/// Creates an object from a property. Typically, the configuration file stores a reference to an object, which gets constructed 
		/// </summary>
		/// <typeparam name="T">The object instance to create.</typeparam>
		/// <param name="propertyName">The name of the property storing the reference to an object.</param>
		/// <returns>The object instance.</returns>
		/// <exception cref="ArgumentNullException">Fired when the property name is null, the property couldn't be found, or the type the property stores is null.</exception>
		/// <exception cref="InvalidOperationException">Creating the object didn't work.</exception>
		public T Create<T>(string propertyName)
		{
			if (string.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException("propertyName");

			PropertyInfo property = this.GetType().GetProperty(propertyName);
			if (property == null)
				throw new ArgumentNullException(propertyName, "The property wasn't found");

			Type propertyType = Type.GetType((string)property.GetValue(this, null));
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
