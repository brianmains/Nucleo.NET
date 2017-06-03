using System;
using System.IO;
using System.Collections.Generic;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a writer to write content out to an text stream.
	/// </summary>
	public class TextStreamControlWriter : BaseControlWriter
	{
		private TextWriter _writer = null;



		#region " Properties "

		/// <summary>
		/// Gets true so that the writer auto-flushes its content.
		/// </summary>
		public override bool AutoFlush
		{
			get { return true; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the stream writer with the underlying text writer component.
		/// </summary>
		/// <param name="writer">The text writer.</param>
		public TextStreamControlWriter(TextWriter writer)
		{
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
