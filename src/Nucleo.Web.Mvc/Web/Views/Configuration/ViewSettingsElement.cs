using System;
using System.Configuration;
using Nucleo.Configuration;


namespace Nucleo.Web.Views.Configuration
{
	/// <summary>
	/// Represents the collection of view element settings.
	/// </summary>
	public class ViewSettingsElement : ConfigurationElement
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the view path for the areas feature.
		/// </summary>
		[ConfigurationProperty("areasViewPath", DefaultValue = "~/Areas")]
		public string AreasViewPath
		{
			get { return (string)this["areasViewPath"]; }
			set { this["areasViewPath"] = value; }
		}

		/// <summary>
		/// Gets or sets the view path to the partial view collection.
		/// </summary>
		[ConfigurationProperty("partialViewPath", DefaultValue = "~/Views")]
		public string PartialViewPath
		{
			get { return (string)this["partialViewPath"]; }
			set { this["partialViewPath"] = value; }
		}

		/// <summary>
		/// Gets or sets whether to include subfolders for partial views, to allow for further separation of partial view logic.
		/// </summary>
		[ConfigurationProperty("searchPartialViewSubfolders", DefaultValue = false)]
		public bool SearchPartialViewSubfolders
		{
			get { return (bool)this["searchPartialViewSubfolders"]; }
			set { this["searchPartialViewSubfolders"] = value; }
		}

		/// <summary>
		/// Gets or sets the path to the shared folder.
		/// </summary>
		[ConfigurationProperty("sharedViewPath", DefaultValue = "~/Views/Shared")]
		public string SharedViewPath
		{
			get { return (string)this["sharedViewPath"]; }
			set { this["sharedViewPath"] = value; }
		}

		/// <summary>
		/// Get sor sets the path to the views folder.
		/// </summary>
		[ConfigurationProperty("viewPath", DefaultValue = "~/Views")]
		public string ViewPath
		{
			get { return (string)this["viewPath"]; }
			set { this["viewPath"] = value; }
		}

		#endregion
	}
}
