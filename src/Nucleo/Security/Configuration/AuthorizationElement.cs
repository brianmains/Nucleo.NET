using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Security.Configuration
{
	public class AuthorizationElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("allowedRoles")]
		public string AllowedRoles
		{
			get { return (string)this["allowedRoles"]; }
			set { this["allowedRoles"] = value; }
		}

		[ConfigurationProperty("allowedUsers")]
		public string AllowedUsers
		{
			get { return (string)this["allowedUsers"]; }
			set { this["allowedUsers"] = value; }
		}

		[ConfigurationProperty("deniedRoles")]
		public string DeniedRoles
		{
			get { return (string)this["deniedRoles"]; }
			set { this["deniedRoles"] = value; }
		}

		[ConfigurationProperty("deniedUsers")]
		public string DeniedUsers
		{
			get { return (string)this["deniedUsers"]; }
			set { this["deniedUsers"] = value; }
		}

		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion
	}
}
