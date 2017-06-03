using System;


namespace Nucleo.Web.Templates
{
	/// <summary>
	/// Represents a fake template to use for unit testing purposes.
	/// </summary>
	public class FakeElementTemplate : IElementTemplate
	{
		private string _content = null;
		private bool _returnsContent = false;



		#region " Properties "

		/// <summary>
		/// Gets the content of the template.
		/// </summary>
		public string Content
		{
			get { return _content; }
		}

		/// <summary>
		/// Gets whether the content should be returned, passed in through the constructor.
		/// </summary>
		public bool ReturnsContent
		{
			get { return _returnsContent; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the fake element template with the passed in content and returns parameters.
		/// </summary>
		/// <param name="content">The content of the template.</param>
		/// <param name="returnsContent">Whether the content can be returned.</param>
		public FakeElementTemplate(string content, bool returnsContent)
		{
			_content = content;
			_returnsContent = returnsContent;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the template content; if the returns content returns true, the content gets returned from this method.
		/// </summary>
		/// <returns>The template content.</returns>
		public string GetTemplate()
		{
			return (_returnsContent) ? _content : null;
		}

		/// <summary>
		/// Ignored.
		/// </summary>
		public void InvokeTemplate()
		{
			
		}

		#endregion
	}
}
