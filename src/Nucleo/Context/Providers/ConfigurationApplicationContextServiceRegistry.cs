using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Configuration;
using Nucleo.Context.Configuration;
using Nucleo.Collections;


namespace Nucleo.Context.Providers
{
	public class ConfigurationApplicationContextServiceRegistry : IApplicationContextServiceRegistry
	{
		#region " Methods "

		public void LoadServices(TypeRegistry registry)
		{
			ContextSettingsSection section = ContextSettingsSection.Instance;
			if (section == null)
				throw new System.Configuration.ConfigurationErrorsException("The context settings section was not established.");

			foreach (TypeRegistrationElement registration in section.Services)
			{
				Type contract = Type.GetType(registration.ContractTypeName);
				if (contract == null)
					throw new NullReferenceException("The contract type could not be loaded: " + registration.ContractTypeName);

				Type map = Type.GetType(registration.MappedTypeName);
				if (map == null)
					throw new NullReferenceException("The map type could not be loaded: " + registration.MappedTypeName);

				registry.Register(contract, Activator.CreateInstance(map));
			}
		}

		#endregion
	}
}
