using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.Tags
{
	public class TagElementWizard
	{
		private TagElement _tag = null;



		#region " Constructors "

		public TagElementWizard(TagElement tag)
		{
			_tag = tag;
		}

		#endregion



		#region " Methods "

		public TagElementWizard Attributes(IDictionary<string, object> attributes)
		{
			_tag.Attributes.AppendAttributes(attributes);
			return this;
		}

		public TagElementWizard Attributes(IEnumerable<TagAttribute> attributes)
		{
			_tag.Attributes.AppendAttributes(attributes);
			return this;
		}

		public TagElementWizard Attributes(Action<TagAttributeCollection> attributes)
		{
			attributes(_tag.Attributes);
			return this;
		}

		public TagElementWizard Children(TagElementCollection tags)
		{
			_tag.Children.AppendTags(tags);
			return this;
		}

		public TagElementWizard Children(Action<TagElementCollection> children)
		{
			children(_tag.Children);
			return this;
		}

		public TagElementWizard Content(string content)
		{
			_tag.Content = content;
			return this;
		}
		
		public TagElement Create()
		{
			return _tag;
		}

		public TagElementWizard Styles(IDictionary<string, object> attributes)
		{
			_tag.Styles.AppendAttributes(attributes);
			return this;
		}

		public TagElementWizard Styles(IEnumerable<TagAttribute> attributes)
		{
			_tag.Styles.AppendAttributes(attributes);
			return this;
		}

		public TagElementWizard Styles(Action<TagAttributeCollection> attributes)
		{
			attributes(_tag.Styles);
			return this;
		}

		#endregion
	}
}
