using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Diagnostics;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the script request details.  These are used to identify the script component to register.
	/// </summary>
	/// <example>
	/// var details = new ScriptReferencingRequestDetails(typeof(MyControl), ScriptMode.Debug);
	/// var details2 = new ScriptReferencingRequestDetails("jquery.js", ScriptMode.Release);
	/// </example>
	[DebuggerDisplay("Path: {Path}, Type: {Type}/{Assembly}")]
	public sealed class ScriptReferencingRequestDetails
	{
		private string _assembly = null;
		private ScriptMode _mode = ScriptMode.Auto;
		private string _path = null;
		private string _type = null;



		#region " Properties "

		/// <summary>
		/// Gets the string name of the assembly.
		/// </summary>
		public string Assembly
		{
			get { return _assembly; }
		}

		/// <summary>
		/// Gets the mode that the script runs in.
		/// </summary>
		public ScriptMode Mode
		{
			get { return _mode; }
		}

		/// <summary>
		/// Gets the path to the file to reference, which could be a reference to the ScriptResource.axd or WebResource.axd.
		/// </summary>
		public string Path
		{
			get
			{
				if (string.IsNullOrEmpty(_path))
					return null;

				if (_path.EndsWith(".js"))
					return _path;
				else
					return _path + this.GetExtension();
			}
		}

		/// <summary>
		/// Gets the type of the embedded resource in the assembly.
		/// </summary>
		public string Type
		{
			get
			{
				if (string.IsNullOrEmpty(_type))
					return null;

				if (_type.EndsWith(".js"))
					return _type;
				else
					return _type + this.GetExtension();
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the script referencing details using the type and assembly of the server side external resource.
		/// </summary>
		/// <param name="assembly">The assembly of the server-side type, which the script must also reside in.</param>
		/// <param name="type">The server-side type of the external resource.</param>
		/// <param name="mode"></param>
		public ScriptReferencingRequestDetails(string assembly, string type, ScriptMode mode)
		{
			_assembly = assembly;
			_type = type;
			_mode = mode;
		}

		/// <summary>
		/// Creates the script referencing details using the path of the component, which is a local path.
		/// </summary>
		/// <param name="path">The path of the script.</param>
		/// <param name="mode">The mode to render in.</param>
		public ScriptReferencingRequestDetails(string path, ScriptMode mode)
		{
			_path = path;
			_mode = mode;
		}

		/// <summary>
		/// Creates the script referencing details using the type of the component, and the mode to render in.  The type must match the client-side type; for instance, Nucleo.Web.Controls.Check server-side type must also match a Nucleo.Web.Controls.Check client-side component.
		/// </summary>
		/// <param name="type">The type of server-side control.</param>
		/// <param name="mode">The mode to render in.</param>
		public ScriptReferencingRequestDetails(Type type, ScriptMode mode)
		{
			_assembly = type.Assembly.FullName;
			_type = type.FullName;
			_mode = mode;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the default extension for the script.
		/// </summary>
		/// <returns>The script extension.</returns>
		private string GetExtension()
		{
			return ".js";

			//if (this.Mode == ScriptMode.Release)
			//    return ".js";
			//else
			//    return ".debug.js";
		}

		public static string MergeTypeInformation(Type coreType, string fileShortName, ScriptMode mode)
		{
			if (coreType == null)
				throw new ArgumentNullException("coreType");
			if (string.IsNullOrEmpty(fileShortName))
				throw new ArgumentNullException("fileShortName");

			return string.Concat(coreType.Namespace, ".", fileShortName, (mode == ScriptMode.Debug) ? ".debug.js" : ".js");
		}

		#endregion
	}
}
