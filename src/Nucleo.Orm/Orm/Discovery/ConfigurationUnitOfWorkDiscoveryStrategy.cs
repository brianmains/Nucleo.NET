using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

using Nucleo.Orm.Configuration;


namespace Nucleo.Orm.Discovery
{
	/// <summary>
	/// Represents the discovery strategy that uses the configurationfile.
	/// </summary>
	public class ConfigurationUnitOfWorkDiscoveryStrategy : IUnitOfWorkDiscoveryStrategy
	{
		#region " Methods "

		private IDictionary CreateAttributes(NameValueConfigurationCollection values)
		{
			Dictionary<string, string> attributes = new Dictionary<string, string>();
			foreach (NameValueConfigurationElement element in values)
				attributes.Add(element.Name, element.Value);

			return attributes;
		}

		/// <summary>
		/// Locates the unit of work in the configuration file.
		/// </summary>
		/// <param name="options">The options to use to find the unit of work.</param>
		/// <returns>The found unit of work, or null if not found.</returns>
		/// <exception cref="ArgumentNullException">Thrown when options are null.</exception>
		/// /// <exception cref="NullReferenceException">Thrown when type could not be found or unit of work doesn't implement <see cref="IUnitOfWork"/> interface.</exception>
		public IUnitOfWork LocateUnitOfWork(UnitOfWorkDiscoveryOptions options)
		{
			if (options == null)
				throw new ArgumentNullException("options");

			UnitOfWorkSection section = UnitOfWorkSection.Instance;
			if (section == null)
				return null;

			UnitOfWorkRegistrationElement registration = section.Registrations[options.Name];
			if (registration == null)
				return null;

			Type type = Type.GetType(registration.TypeName);
			if (type == null)
				throw new NullReferenceException("The type could not be found: " + registration.TypeName);

			if (options.Creator != null)
				return options.Creator.Create(type, CreateAttributes(registration.Attributes));
			else
			{
				IUnitOfWork work = Activator.CreateInstance(type) as IUnitOfWork;
				if (work == null)
					throw new NullReferenceException("Could not create a unit of work from this type; it may not implement IUnitOfWork: " + type.FullName);

				return work;
			}
		}

		#endregion
	}
}
