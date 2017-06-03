using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Lookups.Configuration
{
	/// <summary>
	/// Represents the configuration information for lookup repositories.  You do not need to use this information; the built-in objects use this information internally.  You do need to ensure it is properly configured.
	/// </summary>
	public class LookupRepositoriesSection : ConfigurationSectionBase
	{
		#region " Methods "

		/// <summary>
		/// Gets the collection of groups.  Each group is associated with a repository listing according to the specified name.
		/// </summary>
		[
		ConfigurationProperty("groups", IsDefaultCollection = false),
		ConfigurationCollection(typeof(LookupGroupElementCollection))
		]
		public LookupGroupElementCollection Groups
		{
			get { return (LookupGroupElementCollection)this["groups"]; }
		}

		/// <summary>
		/// Gets an instance of the repository out of the configuration file.  Returns null if the repository is not configured or configured incorrectly.
		/// </summary>
		public static LookupRepositoriesSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo.web/lookupRepositories") as LookupRepositoriesSection; }
		}

		/// <summary>
		/// Gets the collection of mappings; this maps the name of a repository to its type to instantiate.
		/// </summary>
		[
		ConfigurationProperty("mappings", IsDefaultCollection=false),
		ConfigurationCollection(typeof(NameTypeElementCollection))
		]
		public NameTypeElementCollection Mappings
		{
			get { return (NameTypeElementCollection)this["mappings"]; }
		}

		#endregion
	}
}
