using System;
using Nucleo.Collections;


namespace Nucleo.Web.Repeating
{
	public class LayoutRow
	{
		private SimpleCollection<LayoutItem> _items = null;



		#region " Properties "

		public SimpleCollection<LayoutItem> Items
		{
			get
			{
				if (_items == null)
					_items = new SimpleCollection<LayoutItem>();
				return _items;
			}
		}

		#endregion
	}
}
