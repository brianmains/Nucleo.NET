using System;
using System.Configuration;

using Nucleo.Configuration;


namespace Nucleo.Orm.Configuration
{
	/// <summary>
	/// Represents the section for unit of work entries.
	/// </summary>
	public class UnitOfWorkSection : ConfigurationSectionBase
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the type of object to use for caching.
		/// </summary>
		[ConfigurationProperty("cacheTypeName")]
		public string CacheTypeName
		{
			get { return (string)this["cacheTypeName"]; }
			set { this["cacheTypeName"] = value; }
		}

		/// <summary>
		/// Gets or sets the type of object to use for creation.
		/// </summary>
		[ConfigurationProperty("creatorTypeName")]
		public string CreatorTypeName
		{
			get { return (string)this["creatorTypeName"]; }
			set { this["creatorTypeName"] = value; }
		}

		/// <summary>
		/// Gets or sets the type for the discovery strategy.
		/// </summary>
		[ConfigurationProperty("discoveryStrategyTypeName", IsRequired = true)]
		public string DiscoveryStrategyTypeName
		{
			get { return (string)this["discoveryStrategyTypeName"]; }
			set { this["discoveryStrategyTypeName"] = value; }
		}

		public static UnitOfWorkSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo.orm/unitOfWork") as UnitOfWorkSection; }
		}

		/// <summary>
		/// Gets or sets the registrations for the unit of work.
		/// </summary>
		[ConfigurationProperty("registrations")]
		public UnitOfWorkRegistrationElementCollection Registrations
		{
			get { return (UnitOfWorkRegistrationElementCollection)this["registrations"]; }
			set { this["registrations"] = value; }
		}

		#endregion
	}
}
