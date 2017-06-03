using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;


namespace Nucleo.Web.Mvc.Elements.Forms
{
	public class HtmlForm
	{
		private string _actionName;
		private string _controllerName;
		private IDictionary<string, object> _htmlAttributes = null;
		private RouteValueDictionary _routeValues = null;



		#region " Properties "

		public string ActionName
		{
			get { return _actionName; }
			set { _actionName = value; }
		}

		public string ControllerName
		{
			get { return _controllerName; }
			set { _controllerName = value; }
		}

		public IDictionary<string, object> HtmlAttributes
		{
			get
			{
				if (_htmlAttributes == null)
					_htmlAttributes = new Dictionary<string, object>();

				return _htmlAttributes;
			}
			set { _htmlAttributes = value; }
		}

		public RouteValueDictionary RouteValues
		{
			get 
			{
				if (_routeValues == null)
					_routeValues = new RouteValueDictionary();

				return _routeValues; 
			}
			set { _routeValues = value; }
		}

		#endregion
	}
}
