using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.ClientRegistration
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class ClientScriptAttribute : Attribute
	{
		private string _assembly = null;
		private ScriptMode? _mode = null;
		private string _type = null;



		#region " Properties "

		public string Assembly
		{
			get { return _assembly; }
		}

		public ScriptMode? Mode
		{
			get { return _mode; }
		}

		public string Type
		{
			get { return _type; }
		}

		#endregion



		#region " Constructors "

		public ClientScriptAttribute(Type type)
			: this(type.FullName, type.Assembly.FullName) { }

		public ClientScriptAttribute(Type type, ScriptMode mode)
			: this(type)
		{
			_mode = mode;
		}

		public ClientScriptAttribute(string type, string assembly)
		{
			_assembly = assembly;
			_type = type;
		}

		public ClientScriptAttribute(string type, string assembly, ScriptMode mode)
			: this(type, assembly)
		{
			_mode = mode;
		}

		#endregion
	}
}
