using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Reflection;

using Nucleo.Routing;


namespace Nucleo.Web.Routing
{
	/// <summary>
	/// Uses the path of the page to convert a URL.  Takes the type of the page and translates it to a URL, using the namespace of the type.  To change the defaults, provide the new values at construction.
	/// </summary>
	/// <remarks>For instance, if a page is defined as Nucleo.Web.RouteTest.MyPage, and the default path is ~/Web and the RootNamespace is Web, this translates to a URL of ~/Web/RouteTest/MyPage.aspx.</remarks>
	public class PageConventionRoutingEngine : IRoutingEngine
	{
		#region " Properties "

		/// <summary>
		/// Gets the default path of the pages folder; defaults to "~/Pages".
		/// </summary>
		public virtual string DefaultPath
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the default namespace segment for the page type; defaults to "Pages".
		/// </summary>
		public virtual string RootNamespace
		{
			get;
			private set;
		}

		#endregion



		#region  " Constructors "

		/// <summary>
		/// Creates the routing engine with the defaults.
		/// </summary>
		public PageConventionRoutingEngine()
		{
			DefaultPath = "~/Pages";
			RootNamespace = "Pages";
		}

		/// <summary>
		/// Creates the routing engine, allowing the defaults to be overridden.
		/// </summary>
		/// <param name="defaultPath">The default path to the views folder using relative terms (ie. ~/Views).  Do not put an ending / in the path.</param>
		/// <param name="viewNamespace">The default namespace segment for views.  For instance, views may be named MyNS.Views; in this case, only the Views term is needed.</param>
		public PageConventionRoutingEngine(string defaultPath, string viewNamespace)
		{
			this.DefaultPath = defaultPath;
			this.RootNamespace = viewNamespace;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Determines if the routing source is a type, and that type is for an ASP.NET page.
		/// </summary>
		/// <param name="routingSource"></param>
		/// <returns></returns>
		public bool IsForSource(object routingSource)
		{
			if (routingSource == null)
				throw new ArgumentNullException("routingSource");

			return (routingSource is Type) && typeof(Page).IsAssignableFrom((Type)routingSource);
		}

		public void Navigate(object routingSource)
		{
			var type = (Type)routingSource;

			string[] paths = (type).FullName.Split('.');
			bool started = false;
			string finalPath = this.DefaultPath;

			foreach (string path in paths)
			{
				if (path == this.RootNamespace)
					started = true;
				else if (started == true)
				{
					finalPath += @"/" + path;
				}
			}

			finalPath += ".aspx";

			//Redirect to view path
			HttpContext.Current.Response.Redirect(finalPath);
		}

		#endregion
	}
}
