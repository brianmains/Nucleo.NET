using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.Tags;


namespace Nucleo.Web.Mvc.ListControls
{
	public class PageableListItemMvcRenderer
	{
		private PageableListItemControlBuilder _control = null;



		#region " Constructors "

		public PageableListItemMvcRenderer(PageableListItemControlBuilder control)
		{
			_control = control;
		}

		#endregion



		#region " Methods "

		public void Render(BaseControlWriter writer)
		{
			TagElement tag = TagElementBuilder.Create("LABEL");
			writer.Write(tag.ToHtmlString(TagRenderingMode.BeginTag));

			ControlRendering.RenderTemplate(_control.Template, writer);

			writer.Write(tag.ToHtmlString(TagRenderingMode.EndTag));
		}

		#endregion
	}
}
