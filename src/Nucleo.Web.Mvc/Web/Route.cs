using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

using Nucleo.ObjectModel;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a route in MVC.
	/// </summary>
	public class Route
	{
		private string _actionName = null;
		private string _controllerName = null;
		private IDictionary<string, object> _values = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the action for the route.
		/// </summary>
		public string ActionName
		{
			get { return _actionName; }
		}

		/// <summary>
		/// Gets the name of the controller for the route.
		/// </summary>
		public string ControllerName
		{
			get { return _controllerName; }
		}

		/// <summary>
		/// Gets the values for the route.
		/// </summary>
		public IDictionary<string, object> Values
		{
			get { return _values; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the route with no values.
		/// </summary>
		/// <param name="controllerName">The controller.</param>
		/// <param name="actionName">The action.</param>
		public Route(string controllerName, string actionName)
		{
			_controllerName = controllerName;
			_actionName = actionName;
		}

		/// <summary>
		/// Creates the route with values.
		/// </summary>
		/// <param name="controllerName">The controller.</param>
		/// <param name="actionName">The action.</param>
		/// <param name="values">The routing values.</param>
		public Route(string controllerName, string actionName, object values)
			: this(controllerName, actionName)
		{
			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(values);

			_values = reader.Attributes;
		}

		/// <summary>
		/// Creates the route with values.
		/// </summary>
		/// <param name="controllerName">The controller.</param>
		/// <param name="actionName">The action.</param>
		/// <param name="values">The routing values.</param>
		public Route(string controllerName, string actionName, IDictionary<string, object> values)
			: this(controllerName, actionName)
		{
			_values = values;
		}

		#endregion
	}
}
