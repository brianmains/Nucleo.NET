using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.Tags;


namespace Nucleo.Web.Mvc
{
	public abstract class BaseMvcComponentWriter<TComponent>
		where TComponent: BaseMvcComponent
	{
		#region " Methods "

		public abstract TagElement Render(TComponent component);

		#endregion
	}
}
