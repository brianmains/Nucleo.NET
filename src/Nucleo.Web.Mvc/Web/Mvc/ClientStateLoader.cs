using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Nucleo.Web.ClientState;


namespace Nucleo.Web.Mvc
{
	public static class ClientStateLoader
	{
		#region " Methods "

		public static TBuilder LoadComponent<TComponent, TBuilder>(string json)
			where TComponent: BaseMvcComponent
			where TBuilder: BaseMvcComponentBuilder<TComponent, TBuilder>
		{
			TBuilder builder = Activator.CreateInstance<TBuilder>();
			builder.LoadFromJson(json);

			return builder;
		}

		#endregion
	}
}
