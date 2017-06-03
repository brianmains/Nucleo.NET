using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nucleo.Collections;
using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.Context.Providers;
using Nucleo.Web.Context;
using Nucleo.Web.Context.Services;
using Nucleo.Web.Context.Providers;


namespace Nucleo.Models.Context
{
	public class SampleApplicationLoader : MvcApplicationContextServiceRegistry
	{
		#region " Methods "

		public override void LoadServices(TypeRegistry registry)
		{
			base.LoadServices(registry);

			registry.Register<ILoggerService>(new LoggerService());
			registry.Register<IStateManagementService>(new StateManagementService());
		}

		#endregion
	}
}
