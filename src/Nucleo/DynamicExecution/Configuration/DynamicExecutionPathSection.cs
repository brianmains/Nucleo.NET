using System;
using System.Configuration;
using Nucleo.Providers.Configuration;


namespace Nucleo.DynamicExecution.Configuration
{
	public class DynamicExecutionPathSection : ConfigurationSection
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets whether to fail the run on an exception thrown.
		/// </summary>
		[ConfigurationProperty("failOnException", DefaultValue = true)]
		public bool FailOnException
		{
			get { return (bool)this["failOnException"]; }
			set { this["failOnException"] = value; }
		}

		/// <summary>
		/// Gets or sets whether to fail the run on the first failure that occurs (using the custom event argument property).
		/// </summary>
		[ConfigurationProperty("failOnFirstFailure", DefaultValue = true)]
		public bool FailOnFirstFailure
		{
			get { return (bool)this["failOnFirstFailure"]; }
			set { this["failOnFirstFailure"] = value; }
		}

		public static DynamicExecutionPathSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/dynamicExecutionPath") as DynamicExecutionPathSection; }
		}

		[
		ConfigurationProperty("methods", IsDefaultCollection=false),
		ConfigurationCollection(typeof(DynamicExecutionPathMethodElementCollection))
		]
		public DynamicExecutionPathMethodElementCollection Methods
		{
			get { return (DynamicExecutionPathMethodElementCollection)this["methods"]; }
		}

		[ConfigurationProperty("methodProviders")]
		public DynamicExecutionPathMethodProvidersElement MethodProviders
		{
			get { return this["methodProviders"] as DynamicExecutionPathMethodProvidersElement; }
		}

		#endregion
	}
}
