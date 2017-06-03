using System;
using System.Collections.Generic;

using Nucleo.ObjectModel;


namespace Nucleo.Web.Tags
{
	/// <summary>
	/// Responsible for building tag elements.  Use this object over creating the elements directly.
	/// </summary>
	public class TagElementBuilder
	{
		#region " Constructors "

		/// <summary>
		/// Creates the builder internally.
		/// </summary>
		private TagElementBuilder() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates a tag with a specified tag name.
		/// </summary>
		/// <param name="tagName">The name of the tag.</param>
		/// <returns>The tag element reference.</returns>
		/// <example>
		/// var tag = TagElementBuilder.Create("DIV");
		/// </example>
		public static TagElement Create(string tagName)
		{
			return new TagElement(tagName);
		}

		/// <summary>
		/// Creates a tag with a specified tag name and its content.
		/// </summary>
		/// <param name="tagName">The name of the tag.</param>
		/// <param name="content">The tag's inner content.</param>
		/// <returns>The tag element reference.</returns>
		/// <example>
		/// var tag = TagElementBuilder.Create("DIV", "This is my inner contents");
		/// </example>
		public static TagElement Create(string tagName, string content)
		{
			return new TagElement(tagName, content);
		}

		/// <summary>
		/// Creates a tag with a specified tag name and its attributes.
		/// </summary>
		/// <param name="tagName">The name of the tag.</param>
		/// <param name="attributes">The attributes of the tag.</param>
		/// <returns>The tag element reference.</returns>
		/// <example>
		/// var tag = TagElementBuilder.Create("DIV", new { Width = "500px", Height = "500px" });
		/// </example>
		public static TagElement Create(string tagName, object attributes)
		{
			TagElement element = new TagElement(tagName);
			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(attributes);

			element.Attributes.CopyFrom(reader.Attributes);

			return element;
		}

		/// <summary>
		/// Creates a tag with a specified tag name and its attributes.
		/// </summary>
		/// <param name="tagName">The name of the tag.</param>
		/// <param name="attributes">The attributes of the tag.</param>
		/// <returns>The tag element reference.</returns>
		/// <example>
		/// var attrib = new Dictionary&lt;string, object>();
		/// attrib.Add("class", "mycssclass");
		/// attrib.Add("width", "500px");
		/// attrib.Add("height", "500px");
		/// var tag = TagElementBuilder.Create("DIV", attrib);
		/// </example>
		public static TagElement Create(string tagName, Dictionary<string, object> attributes)
		{
			TagElement element = new TagElement(tagName);
			element.Attributes.CopyFrom<object>(attributes);

			return element;
		}

		/// <summary>
		/// Creates a tag using a custom tag builder.  Several custom tag builders already exist within the <see cref="Nucleo.Web.Tags.Custom">Custom namespace</see>.
		/// </summary>
		/// <param name="tagBuilder">The tag builder to create the UI.</param>
		/// <returns>The tag element reference.</returns>
		/// <example>
		/// var tag = TagElementBuilder.Create(HiddenTagBuilder.Create("keyfield", "1"));
		/// </example>
		public static TagElement Create(Custom.ICustomTagBuilder tagBuilder)
		{
			return tagBuilder.ToElement();
		}

		/// <summary>
		/// Creates a group of tags with the specified array of tag names.
		/// </summary>
		/// <param name="tagNames">The tag names to create.</param>
		/// <returns>The group of tag elements.</returns>
		/// <example>
		/// var tags = TagElementBuilder.CreateGroup(new[] { "SPAN", "DIV", "SPAN", "DIV" });
		/// </example>
		public static TagElementGroup CreateGroup(string[] tagNames)
		{
			TagElementCollection tagElements = new TagElementCollection();

			for (int index = 0, len = tagNames.Length; index < len; index++)
				tagElements.AppendTag(new TagElement(tagNames[index]));

			return new TagElementGroup(tagElements);
		}

		/// <summary>
		/// Creates a group of tags with a single tag name, using the count to specify the number of tags to create.
		/// </summary>
		/// <param name="tagName">The tag name to use to create all of the tags.</param>
		/// <param name="tagCount">The total number of tags to create.</param>
		/// <returns>The group of tag elements.</returns>
		/// <example>
		/// var tags = TagElementBuilder.CreateGroup("DIV", 5);
		/// </example>
		public static TagElementGroup CreateGroup(string tagName, int tagCount)
		{
			TagElementCollection tagElements = new TagElementCollection();

			for (int index = 0; index < tagCount; index++)
				tagElements.AppendTag(new TagElement(tagName));

			return new TagElementGroup(tagElements);
		}

		/// <summary>
		/// Creates a group of tags with a single tag name, using the count to specify the number of tags to create.  Applies the attributes to all of the tags.
		/// </summary>
		/// <param name="tagName">The tag name to use to create all of the tags.</param>
		/// <param name="tagCount">The total number of tags to create.</param>
		/// <param name="attributes">The attributes to apply.</param>
		/// <returns>The group of tag elements.</returns>
		/// <example>
		/// var tags = TagElementBuilder.CreateGroup("INPUT", 5, new { Type = "text", ReadOnly = "false" });
		/// </example>
		public static TagElementGroup CreateGroup(string tagName, int tagCount, object attributes)
		{
			TagElementGroup group = CreateGroup(tagName, tagCount);
			ObjectReader reader = new ObjectReader();
			reader.ReadAttributes(attributes);

			for (int index = 0, len = group.Tags.Count; index < len; index++)
				group.Tags[index].Attributes.CopyFrom(reader.Attributes);

			return group;
		}

		/// <summary>
		/// Creates a tag group using a custom tag builder.  Several custom tag builders already exist within the <see cref="Nucleo.Web.Tags.Custom">Custom namespace</see>.
		/// </summary>
		/// <param name="tagBuilder">The tag builder to create the UI.</param>
		/// <returns>The tag element reference.</returns>
		public static TagElementGroup CreateGroup(Custom.ICustomTagGroupBuilder groupBuilder)
		{
			return groupBuilder.ToElementGroup();
		}

		/// <summary>
		/// Returns a wizard that can use a Fluent API to create a tag.
		/// </summary>
		/// <param name="tagName">The name of the tag to create.</param>
		/// <returns>The wizard for creating the tag.</returns>
		/// <example>
		/// var tag = TagElementBuilder.Wizard("DIV").Attributes((a) => { a.AppendAttribute("width", "500px"); }).Create();
		/// </example>
		public static TagElementWizard Wizard(string tagName)
		{
			TagElement tag = new TagElement(tagName);
			return new TagElementWizard(tag);
		}

		#endregion
	}
}
