using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.Tags;


namespace Nucleo.Web.Mvc
{
	public class WebRendererComponentWriter<TComponent> : BaseMvcComponentWriter<TComponent>
		where TComponent: BaseMvcComponent
	{
		#region " Methods "

		public override TagElement Render(TComponent component)
		{
			WebRenderer[] renderers = ControlRendering.GetWebRenderer(component);
			if (renderers != null && renderers.Length > 0)
				return renderers[0].Render();
			else
				throw new InvalidOperationException("The control being rendered does not have a WebRendererAttribute declaration at the class level.");
		}

		#endregion
	}
}
