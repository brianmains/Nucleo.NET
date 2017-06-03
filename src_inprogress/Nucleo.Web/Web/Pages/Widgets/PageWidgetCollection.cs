using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web.Pages.Widgets
{
	public class PageWidgetCollection : SimpleCollection<PageWidget>
	{
		#region " Constructors "

		public PageWidgetCollection() { }

		public PageWidgetCollection(PageWidget widget)
		{
			this.Add(widget);
		}

		public PageWidgetCollection(IEnumerable<PageWidget> widgets)
		{
			foreach (PageWidget widget in widgets)
				this.Add(widget);
		}

		#endregion



		#region " Methods "



		#endregion
	}
}
