using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Nucleo.Web
{
	public static class BaseControlWriterExtensions
	{
		#region " Methods "

		/// <summary>
		/// Writes an MVC HTML string to the underlying writer.
		/// </summary>
		/// <param name="writer">The writer to write to.</param>
		/// <param name="content">The content to write.</param>
		public static void Write(this BaseControlWriter writer, MvcHtmlString content)
		{
			if (content == null)
				return;

			writer.Write(content.ToHtmlString());
		}

		#endregion
	}
}
