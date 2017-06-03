using System;


namespace Nucleo.Views
{
	/// <summary>
	/// Represents a view.  Must be overridden to have value to the presenter.
	/// </summary>
	public interface IView
	{
		#region " Events "

		/// <summary>
		/// Fires when the view is initializing.
		/// </summary>
		event EventHandler Initializing;

		/// <summary>
		/// Fires when the view is loading.
		/// </summary>
		event EventHandler Loading;

		/// <summary>
		/// Fires when the view is loaded.
		/// </summary>
		event EventHandler Loaded;

		/// <summary>
		/// Fires when the view is starting.
		/// </summary>
		event EventHandler Starting;

		/// <summary>
		/// Fires when the view is unloading.
		/// </summary>
		event EventHandler Unloading;

		#endregion
	}
}
