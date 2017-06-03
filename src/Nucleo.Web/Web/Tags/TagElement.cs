using System;
using System.Text;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web.Tags
{
	/// <summary>
	/// Represents an HTML tag to create.
	/// </summary>
	public class TagElement
	{
		private TagAttributeCollection _attributes = null;
		private TagElementCollection _children = null;
		private TagAttributeCollection _styles = null;

		private string _content = null;
		private string _tagName = null;



		#region " Properties "

		/// <summary>
		/// Gets the attributes for the tag element, or the attributes for the direct tag element.
		/// </summary>
		/// <example>
		/// tag.Attributes.AppendAttribute("width", "500px");
		/// </example>
		public TagAttributeCollection Attributes
		{
			get
			{
				if (_attributes == null)
					_attributes = new TagAttributeCollection();
				return _attributes;
			}
		}

		/// <summary>
		/// Gets the children of the element.
		/// </summary>
		/// <example>
		/// 
		/// </example>
		public TagElementCollection Children
		{
			get
			{
				if (_children == null)
					_children = new TagElementCollection();
				return _children;
			}
		}

		/// <summary>
		/// Gets the inner content (text or inner HTML) of the element.
		/// </summary>
		public string Content
		{
			get { return _content; }
			set { _content = value; }
		}

		/// <summary>
		/// Gets the styles of the element, or attributes within the style attribute.
		/// </summary>
		public TagAttributeCollection Styles
		{
			get
			{
				if (_styles == null)
					_styles = new TagAttributeCollection();
				return _styles;
			}
		}

		/// <summary>
		/// Gets the name of the tag.
		/// </summary>
		public string TagName
		{
			get { return _tagName; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the tag element.  Please do not use this approach; use the <see cref="TagElementBuilder">TagElementBuilder component</see> for creating tags.
		/// </summary>
		/// <param name="tagName">The name of the tag.</param>
		public TagElement(string tagName)
		{
			_tagName = tagName;
		}

		/// <summary>
		/// Creates the tag element.  Please do not use this approach; use the <see cref="TagElementBuilder">TagElementBuilder component</see> for creating tags.
		/// </summary>
		/// <param name="tagName">The name of the tag.</param>
		/// <param name="content">The tag's inner content.</param>
		public TagElement(string tagName, string content)
			: this(tagName)
		{
			_content = content;
		}

		public TagElement(string tagName, params object[] children)
			: this(tagName)
		{
			foreach (object child in children)
			{
				if (child is TagElement)
					this.Children.AppendTag((TagElement)child);
				else if (child is TagAttribute)
					this.Attributes.AppendAttribute((TagAttribute)child);
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Clones the tag without cloning the children.
		/// </summary>
		/// <returns>The cloned tag without cloned children.</returns>
		/// <example>
		/// var newTag = tag.CloneTag();
		/// </example>
		public TagElement CloneTag()
		{
			return this.CloneTag(false);
		}

		/// <summary>
		/// Clones the tag with or without cloning the children.
		/// </summary>
		/// <param name="includeChildren">Whether to clone the children.</param>
		/// <returns>The cloned tag, with or without cloned children.</returns>
		/// <example>
		/// var newTag = tag.CloneTag(true);
		/// Assert.AreEqual(2, newTag.Children.TagCount);
		/// </example>
		public TagElement CloneTag(bool includeChildren)
		{
			TagElement element = new TagElement(this.TagName, this.Content);
			element.Attributes.CopyFrom(this.Attributes);
			element.Styles.CopyFrom(this.Styles);

			element.Children.AppendTags(this.Children.CloneTags(includeChildren));

			return element;
		}

		/// <summary>
		/// Getting the tag element plus its children to an output string, returning attributes and styles as well.
		/// </summary>
		/// <returns>The HTML string for the element and its children.</returns>
		/// <example>
		/// string content = tag.ToHtmlString();
		/// </example>
		public string ToHtmlString()
		{
			return ToHtmlString(TagRenderingMode.Full);
		}

		/// <summary>
		/// Getting the tag element plus its children to an output string, returning attributes and styles as well.  Can use the parameter to return only a subset of the attribute.
		/// </summary>
		/// <returns>The HTML string for the element and its children.</returns>
		/// <example>
		/// var beginContent = tag.ToHtmlString(TagRenderingMode.BeginTag);
		/// var endContent = tag.ToHtmlString(TagRenderingMode.EndTag);
		/// </example>
		public string ToHtmlString(TagRenderingMode mode)
		{
			StringBuilder builder = new StringBuilder();

			if (mode == TagRenderingMode.Full || mode == TagRenderingMode.BeginTag)
			{
				builder.AppendFormat("<{0}", this.TagName);

				if (this.Attributes.AttributeCount > 0)
				{
					IEnumerable<TagAttribute> attributes = this.Attributes.GetAttributes();

					foreach (TagAttribute attribute in attributes)
					{
						if (!(attribute.Value == null || (attribute.Value is string && string.IsNullOrEmpty((string)attribute.Value))))
							builder.AppendFormat(" {0}=\"{1}\"", attribute.Name, attribute.Value);
					}
				}

				if (this.Styles.AttributeCount > 0)
				{
					builder.Append(" style=\"");
					bool semi = false;

					IEnumerable<TagAttribute> styles = this.Styles.GetAttributes();

					foreach (TagAttribute style in styles)
						builder.Append(string.Format("{0}:{1};", style.Name, style.Value));

					builder.Append("\"");
				}

				builder.Append(">");
			}

			if (mode == TagRenderingMode.Full)
			{
				if (!string.IsNullOrEmpty(this.Content))
					builder.Append(this.Content);
			}

			if (mode == TagRenderingMode.Full || mode == TagRenderingMode.Children)
			{
				if (this.Children.Count > 0)
				{
					for (int index = 0, len = this.Children.Count; index < len; index++)
						builder.Append(this.Children.GetTag(index).ToHtmlString());
				}
			}

			if (mode == TagRenderingMode.Full || mode == TagRenderingMode.EndTag)
			{
				builder.AppendFormat("</{0}>", this.TagName);
			}

			return builder.ToString();
		}

		#endregion
	}
}
