using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Web.Tags
{
	public static class TagElementCollectionExtensions
	{
		#region " Methods "

		public static IEnumerable<TagElement> GetTags(this TagElementCollection list, Func<TagElement, bool> expression)
		{
			List<TagElement> outputList = new List<TagElement>();

			for (int index = 0, len = list.Count; index < len; index++)
			{
				if (expression(list[index]))
					outputList.Add(list[index]);
			}

			return outputList.ToArray();
		}

		#endregion
	}
}
