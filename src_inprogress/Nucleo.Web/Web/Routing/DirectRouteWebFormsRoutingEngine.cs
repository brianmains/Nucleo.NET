using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Routing
{
	public class DirectRouteWebFormsRoutingEngine : BaseWebFormsRoutingEngine
	{
		#region " Constructors "

		public DirectRouteWebFormsRoutingEngine(string viewPath, string sharedViewPath)
			: base(viewPath, sharedViewPath) { }

		#endregion



		#region " Methods "

		public override bool IsForSource(object routingSource)
		{
			return (routingSource is DirectRoute);
		}

		private string GetDirectRoutePath(DirectRoute route)
		{
			string path = @"~/";

			if (route.IsShared)
				path += this.SharedViewPath;
			else
				path += this.ViewPath;

			if (!path.EndsWith(@"/"))
				path += @"/";

			if (!string.IsNullOrEmpty(route.Area))
				path += route.Area + "/";

			path += route.View + ".aspx";

			return path;
		}

		public override void Navigate(object routingSource)
		{
			if (routingSource is DirectRoute)
			{
				var route = (DirectRoute)routingSource;
				//Navigate
				var path = this.GetDirectRoutePath(route);

			}
		}

		#endregion
	}
}
