using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;


namespace Nucleo.Web.Controllers
{
	/// <summary>
	/// Represents a simple controller factory implementation.
	/// </summary>
	public class FakeControllerFactory : DefaultControllerFactory
	{
		private IDictionary<string, IController> _controllerMappings = null;



		#region " Properties "

		/// <summary>
		/// Gets the collection of controller mappings.
		/// </summary>
		public IDictionary<string, IController> ControllerMappings
		{
			get
			{
				if (_controllerMappings == null)
					_controllerMappings = new Dictionary<string, IController>();
				return _controllerMappings;
			}
		}

		#endregion



		#region " Controllers "

		public FakeControllerFactory()
			: base() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates a new controller from a given type.
		/// </summary>
		/// <param name="requestContext">The request context instance.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <returns>The controller instance.</returns>
		public override IController CreateController(RequestContext requestContext, string controllerName)
		{
			if (this.ControllerMappings.ContainsKey(controllerName))
				return this.ControllerMappings[controllerName];

			return null;
		}

		#endregion
	}
}
