using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Routing;


namespace Nucleo.Web.Routing
{
	public abstract class BaseWebFormsRoutingEngine : IRoutingEngine
	{
		private string _sharedViewPath = null;
		private string _viewPath = null;



		#region " Properties "

		protected string SharedViewPath
		{
			get { return _sharedViewPath; }
		}

		protected string ViewPath
		{
			get { return _viewPath; }
		}

		#endregion



		#region " Constructors "

		public BaseWebFormsRoutingEngine(string viewPath, string sharedViewPath)
		{
			_viewPath = viewPath;
			_sharedViewPath = sharedViewPath;
		}

		#endregion



		#region " Methods "

		public abstract bool IsForSource(object routingSource);

		public abstract void Navigate(object routingSource);

		#endregion
	}
}