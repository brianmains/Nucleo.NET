using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the event arguments for binding items.
	/// </summary>
	public class ItemBindingEventArgs : ItemBoundEventArgs
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets whether to cancel the binding.
		/// </summary>
		public bool Cancel { get; set; }

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event args.
		/// </summary>
		/// <param name="control">The control to bind.</param>
		/// <param name="direction">The binding direction.</param>
		public ItemBindingEventArgs(Control control, ViewBindingDirection direction)
			: base(control, direction) { }

		#endregion
	}

	/// <summary>
	/// Represents the event handler for binding items.
	/// </summary>
	/// <param name="sender">The source.</param>
	/// <param name="e">The binding args.</param>
	public delegate void ItemBindingEventHandler(object sender, ItemBindingEventArgs e);
}
