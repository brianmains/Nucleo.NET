using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Windows.Application.Configuration
{
	public class ApplicationControllerInterfaceElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("controlType", IsRequired = true)]
		public string ControlType
		{
			get { return (string)this["controlType"]; }
			set { this["controlType"] = value; }
		}

		[ConfigurationProperty("interface", IsRequired=true)]
		public WindowsInterfaceType Interface
		{
			get { return (WindowsInterfaceType)this["interface"]; }
			set { this["interface"] = value; }
		}

		protected override string UniqueKey
		{
			get { return this.Interface.ToString(); }
		}

		[ConfigurationProperty("rendererType", IsRequired=true)]
		public string RendererType
		{
			get { return (string)this["rendererType"]; }
			set { this["rendererType"] = value; }
		}

		#endregion



		#region " Constructors "

		public ApplicationControllerInterfaceElement() { }

		public ApplicationControllerInterfaceElement(WindowsInterfaceType uiInterface, string rendererType)
		{
			this.Interface = uiInterface;
			this.RendererType = rendererType;
		}

		#endregion
	}
}
