using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Presentation.Configuration
{
	public class RoutingElement : ConfigurationElement
	{
		#region " Properties "

		[ConfigurationProperty("baseUrl")]
		public string BaseUrl
		{
			get { return (string)this["baseUrl"]; }
			set { this["baseUrl"] = value; }
		}

		[ConfigurationProperty("viewPath")]
		public string ViewPath
		{
			get { return (string)this["viewPath"]; }
			set { this["viewPath"] = value; }
		}

		#endregion
	}
}
