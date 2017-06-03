using System;
using System.IO;
using System.Web.Mvc;


namespace Nucleo.Web.Views
{
	public class NucleoView : WebFormView
	{
		#region " Constructors "

		public NucleoView(string viewPath)
			: base(viewPath) { }

		public NucleoView(string viewPath, string masterPath) 
			: base(viewPath, masterPath) { }

		#endregion
	}
}
