using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Microsoft.Practices.Unity;
using System.Web.Routing;


namespace Nucleo.Web.Controllers
{
	/// <summary>
	/// Represents a controller factory that uses unity to inject references into the constructor.
	/// </summary>
	public class UnityControllerFactory : DefaultControllerFactory
	{
		IUnityContainer _container;



		#region " Constructors "

		/// <summary>
		/// Creates the factory with the given container.
		/// </summary>
		/// <param name="container">The container definition.</param>
		public UnityControllerFactory(IUnityContainer container)
		{
			_container = container;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Injects any references into the controller upon creating it, ensuring that the controller is of a given type.
		/// </summary>
		/// <param name="requestContext">The current request context.</param>
		/// <param name="controllerType">The type of controller to create.</param>
		/// <exception cref="ArgumentNullException">Thrown when the controller type is null.</exception>
		/// <exception cref="ArgumentException">Thrown when the controller is of the wrong type.</exception>
		/// <returns></returns>
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
				throw new ArgumentNullException("controllerType");

			if (!typeof(IController).IsAssignableFrom(controllerType))
				throw new ArgumentException(string.Format(
					"The given type is not a controller: {0}.", controllerType.FullName), "controllerType");

			return _container.Resolve(controllerType) as IController;
		}

		#endregion
	}
}
