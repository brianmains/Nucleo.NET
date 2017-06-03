using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Sitemaps
{
	/// <summary>
	/// Represents an item on a site map.  The item contains a pointer to a location.
	/// </summary>
	public class SitemapItem
	{
		private SitemapItemCollection _items = null;



		/// <summary>
		/// Gets the child items to this site map item.
		/// </summary>
		public SitemapItemCollection Items
		{
			get
			{
				if (_items == null)
					_items = new SitemapItemCollection();

				return _items;
			}
		}

		/// <summary>
		/// Gets or sets the location of the item for the site map entry.
		/// </summary>
		public ISitemapLocation Location
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the item in the sitemap.
		/// </summary>
		public string Name
		{
			get;
			set;
		}
	}
}