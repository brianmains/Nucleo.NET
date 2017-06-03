using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.DynamicExecution.Configuration
{
	public class DynamicExecutionPathMethodElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("methodFriendlyName", IsRequired=true)]
		public string MethodFriendlyName
		{
			get { return (string)this["methodFriendlyName"]; }
			set { this["methodFriendlyName"] = value; }
		}

		[ConfigurationProperty("methodName", IsRequired = true)]
		public string MethodName
		{
			get { return (string)this["methodName"]; }
			set { this["methodName"] = value; }
		}

		[ConfigurationProperty("objectTypeName", IsRequired = true)]
		public string ObjectTypeName
		{
			get { return (string)this["objectTypeName"]; }
			set { this["objectTypeName"] = value; }
		}

		protected internal override string UniqueKey
		{
			get { return this.MethodFriendlyName; }
		}

		#endregion
	}
}
