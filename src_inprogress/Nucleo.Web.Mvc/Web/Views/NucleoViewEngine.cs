using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Hosting;
using System.Collections.Generic;

using Nucleo.Collections;
using Nucleo.Web.Mvc.Configuration;
using Nucleo.Web.Views.Configuration;


namespace Nucleo.Web.Views
{
	public class NucleoViewEngine : WebFormViewEngine
	{
		#region " Constructors "

		protected NucleoViewEngine() { }

		#endregion



		#region " Methods "

		private StringCollection AddViewPath(string viewPath, string sharedPath, bool searchSubdirectories)
		{
			StringCollection list = new StringCollection();
			list.Add(VirtualizePath(string.Concat(viewPath, (viewPath.EndsWith(@"/") ? "" : @"/"), "{0}.ascx"), viewPath));
			list.Add(VirtualizePath(string.Concat(sharedPath, (sharedPath.EndsWith(@"/") ? "" : @"/"), "{0}.ascx"), sharedPath));

			if (searchSubdirectories)
			{
				var childDirectories = this.GetChildDirectories(viewPath);

				foreach (VirtualDirectory childDirectory in childDirectories)
				{
					list.Add(VirtualizePath(childDirectory.VirtualPath.Substring(
						childDirectory.VirtualPath.IndexOf(@"/", 2)), viewPath) + "{0}.ascx");
				}
			}

			return list;
		}

		public static NucleoViewEngine Create()
		{
			NucleoViewEngine engine = new NucleoViewEngine();
			engine.InitializePaths();

			return engine;
		}

		private IEnumerable<VirtualDirectory> GetChildDirectories(string rootDirectory)
		{
			var directory = this.VirtualPathProvider.GetDirectory(rootDirectory);
			return directory.Directories.Cast<VirtualDirectory>();
		}

		protected virtual void InitializePaths()
		{
			MvcSettingsSection settings = MvcSettingsSection.Instance;
			ViewSettingsElement viewSettings = null;

			if (settings != null)
				viewSettings = settings.ViewSettings;

			if (viewSettings != null)
			{
				string viewPath = !string.IsNullOrEmpty(viewSettings.ViewPath) ? viewSettings.ViewPath : "~/Views";
				string partialViewPath = !string.IsNullOrEmpty(viewSettings.PartialViewPath) ? viewSettings.PartialViewPath : "~/Views";
				string sharedPath = !string.IsNullOrEmpty(viewSettings.SharedViewPath) ? viewSettings.SharedViewPath : "~/Views/Shared";
#if MVC2
				string areasPath = !string.IsNullOrEmpty(viewSettings.AreasViewPath) ? viewSettings.AreasViewPath : "~/Areas";
#endif

				StringCollection list = new StringCollection();
				//list.AddRange(this.AddViewPath(viewPath, sharedPath, false).ToArray());
				list.AddRange(this.AddViewPath(partialViewPath, sharedPath, viewSettings.SearchPartialViewSubfolders).ToArray());

				base.ViewLocationFormats = new string[]
				{
					viewPath + "/{1}/{0}.aspx",
					sharedPath + "/{0}.aspx"
				};

				base.PartialViewLocationFormats = list.ToArray();

				base.MasterLocationFormats = new string[]
				{
					viewPath + "/{1}/{0}.master",
					sharedPath + "/{0}.master"
				};

#if MVC2
				base.AreaViewLocationFormats = new string[]
				{
					areasPath + "/{2}/" + viewPath.Substring(2) + "/{1}/{0}.aspx",
					areasPath + "/{2}/" + sharedPath.Substring(2) + "/{0}.aspx"
				};

				base.AreaPartialViewLocationFormats = list.Cast<string>().Each<string, string>(s => areasPath + "/{2}/" + s.Substring(1)).ToArray();

				base.AreaMasterLocationFormats = new string[]
				{
					areasPath +"/{2}/" + viewPath.Substring(2) + "/{1}/{0}.master",
					areasPath +"/{2}/" + sharedPath.Substring(2) + "/{0}.master"
				};
#endif
			}
			else
			{
				base.ViewLocationFormats = new string[]
				{
					"~/Views/{1}/{0}.aspx",
					"~/Views/Shared/{0}.aspx"
				};
				base.PartialViewLocationFormats = new string[]
				{
					"~/Views/{1}/{0}.ascx",
					"~/Views/Shared/{0}.ascx"
				};
				base.MasterLocationFormats = new string[]
				{
					"~/Views/{1}/{0}.master",
					"~/Views/Shared/{0}.master"
				};

#if MVC2
				base.AreaViewLocationFormats = new string[]
				{
					"~/Areas/{2}/Views/{1}/{0}.aspx",
					"~/Areas/{2}/Views/Shared/{0}.aspx"
				};
				base.AreaPartialViewLocationFormats = new string[]
				{
					"~/Areas/{2}/Views/{1}/{0}.ascx",
					"~/Areas/{2}/Views/Shared/{0}.ascx"
				};
				base.AreaMasterLocationFormats = new string[]
				{
					"~/Areas/{2}/Views/{1}/{0}.master",
					"~/Areas/{2}/Views/Shared/{0}.master"
				};
#endif
			}
		}

		/// <summary>
		/// Gets the virtualized path; if the path starts with ~/, the path is returned.  Otherwise, this is created.  Paths often come in as /VirtualDir/Folder/file.aspx, so the /VirtualDir is removed.
		/// </summary>
		/// <param name="path">The path to virtualize.</param>
		/// <returns>The virtualized path.</returns>
		protected virtual string VirtualizePath(string path, string pathPrefix)
		{
			if (string.IsNullOrEmpty(path))
				return null;
			if (path.StartsWith("~/"))
				return path;

			return "~" + path;
			//return "~" + path.Substring(path.IndexOf(pathPrefix));
		}

		#endregion
	}
}
