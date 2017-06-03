using System;
using Nucleo.Collections;
using Nucleo.Providers;


namespace Nucleo.Security
{
	public abstract class SecuritySubsystemManagementProvider : ProviderBase
	{
		protected SecuritySubsystem CreateSubsystemObject(Guid id, string name, string description)
		{
			return new SecuritySubsystem(id, name, description);
		}

		public abstract SecuritySubsystem CreateSubsystem(string subsystemName, string description, out SecurityObjectCreationStatusType status);
		public abstract bool DeleteSubsystem(SecuritySubsystem subsystem);
		public abstract bool DeleteSubsystemAssociations(SecuritySubsystem subsystem);
		protected internal abstract SecuritySubsystemCollection GetSubsystems();
	}


	public class SecuritySubsystemManagementProviderCollection : ProviderCollection<SecuritySubsystemManagementProvider> { }
}
