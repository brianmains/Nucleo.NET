﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

using Nucleo.Routing;
using Nucleo.Views;


namespace Nucleo.Web.Routing
{
	/// <summary>
	/// Uses the path of the view to convert a URL.  Takes the type of the view and translates it to a URL, using the namespace of the type.  The view implementation of the interface is dynamically parsed from the available assemblies.  To change the defaults, provide the new values at construction.
	/// </summary>
	/// <remarks>For instance, if the view is defined as Nucleo.Web.RouteTest.IMyPageView, and the default path is ~/Web and the RootNamespace is Web, this translates to a URL of ~/Web/RouteTest/MyPage.aspx.</remarks>
	public class ViewConventionRoutingEngine : IRoutingEngine
	{
		#region " Properties "

		public virtual string DefaultExtension
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the default path of the views folder; defaults to "~/Views".
		/// </summary>
		public virtual string DefaultPath
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the default namespace for the View type; defaults to "Views".
		/// </summary>
		public virtual string ViewNamespace
		{
			get;
			private set;
		}

		#endregion



		#region  " Constructors "

		/// <summary>
		/// Creates the routing engine with the defaults.
		/// </summary>
		public ViewConventionRoutingEngine()
			: this("~/Views", "Views") { }

		/// <summary>
		/// Creates the routing engine, allowing the defaults to be overridden.
		/// </summary>
		/// <param name="defaultPath">The default path to the views folder using relative terms (ie. ~/Views).  Do not put an ending / in the path.</param>
		/// <param name="viewNamespace">The default namespace segment for views.  For instance, views may be named MyNS.Views; in this case, only the Views term is needed.</param>
		public ViewConventionRoutingEngine(string defaultPath, string viewNamespace, string defaultExtension = ".aspx")
		{
			this.DefaultPath = defaultPath ?? "";
			this.ViewNamespace = viewNamespace ?? "";
			this.DefaultExtension = defaultExtension ?? ".aspx";
		}

		#endregion



		#region " Methods "

		protected virtual Type FindViewTypeInAppDomain(Type viewType)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(i => !i.FullName.StartsWith("mscorlib") && !i.FullName.StartsWith("System") && !i.FullName.StartsWith("Microsoft"));

			foreach (Assembly a in assemblies)
			{
				var type = a.GetTypes().FirstOrDefault(i => i.GetInterface(viewType.Name) != null);
				if (type != null)
					return type;
			}

			return null;
		}

		/// <summary>
		/// Determines if the routing source is a type, and that type is for a view.
		/// </summary>
		/// <param name="routingSource"></param>
		/// <returns></returns>
		public bool IsForSource(object routingSource)
		{
			if (routingSource == null)
				throw new ArgumentNullException("routingSource");

			return (routingSource is Type) && (((Type)routingSource).GetInterface("IView") != null);
		}

		public void Navigate(object routingSource)
		{
			var type = (Type)routingSource;
			var viewType = FindViewTypeInAppDomain(type);

			List<string> paths = viewType.FullName.Split('.').ToList();
			bool started = false;
			string finalPath = this.DefaultPath;

			if (this.ViewNamespace.Contains("."))
			{
				string[] viewNamespaceParts = this.ViewNamespace.Split('.');
				if (paths.Count < viewNamespaceParts.Length)
					throw new InvalidOperationException("The view namespace is filtering out too much of the given path.");

				//Remove the parts from the path
				paths.RemoveRange(0, viewNamespaceParts.Length);
			}

			foreach (string path in paths)
			{
				//if (path == this.ViewNamespace)
				//    started = true;
				//else if (started == true)
				//{
					finalPath += @"/" + path;
				//}
			}

			finalPath += this.DefaultExtension;

			try
			{
				//Redirect to view path
				HttpContext.Current.Response.Redirect(finalPath);
			}
			catch (System.Threading.ThreadAbortException tex)
			{
				//Do nothing because this can happen upon redirection
			}
		}

		#endregion
	}
}
