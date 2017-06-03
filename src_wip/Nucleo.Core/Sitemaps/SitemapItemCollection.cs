using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Collections;


namespace Nucleo.Sitemaps
{
	/// <summary>
	/// Represents a collection of site map items.
	/// </summary>
	public class SitemapItemCollection : SimpleCollection<SitemapItem>
	{
		public void AddRange(IEnumerable<SitemapItem> items)
		{
			Guard.NotNull(items);

			foreach (var item in items)
				this.Add(item);
		}
	}
}
