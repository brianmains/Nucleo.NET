using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web.Tags
{
	public class TagGroupSettings
	{
		private ObjectKeyedDictionary _attributes = null;
		private TagGroupRule _rule = null;



		#region " Properties "

		public ObjectKeyedDictionary Attributes
		{
			get
			{
				if (_attributes == null)
					_attributes = new ObjectKeyedDictionary();
				return _attributes;
			}
		}

		public TagGroupRule Rule
		{
			get { return _rule; }
		}

		#endregion



		#region " Constructors "

		public TagGroupSettings(TagGroupRule rule)
		{
			_rule = rule;
		}

		#endregion
	}
}
