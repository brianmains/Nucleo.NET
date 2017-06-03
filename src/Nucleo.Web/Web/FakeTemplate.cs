using System;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a template that's a fake, rendering a literal control in the container, with the content that's supplied.
	/// </summary>
	public class FakeTemplate : ITemplate
	{
		private string _content = "Fake!!!";



		#region " Constructors "

		/// <summary>
		/// Creates the fake template.
		/// </summary>
		public FakeTemplate() { }

		/// <summary>
		/// Creates the fake template with its content.
		/// </summary>
		/// <param name="content">The content of the template.</param>
		public FakeTemplate(string content)
		{
			_content = content;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Instantiates the template within the container.
		/// </summary>
		/// <param name="container">The container.</param>
		public void InstantiateIn(Control container)
		{
			container.Controls.Add(new LiteralControl(_content));
		}

		#endregion
	}
}
