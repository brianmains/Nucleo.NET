using System;
using System.Configuration;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.Application.Configuration
{
	public class ApplicationControllerSection : ConfigurationSection
	{
		#region " Properties "

		public static ApplicationControllerSection Instance
		{
			get { return ConfigurationManager.GetSection("nucleo/applicationControllers") as ApplicationControllerSection; }
		}

		[
		ConfigurationProperty("interfaces", IsDefaultCollection=false),
		ConfigurationCollection(typeof(ApplicationControllerInterfaceElementCollection))
		]
		public ApplicationControllerInterfaceElementCollection Interfaces
		{
			get { return (ApplicationControllerInterfaceElementCollection)this["interfaces"]; }
		}

		#endregion



		#region " Methods "

		public Type GetRendererType(WindowsInterfaceType uiInterface)
		{
			return Type.GetType(this.Interfaces[uiInterface].RendererType);
		}

		#endregion
	}
}
