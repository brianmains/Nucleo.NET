using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web.Tags
{
	public class TagElementCollection : ReadonlyCollectionBase<TagElement>
	{
		#region " Properties "

		/// <summary>
		/// Gets the number of tags in the collection.
		/// </summary>
		public int TagCount
		{
			get { return this.Count; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Appends a tag to the collection.
		/// </summary>
		/// <param name="tag">The tag to append.</param>
		/// <remarks>Appends to the end.</remarks>
		/// <exception cref="ArgumentNullException">The exception to throw when the tag is null.</exception>
		public void AppendTag(TagElement tag)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");

			this.Add(tag);
		}

		/// <summary>
		/// Appends an array of tags to the collection.
		/// </summary>
		/// <param name="tags">The tags to append.</param>
		/// <remarks>Appends to the end.</remarks>
		/// <exception cref="ArgumentNullException">The exception to throw when the tags are null.</exception>
		public void AppendTags(params TagElement[] tags)
		{
			if (tags == null)
				throw new ArgumentNullException("tags");

			this.AddRange(tags);
		}

		/// <summary>
		/// Appends a collection of tags to the collection.
		/// </summary>
		/// <param name="tags">The tags to append.</param>
		/// <remarks>Appends to the end.</remarks>
		/// <exception cref="ArgumentNullException">The exception to throw when the tags are null.</exception>
		public void AppendTags(TagElementCollection tags)
		{
			if (tags == null)
				throw new ArgumentNullException("tags");

			this.AddRange(tags);
		}

		/// <summary>
		/// Clones the array of tags, returning the cloned array.  This does not include children by default.
		/// </summary>
		/// <returns>The cloned collection of tags.</returns>
		public TagElementCollection CloneTags()
		{
			return this.CloneTags(false);
		}

		/// <summary>
		/// Clones the array of tags, returning the cloned array.  This will clone a tag's children too.
		/// </summary>
		/// <param name="includeChildren">Whether to include the children in the clone.</param>
		/// <returns>The cloned collection of tags.</returns>
		public TagElementCollection CloneTags(bool includeChildren)
		{
			TagElementCollection list = new TagElementCollection();

			for (int index = 0, len = this.Count; index < len; index++)
				list.Add(this[index].CloneTag(includeChildren));

			return list;
		}

		/// <summary>
		/// Gets the tag by an index.
		/// </summary>
		/// <param name="index">The index to get with.</param>
		/// <returns>The tag at the index.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the index if out of the range of tags.</exception>
		/// <example>
		/// var foundTag = tag.Children.GetTag(0);
		/// </example>
		public TagElement GetTag(int index)
		{
			return this[index];
		}

		/// <summary>
		/// Gets a single tag by the tag name.
		/// </summary>
		/// <param name="tagName">The tag to find.</param>
		/// <returns>The found tag, or null if not found.</returns>
		/// <example>
		/// var foundTag = tag.Children.GetTag("SPAN");
		/// </example>
		public TagElement GetTag(string tagName)
		{
			for (int index = 0, len = this.Count; index < len; index++)
			{
				if (string.Compare(this[index].TagName, tagName, StringComparison.InvariantCultureIgnoreCase) == 0)
					return this[index];
			}

			return null;
		}

		/// <summary>
		/// Gets tags by its tag name, returning the results as a collection.
		/// </summary>
		/// <param name="tagName">The name of the tag.</param>
		/// <returns>The results.</returns>
		/// <example>
		/// var tags = tag.Children.GetTags("DIV");
		/// </example>
		public TagElementCollection GetTags(string tagName)
		{
			TagElementCollection tags = new TagElementCollection();

			for (int index = 0, len = this.Count; index < len; index++)
			{
				if (string.Compare(this[index].TagName, tagName, StringComparison.InvariantCultureIgnoreCase) == 0)
					tags.Add(this[index]);
			}

			return tags;
		}

		#endregion
	}
}
