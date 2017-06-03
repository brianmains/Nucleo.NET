using System;
using System.Collections.Generic;


namespace Nucleo.Web.Templates
{
	/// <summary>
	/// Represents the template defined within an action that will render the template.
	/// </summary>
	public class ActionElementTemplate : IElementTemplate
	{
		private Action _content = null;



		#region " Properties "

		/// <summary>
		/// Gets the content defined within the action.
		/// </summary>
		public Action Content
		{
			get { return _content; }
		}

		/// <summary>
		/// Returns false.
		/// </summary>
		public bool ReturnsContent
		{
			get { return false; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the template.
		/// </summary>
		public ActionElementTemplate() { }

		/// <summary>
		/// Creates the template with the action that will render it.
		/// </summary>
		/// <param name="content">The content to render the template.</param>
		public ActionElementTemplate(Action content)
		{
			_content = content;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Returns null; this isn't used.
		/// </summary>
		/// <returns>Returns empty.</returns>
		public string GetTemplate()
		{
			return null;
		}

		/// <summary>
		/// Invokes the template, calling the action method that will render the content.
		/// </summary>
		public void InvokeTemplate()
		{
			this.Content();
		}

		#endregion
	}
}