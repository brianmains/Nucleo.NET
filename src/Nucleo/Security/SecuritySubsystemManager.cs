using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Security
{
	public static class SecuritySubsystemManager
	{
		private static SecuritySubsystemManagementProvider _defaultProvider = null;
		private static SecuritySubsystemManagementProviderCollection _providers = null;
		private static bool _initialized = false;



		#region " Properties "

		public static SecuritySubsystemManagementProvider DefaultProvider
		{
			get
			{
				Initialize();
				return _defaultProvider;
			}
		}

		public static SecuritySubsystemManagementProviderCollection Providers
		{
			get
			{
				Initialize();
				return _providers;
			}
		}

		#endregion



		#region " Methods "

		public static SecuritySubsystem CreateSubsystem(string subsystemName, string description, out SecurityObjectCreationStatusType status)
		{
			if (string.IsNullOrEmpty(subsystemName))
				throw new ArgumentNullException("subsystemName");
			if (SecurityFramework.Subsystems.Contains(subsystemName))
			{
				status = SecurityObjectCreationStatusType.Duplicate;
				return null;
			}

			SecuritySubsystem subsystem = DefaultProvider.CreateSubsystem(subsystemName, description, out status);
			if (subsystem == null)
				throw new NullReferenceException();
			SecurityFramework.Subsystems.Add(subsystem);
			return subsystem;
		}

		public static bool DeleteSubsystem(SecuritySubsystem subsystem)
		{
			if (subsystem == null)
				throw new ArgumentNullException("subsystem");

			if (SecurityFramework.Subsystems.Contains(subsystem))
			{
				SecurityFramework.Subsystems.Remove(subsystem);
				DefaultProvider.DeleteSubsystemAssociations(subsystem);
				return DefaultProvider.DeleteSubsystem(subsystem);
			}

			return false;
		}

		internal static SecuritySubsystemCollection GetSubsystems()
		{
			return DefaultProvider.GetSubsystems();
		}

		private static void Initialize()
		{
			if (_initialized)
				return;


		}

		#endregion
	}
}
