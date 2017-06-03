using System;
using System.Web.UI;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Scripts.Configuration
{
	/// <summary>
	/// Represents the configuration of a script external to the Nucleo API.
	/// </summary>
	public class ExternalScriptElement : ConfigurationElementBase
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the assembly that the script resides in.
		/// </summary>
		[ConfigurationProperty("assembly")]
		public string Assembly
		{
			get { return (string)this["assembly"]; }
			set { this["assembly"] = value; }
		}

		/// <summary>
		/// Gets or sets the debug script path, for scripts that are referenced locally.
		/// </summary>
		[ConfigurationProperty("debugPath")]
		public string DebugPath
		{
			get { return (string)this["debugPath"]; }
			set { this["debugPath"] = value; }
		}

		/// <summary>
		/// Gets or sets the debug type of the script stored as an embedded resource.
		/// </summary>
		[ConfigurationProperty("debugType")]
		public string DebugType
		{
			get { return (string)this["debugType"]; }
			set { this["debugType"] = value; }
		}

		/// <summary>
		/// Gets or sets the name of the script used as the unique identifier.
		/// </summary>
		[ConfigurationProperty("name", IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
			set { this["name"] = value; }
		}

		/// <summary>
		/// Gets or sets the release script path, for scripts that are referenced locally.
		/// </summary>
		[ConfigurationProperty("releasePath")]
		public string ReleasePath
		{
			get { return (string)this["releasePath"]; }
			set { this["releasePath"] = value; }
		}

		/// <summary>
		/// Gets or sets the release type of the script stored as an embedded resource.
		/// </summary>
		[ConfigurationProperty("releaseType")]
		public string ReleaseType
		{
			get { return (string)this["releaseType"]; }
			set { this["releaseType"] = value; }
		}

		protected override string UniqueKey
		{
			get { return this.Name; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates an empty element.
		/// </summary>
		public ExternalScriptElement() { }

		/// <summary>
		/// Creates an element setup for the local path scenario.
		/// </summary>
		/// <param name="name">The unique identifier of the script.</param>
		/// <param name="debugPath">The debug path to the script stored locally.</param>
		/// <param name="releasePath">The release path to the script stored locally.</param>
		public ExternalScriptElement(string name, string debugPath, string releasePath)
		{
			this.Name = name;
			this.DebugPath = debugPath;
			this.ReleasePath = releasePath;
		}

		/// <summary>
		/// Creates an element setup for the embedded path scenario.
		/// </summary>
		/// <param name="name">The unique identifier of the script.</param>
		/// <param name="assembly">The assembly that stored the script.</param>
		/// <param name="debugType">The debug type name of the script as stored as an embedded resource.</param>
		/// <param name="releaseType">The release type name of the script as stored as an embedded resource.</param>
		public ExternalScriptElement(string name, string assembly, string debugType, string releaseType)
		{
			this.Name = name;
			this.Assembly = assembly;
			this.DebugType = debugType;
			this.ReleaseType = releaseType;
		}

		#endregion
	}
}
