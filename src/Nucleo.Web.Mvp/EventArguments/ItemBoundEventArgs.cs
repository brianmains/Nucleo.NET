using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the event arguments for items that are already bound.
	/// </summary>
	public class ItemBoundEventArgs : EventArgs
	{
		#region " Properties "

		/// <summary>
		/// Gets the control being bound.
		/// </summary>
		public Control Control { get; private set; }

		/// <summary>
		/// Gets the direction that the binding is happening.
		/// </summary>
		public ViewBindingDirection Direction { get; private set; }

		/// <summary>
		/// Gets or sets the name of the property.
		/// </summary>
		public string PropertyName { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		public object Value { get; set; }

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event args.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="direction">The direction to bind.</param>
		public ItemBoundEventArgs(Control control, ViewBindingDirection direction)
		{
			this.Control = control;
			this.Direction = direction;
		}

		#endregion
	}

	/// <summary>
	/// Represents the event arguments for items that are already bound.
	/// </summary>
	/// <param name="sender">The source.</param>
	/// <param name="e">The item bound event details.</param>
	public delegate void ItemBoundEventHandler(object sender, ItemBoundEventArgs e);
}
