using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

using Nucleo.Orm.Configuration;


namespace Nucleo.Orm.Discovery
{
	/// <summary>
	/// Represents the discovery strategy that uses the configuration file to find unit of work definition.  Each of these definitions are found from the <see cref="UnitOfWorkRegistrationElement"/> class.
	/// </summary>
	public class ConfigurationUnitOfWorkDiscoveryStrategy : IUnitOfWorkDiscoveryStrategy
	{
		#region " Methods "

		private IDictionary<object, object> CreateAttributes(NameValueConfigurationCollection values)
		{
			var attributes = new Dictionary<object, object>();
			foreach (NameValueConfigurationElement element in values)
				attributes.Add(element.Name, element.Value);

			return attributes;
		}

		/// <summary>
		/// Locates the unit of work in the configuration file, finding the appropriate <see cref="UnitOfWorkRegistrationElement"/> registration definition and instantiating it, if found.  If not found,  the discovery strategy returns null.
		/// </summary>
		/// <param name="options">The options to use to find the unit of work.</param>
		/// <returns>The found unit of work, or null if not found.</returns>
		/// <exception cref="ArgumentNullException">Thrown when options are null.</exception>
		/// /// <exception cref="NullReferenceException">Thrown when type could not be found or unit of work doesn't implement <see cref="IUnitOfWork"/> interface.</exception>
        public UnitOfWorkDiscoveryResults LocateUnitOfWork(UnitOfWorkDiscoveryOptions options)
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
            if (type != null && type.Name.Contains("RuntimeType"))
                type = type.UnderlyingSystemType;

            return new UnitOfWorkDiscoveryResults { UnitOfWorkType = type, Attributes = CreateAttributes(registration.Attributes) };
		}

		#endregion
	}
}
