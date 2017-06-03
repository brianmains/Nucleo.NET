using System;
using System.Web.Mvc;
using System.Web.Routing;

using Nucleo.Configuration;
using Nucleo.Context;
using Nucleo.Web.Controllers.Configuration;


namespace Nucleo.Web.Controllers
{
	public class NucleoControllerFactory : DefaultControllerFactory
	{
		private ControllerActionInvoker _actionInvoker = null;
		private IControllerServer _server = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the action invoker to use for controllers.
		/// </summary>
		public ControllerActionInvoker ActionInvoker
		{
			get { return _actionInvoker; }
			set { _actionInvoker = value; }
		}

		/// <summary>
		/// Gets or sets the server to serve up controller requests.
		/// </summary>
		public IControllerServer Server
		{
			get { return _server; }
			set { _server = value; }
		}

		#endregion



		#region " Constructors "

		protected NucleoControllerFactory() { }

		#endregion



		#region " Methods "

		public static NucleoControllerFactory Create()
		{
			NucleoControllerFactory factory = new NucleoControllerFactory();
			factory.LoadFromConfig();
			return factory;
		}

		public static NucleoControllerFactory Create(ControllerActionInvoker invoker, IControllerServer server)
		{
			NucleoControllerFactory factory = new NucleoControllerFactory();
			factory._actionInvoker = invoker;
			factory._server = server;

			return factory;
		}

		public override IController CreateController(RequestContext requestContext, string controllerName)
		{
			if (requestContext == null)
				throw new ArgumentNullException("requestContext");
			if (string.IsNullOrEmpty(controllerName))
				throw new ArgumentNullException("controllerName");

#if MVC1
			this.RequestContext = requestContext;
#endif
			IController controller = this.GetControllerReference(requestContext, controllerName);

			if (controller != null)
			{
				if (controller is Controller)
					this.SetupControllerActionInvoker((Controller)controller);
				if (controller is NucleoController)
					this.SetupContext((NucleoController)controller);
			}

			return controller;
		}

		/// <summary>
		/// Loads a controller by its name, getting the type, and then instantiating the controller instance.
		/// </summary>
		/// <param name="controllerName">The name of the controller.</param>
		/// <returns>The controller reference, or null if the controller wasn't found.</returns>
		protected virtual IController GetControllerReference(RequestContext context, string controllerName)
		{
			Type controllerType = null;
			if (this.Server != null)
				return this.Server.GetControllerReference(context, controllerName);
			
#if MVC1
			controllerType = this.GetControllerType(controllerName);
#else
			controllerType = this.GetControllerType(context, controllerName);
#endif
			if (controllerType == null)
				return null;
			
#if MVC1
			return this.GetControllerInstance(controllerType);
#else
			return this.GetControllerInstance(context, controllerType);
#endif
		}

		private void LoadFromConfig()
		{
			ControllerSettingsSection section = ControllerSettingsSection.Instance;

			if (section != null)
			{
				if (!string.IsNullOrEmpty(section.DefaultActionInvokerType))
					_actionInvoker = (ControllerActionInvoker)Activator.CreateInstance(Type.GetType(section.DefaultActionInvokerType));
				if (!string.IsNullOrEmpty(section.DefaultServerType))
					_server = (IControllerServer)Activator.CreateInstance(Type.GetType(section.DefaultServerType));
			}
		}

		protected virtual void SetupContext(NucleoController controller)
		{
			controller.Context = new MvcRequestContext();
		}

		protected virtual void SetupControllerActionInvoker(Controller controller)
		{
			controller.ActionInvoker = this.ActionInvoker ?? new NucleoActionInvoker();
		}

		#endregion
	}
}
