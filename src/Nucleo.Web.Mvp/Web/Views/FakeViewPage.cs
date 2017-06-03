using System;
using System.Web.UI;

using Nucleo.Views;


namespace Nucleo.Web.Views
{
	public class FakeViewPage : Page, IView
	{
		#region IView Members

		/// <summary>
		/// Fires when the view is initializing.
		/// </summary>
		public event EventHandler Initializing;

		/// <summary>
		/// Fires when the view is loading.
		/// </summary>
		public event EventHandler Loading;

		/// <summary>
		/// Fires when the view is loaded.
		/// </summary>
		public event EventHandler Loaded;

		/// <summary>
		/// Fires when the view is starting.
		/// </summary>
		public event EventHandler Starting;

		/// <summary>
		/// Fires when the view is unloading.
		/// </summary>
		public event EventHandler Unloading;

		#endregion



		#region " Methods "

		/// <summary>
		/// Fires the <see cref="Initializing"/> event.
		/// </summary>
		public void FireInitializingEvent()
		{
			if (Initializing != null)
				Initializing(this, EventArgs.Empty);
		}

		/// <summary>
		/// Fires the <see cref="Loading"/> event.
		/// </summary>
		public void FireLoadingEvent()
		{
			if (Loading != null)
				Loading(this, EventArgs.Empty);
		}

		/// <summary>
		/// Fires the <see cref="Loaded"/> event.
		/// </summary>
		public void FireLoadedEvent()
		{
			if (Loaded != null)
				Loaded(this, EventArgs.Empty);
		}

		/// <summary>
		/// Fires the <see cref="Starting"/> event.
		/// </summary>
		public void FireStartingEvent()
		{
			if (Starting != null)
				Starting(this, EventArgs.Empty);
		}

		/// <summary>
		/// Fires the <see cref="Unloading"/> event.
		/// </summary>
		public void FireUnloadingEvent()
		{
			if (Unloading != null)
				Unloading(this, EventArgs.Empty);
		}

		#endregion
	}
}
