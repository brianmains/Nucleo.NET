using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Windows.ApplicationListeners.Configuration
{
	public class ControlConversionSection : ConfigurationSection
	{
		#region " Properties "

		[
		ConfigurationProperty("converters", IsDefaultCollection=true),
		ConfigurationCollection(typeof(NameTypeElementCollection))
		]
		public NameTypeElementCollection Converters
		{
			get { return (NameTypeElementCollection)this["converters"]; }
		}

		public static ControlConversionSection Instance
		{
			get { return (ControlConversionSection)ConfigurationManager.GetSection("nucleo/applicationModel/controlConverters"); }
		}

		#endregion
	}
}
