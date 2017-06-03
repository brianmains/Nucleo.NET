using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Nucleo.Lookups
{
	public static class LookupCollectionExtensions
	{
		#region " Methods "

		/// <summary>
		/// Converts a looukp to a collection of select list items.
		/// </summary>
		/// <param name="lookups">The collection of lookups.</param>
		/// <returns>The collection of select items.</returns>
		public static IEnumerable<SelectListItem> ToListItems(this LookupCollection lookups)
		{
			List<SelectListItem> items = new List<SelectListItem>();

			foreach (Lookup lookup in lookups)
			{
				items.Add(new SelectListItem
				{
					Text = lookup.Name,
					Value = lookup.Value
				});
			}

			return items;
		}

		#endregion
	}
}
