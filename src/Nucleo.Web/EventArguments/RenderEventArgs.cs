using System;
using Nucleo.Web;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Gets the event argument for the rendering process.
	/// </summary>
	public class RenderEventArgs
	{
		private BaseControlWriter _writer = null;



		#region " Properties "

		/// <summary>
		/// Gets the writer currently performing the rendering process.
		/// </summary>
		public BaseControlWriter Writer
		{
			get { return _writer; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event arguments with the renderer.
		/// </summary>
		/// <param name="writer">The writer to render with.</param>
		public RenderEventArgs(BaseControlWriter writer)
		{
			_writer = writer;
		}

		#endregion
	}

	/// <summary>
	/// Represents a delegate for rendering.
	/// </summary>
	/// <param name="sender">The sending object.</param>
	/// <param name="e">The rendering event argument details.</param>
	public delegate void RenderEventHandler(object sender, RenderEventArgs e);
}
