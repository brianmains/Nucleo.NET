using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents the options for the event registry.
	/// </summary>
	public class EventRegistryOptions : INotifyPropertyChanged
	{
		private bool _queuePublishedNotifications;



		#region " Events "

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion



		#region " Properties '

		/// <summary>
		/// Gets or sets whether to queue notifications that have been published.  This means that notifications are kept 
		/// </summary>
		public bool QueuePublishedNotifications
		{
			get { return _queuePublishedNotifications; }
			set
			{
				if (_queuePublishedNotifications != value)
				{
					_queuePublishedNotifications = value;
					this.OnPropertyChanged(new PropertyChangedEventArgs("QueuePublishedNotifications"));
				}
			}
		}

		#endregion



		#region " Methods "

		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, e);
		}

		#endregion
	}
}
