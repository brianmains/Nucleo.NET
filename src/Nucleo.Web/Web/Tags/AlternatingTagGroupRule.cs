using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.Tags
{
	public class AlternatingTagGroupRule : TagGroupRule
	{
		private bool _matchEvenTags = false;



		#region " Constructors "

		public AlternatingTagGroupRule(bool matchEvenTags)
		{
			_matchEvenTags = matchEvenTags;
		}

		#endregion



		#region " Methods "

		public override bool IsForTag(TagElement element, int index)
		{
			return (index % 2 == 0);
		}

		#endregion
	}
}
