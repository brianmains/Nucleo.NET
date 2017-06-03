using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Views
{
	public class View : IView
	{
		#region " Events "

		public event EventHandler Initializing;

		public event EventHandler Loading;

		public event EventHandler Loaded;

		public event EventHandler Starting;

		public event EventHandler Unloading;

		#endregion



		#region " Methods "

		protected virtual void OnInitializing(EventArgs e)
		{
			if (Initializing != null)
				Initializing(this, e);
		}

		protected virtual void OnLoading(EventArgs e)
		{
			if (Loading != null)
				Loading(this, e);
		}

		protected virtual void OnLoaded(EventArgs e)
		{
			if (Loaded != null)
				Loaded(this, e);
		}

		protected virtual void OnStarting(EventArgs e)
		{
			if (Starting != null)
				Starting(this, e);
		}

		protected virtual void OnUnloading(EventArgs e)
		{
			if (Unloading != null)
				Unloading(this, e);
		}

		#endregion
	}
}
