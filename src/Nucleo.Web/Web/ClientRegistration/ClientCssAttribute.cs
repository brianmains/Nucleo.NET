using System;
using System.Collections.Generic;


namespace Nucleo.Web.ClientRegistration
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class ClientCssAttribute : Attribute
	{
		private string _assembly = null;
		private string _path = null;



		#region " Properties "

		public string Assembly
		{
			get { return _assembly; }
		}

		public string Path
		{
			get { return _path; }
		}

		#endregion



		#region " Constructors "

		public ClientCssAttribute(string path)
		{
			_path = path;
		}

		public ClientCssAttribute(string path, string assembly)
			: this(path)
		{
			_assembly = assembly;
		}

		#endregion
	}
}
