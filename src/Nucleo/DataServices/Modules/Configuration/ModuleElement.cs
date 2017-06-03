using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.DataServices.Modules.Configuration
{
	/// <summary>
	/// Represents a module definition store within the configuration file.
	/// </summary>
	public class ModuleElement : NameTypeElement
	{
		#region " Properties "

		/// <summary>
		/// Gets the parameters for the specific module.
		/// </summary>
		[
		ConfigurationProperty("parameters", IsDefaultCollection = false),
		ConfigurationCollection(typeof(NameValueElementCollection))
		]
		public NameValueElementCollection Parameters
		{
			get { return (NameValueElementCollection)this["parameters"]; }
		}

		#endregion
	}
}
