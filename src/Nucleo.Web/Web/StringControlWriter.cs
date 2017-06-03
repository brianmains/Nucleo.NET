using System;
using System.Text;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a writer that writes to a string builder.
	/// </summary>
	public class StringControlWriter : BaseControlWriter
	{
		private StringBuilder _writer = null;



		#region " Properties "

		/// <summary>
		/// Gets false.
		/// </summary>
		public override bool AutoFlush
		{
			get { return false; }
		}

		/// <summary>
		/// Gets the string builder to write the content out to.
		/// </summary>
		private StringBuilder Writer
		{
			get
			{
				if (_writer == null)
					_writer = new StringBuilder();
				return _writer;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Writes text to the underlying stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public override void Write(string text)
		{
			this.Writer.Append(text);
		}

		/// <summary>
		/// Writes text to the underlying stream, using the format string and supplying the arguments as placeholders.
		/// </summary>
		/// <param name="format">The text to write.</param>
		/// <param name="args">The arguments to inject into the format string.</param>
		public override void Write(string format, params object[] args)
		{
			this.Writer.Append(string.Format(format, args));
		}

		/// <summary>
		/// Writes text to the underlying stream.  A new line is inserted at the end.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public override void WriteLine(string text)
		{
			this.Writer.AppendLine(text);
		}

		/// <summary>
		/// Writes text to the underlying stream, using the format string and supplying the arguments as placeholders.  At the end, a new line is inserted.
		/// </summary>
		/// <param name="format">The text to write.</param>
		/// <param name="args">The arguments to inject into the format string.</param>
		public override void WriteLine(string format, params object[] args)
		{
			this.Writer.AppendLine(string.Format(format, args));
		}

		/// <summary>
		/// Writes all of the content from the string builder.
		/// </summary>
		/// <returns>The final content.</returns>
		public override string ToString()
		{
			return this.Writer.ToString();
		}

		#endregion
	}
}
