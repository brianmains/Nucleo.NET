using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Presentation.Configuration
{
	public class AjaxMethodElement : ConfigurationElementBase
	{
		#region " Properties "

		[ConfigurationProperty("methodName", IsRequired=true)]
		public string MethodName
		{
			get { return (string)this["methodName"]; }
			set { this["methodName"] = value; }
		}

		protected override string UniqueKey
		{
			get { return this.MethodName; }
		}

		#endregion
	}
}
