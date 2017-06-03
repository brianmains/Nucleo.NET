using System;
using System.Configuration;


namespace Nucleo.Web.Mappings.Configuration
{
	public class ControlMappingsSection : ConfigurationSection
	{
		[
			ConfigurationProperty("", IsDefaultCollection=true),
			ConfigurationCollection(typeof(ControlMappingGroupElementCollection))
		]
		public ControlMappingGroupElementCollection Groups
		{
			get { return (ControlMappingGroupElementCollection) this[""]; }
		}

		public static ControlMappingsSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/controlMappings") as ControlMappingsSection; }
		}
	}
}
