using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents the base class for control writers.
	/// </summary>
	public abstract class BaseControlWriter
	{
		#region " Properties "

		/// <summary>
		/// Gets whether the writer auto-flushes the content.
		/// </summary>
		public abstract bool AutoFlush { get; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Writes text to the underlying stream.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public abstract void Write(string text);

		/// <summary>
		/// Writes text to the underlying stream, using the format string and supplying the arguments as placeholders.
		/// </summary>
		/// <param name="format">The text to write.</param>
		/// <param name="args">The arguments to inject into the format string.</param>
		public abstract void Write(string format, params object[] args);

		/// <summary>
		/// Writes text to the underlying stream.  A new line is inserted at the end.
		/// </summary>
		/// <param name="text">The text to write.</param>
		public abstract void WriteLine(string text);

		/// <summary>
		/// Writes text to the underlying stream, using the format string and supplying the arguments as placeholders.  At the end, a new line is inserted.
		/// </summary>
		/// <param name="format">The text to write.</param>
		/// <param name="args">The arguments to inject into the format string.</param>
		public abstract void WriteLine(string format, params object[] args);

		#endregion
	}
}