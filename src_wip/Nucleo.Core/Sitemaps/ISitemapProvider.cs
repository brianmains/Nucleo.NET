using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Sitemaps
{
	/// <summary>
	/// Represents the provider of the site map.
	/// </summary>
	public interface ISitemapProvider
	{
		/// <summary>
		/// Gets all of the site map items.
		/// </summary>
		/// <returns>The collection of site map items.</returns>
		SitemapItemCollection GetAllItems();

		/// <summary>
		/// Gets a site map item by the name of the item.
		/// </summary>
		/// <param name="location">The location of the item.</param>
		/// <returns>The site map item.</returns>
		SitemapItem GetByLocation(ISitemapLocation location);
	}
}
