using System;
using System.Collections.Generic;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Presentation.Configuration
{
	public class PresenterElement : ConfigurationElementBase
	{
		#region " Properties "

		[
		ConfigurationProperty("ajaxMethods", IsDefaultCollection = false),
		ConfigurationCollection(typeof(AjaxMethodElementCollection))
		]
		public AjaxMethodElementCollection AjaxMethods
		{
			get { return (AjaxMethodElementCollection)this["ajaxMethods"]; }
		}

		[ConfigurationProperty("typeName")]
		public string TypeName
		{
			get { return (string)this["typeName"]; }
			set { this["typeName"] = value; }
		}

		protected override string UniqueKey
		{
			get { return this.TypeName; }
		}

		#endregion



		#region " Methods "

		public IList<string> GetAjaxMethods()
		{
			List<string> list = new List<string>();
			foreach (AjaxMethodElement method in this.AjaxMethods)
				list.Add(method.MethodName);

			return list;
		}

		#endregion
	}
}
