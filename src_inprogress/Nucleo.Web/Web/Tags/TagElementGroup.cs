using System;
using System.Collections.Generic;
using System.Text;

using Nucleo.ObjectModel;


namespace Nucleo.Web.Tags
{
	public class TagElementGroup
	{
		private TagElementCollection _tags = null;



		#region " Properties "

		/// <summary>
		/// Gets the collection of tags within the group.
		/// </summary>
		public TagElementCollection Tags
		{
			get { return _tags; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the group using the collection of tags.
		/// </summary>
		/// <param name="tags">The tags to use for the group.</param>
		public TagElementGroup(TagElementCollection tags)
		{
			_tags = tags;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Applies the attributes of the supplied object to all of the tags within the group.
		/// </summary>
		/// <param name="attributes">The attributes to copy.</param>
		public void ApplyAttributes(object attributes)
		{
			ApplyAttributes(attributes, null);
		}

		/// <summary>
		/// Applies the attributes of the supplied object to some of the tags within the group.  Uses the rule to determine which tags to use, or a null rule means all.
		/// </summary>
		/// <param name="attributes">The attributes to copy.</param>
		public void ApplyAttributes(object attributes, TagGroupRule rule)
		{
			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(attributes);

			for (int index = 0, len = this.Tags.Count; index < len; index++)
			{
				if (rule == null || rule.IsForTag(this.Tags[index], index))
					this.Tags[index].Attributes.CopyFrom(reader.Attributes);
			}
		}

		/// <summary>
		/// Applies the attributes of the supplied object to all of the tags within the group.
		/// </summary>
		/// <param name="attributes">The attributes to copy.</param>
		public void ApplyAttributes(IDictionary<string, object> attributes)
		{
			ApplyAttributes(attributes, null);
		}

		/// <summary>
		/// Applies the attributes of the supplied object to some of the tags within the group.  The rule determines which elements, or a null rule means all.
		/// </summary>
		/// <param name="attributes">The attributes to copy.</param>
		public void ApplyAttributes(IDictionary<string, object> attributes, TagGroupRule rule)
		{
			for (int index = 0, len = this.Tags.Count; index < len; index++)
			{
				this.Tags[index].Attributes.CopyFrom(attributes);
			}
		}

		#endregion
	}
}
