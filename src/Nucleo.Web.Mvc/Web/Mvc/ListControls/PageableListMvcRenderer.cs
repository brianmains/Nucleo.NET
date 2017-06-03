using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ListControls;

namespace Nucleo.Web.Mvc.ListControls
{
	public class PageableListMvcRenderer : PageableListRenderer
	{
		private List<PageableListItemControlBuilder> _items = null;



		#region " Constructors "

		public PageableListMvcRenderer(List<PageableListItemControlBuilder> items)			
		{
			if (items == null)
				throw new ArgumentNullException("items");

			_items = items;
		}

		#endregion



		#region " Methods "

		protected override int GetItemCount()
		{
			return _items.Count;
		}

		protected override void RenderItemUI(int index, BaseControlWriter writer)
		{
			PageableListItemControlBuilder builder = this._items[index];
			PageableListItemMvcRenderer renderer = new PageableListItemMvcRenderer(builder);
			renderer.Render(writer);
		}

		#endregion
	}
}
