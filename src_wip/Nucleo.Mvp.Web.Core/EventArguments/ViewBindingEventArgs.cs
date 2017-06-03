using System;
using System.ComponentModel;

using Nucleo.Web.Mvp.BindingControls;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the event arguments for binding to/from the view.
	/// </summary>
	public class ViewBindingEventArgs : CancelEventArgs
	{
		#region " Properties "

		/// <summary>
		/// Gets the direction to bind.
		/// </summary>
		public ViewBindingDirection Direction
		{
			get;
			private set;
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event arguments.
		/// </summary>
		/// <param name="direction">The direction to bind.</param>
		public ViewBindingEventArgs(ViewBindingDirection direction)
		{
			this.Direction = direction;
		}

		#endregion
	}

	/// <summary>
	/// Represents the delegate for handling the binding to/from views.
	/// </summary>
	/// <param name="sender">The control.</param>
	/// <param name="e">The binding event args.</param>
	public delegate void ViewBindingEventHandler(object sender, ViewBindingEventArgs e);
}
