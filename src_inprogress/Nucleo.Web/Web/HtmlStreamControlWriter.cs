using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a writer to write content out to an HTML stream.
	/// </summary>
	public class HtmlStreamControlWriter : BaseControlWriter
	{
		private HtmlTextWriter _writer = null;



		#region " Properties "

		/// <summary>
		/// Gets true so that the writer auto-flushes its content.
		/// </summary>
		public override bool AutoFlush
		{
			get { return true; }
		}

		/// <summary>
		/// Gets the HTML writer.
		/// </summary>
		private HtmlTextWriter Writer
		{
			get { return _writer; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the stream writer with the underlying HTML text writer component.
		/// </summary>
		/// <param name="writer">The HTML text writer.</param>
		public HtmlStreamControlWriter(HtmlTextWriter writer)
		{
			if (writer == null)
				throw new ArgumentNullException("writer");

			_writer = writer;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Writes the text to the output stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public override void Write(string text)
		{
			_writer.Write(text);
		}

		/// <summary>
		/// Writes the text to the output stream.
		/// </summary>
		/// <param name="format">The text to write, with format placeholders.</param>
		/// <param name="args">The arguments to interject.</param>
		public override void Write(string format, params object[] args)
		{
			_writer.Write(format, args);
		}

		/// <summary>
		/// Writes the text to the output stream with a new line.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public override void WriteLine(string text)
		{
			_writer.WriteLine(text);
		}

		/// <summary>
		/// Writes the text to the output stream with a new line.
		/// </summary>
		/// <param name="format">The text to write, with format placeholders.</param>
		/// <param name="args">The arguments to interject.</param>
		public override void WriteLine(string format, params object[] args)
		{
			_writer.WriteLine(format, args);
		}
		
		#endregion
	}
}
