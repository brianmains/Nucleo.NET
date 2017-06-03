using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.Tags.Custom
{
	/// <summary>
	/// Represents a builder to create a javascript tag and its JS content or file reference.
	/// </summary>
	/// <example>
	/// var builder = JavaScriptTagBuilder.CreateForFile("jquery.min.js");
	/// //gets &lt;script language='javascript' src='jquery.min.js'>&lt;/script>
	/// var jsBlock = builder.ToElement();
	/// </example>
	public class JavaScriptTagBuilder : ICustomTagBuilder
	{
		private string _content = null;
		private string _path = null;



		#region " Properties "

		public string Content
		{
			get { return _content; }
			set { _content = value; }
		}

		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}

		#endregion



		#region " Constructors "

		private JavaScriptTagBuilder() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Creates the builder using a file reference.
		/// </summary>
		/// <param name="path">The file reference to include.</param>
		/// <returns>The builder reference.</returns>
		public static JavaScriptTagBuilder CreateForFile(string path)
		{
			if (string.IsNullOrEmpty(path))
				throw new ArgumentNullException("path");

			JavaScriptTagBuilder builder = new JavaScriptTagBuilder();
			builder._path = path;

			return builder;
		}

		/// <summary>
		/// Creates the builder using a file reference.
		/// </summary>
		/// <param name="content">The content of JavaScript code.</param>
		/// <returns>The builder reference.</returns>
		public static JavaScriptTagBuilder CreateWithContent(string content)
		{
			if (string.IsNullOrEmpty(content))
				throw new ArgumentNullException("content");

			JavaScriptTagBuilder builder = new JavaScriptTagBuilder();
			builder._content = content;

			return builder;
		}

		/// <summary>
		/// Creates the javascript element block.
		/// </summary>
		/// <returns>The script reference and JavaScript content or file reference.</returns>
		public TagElement ToElement()
		{
			TagElement tag = TagElementBuilder.Create("SCRIPT");
			tag.Attributes.AppendAttribute("type", "text/javasript")
				.AppendAttribute("language", "javascript");

			if (!string.IsNullOrEmpty(_path))
				tag.Attributes.AppendAttribute("src", _path);
			else
				tag.Content = _content;

			return tag;
		}

		#endregion
	}
}
