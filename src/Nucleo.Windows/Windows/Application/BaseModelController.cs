using System;

using Nucleo.Collections;
using Nucleo.Windows.ApplicationListeners;


namespace Nucleo.Windows.Application
{
	public class BaseModelController
	{
		private SimpleCollection<BaseModelListener> _listeners = null;



		#region " Properties "

		private SimpleCollection<BaseModelListener> Listeners
		{
			get
			{
				if (_listeners == null)
					_listeners = new SimpleCollection<BaseModelListener>();
				return _listeners;
			}
		}

		#endregion



		#region " Constructors "

		public BaseModelController() { }

		#endregion



		#region " Methods "

		public void AddListener(BaseModelListener listener)
		{
			this.Listeners.Add(listener);
		}

		public T GetListener<T>()
			where T : BaseModelListener
		{
			foreach (BaseModelListener listener in this.Listeners)
			{
				if (listener is T)
					return (T)listener;
			}

			return null;
		}

		public SimpleCollection<BaseModelListener> GetListeners()
		{
			return this.Listeners;
		}

		#endregion
	}
}
