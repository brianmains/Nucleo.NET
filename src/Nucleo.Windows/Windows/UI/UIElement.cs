using System;

using Nucleo.EventArguments;
using Nucleo.Windows.Actions;
using Nucleo.Windows.Application;


namespace Nucleo.Windows.UI
{
	public abstract class UIElement
	{
		private ContextMenu _contextMenu = null;
		private NotificationBalloon _notificationBalloon = null;

		private string _name = string.Empty;
		private string _title = "Untitled";
		private bool _visible = true;



		#region " Events "

		/// <summary>
		/// Raised when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets the context menu available for an object.
		/// </summary>
		public ContextMenu ContextMenu
		{
			get { return _contextMenu; }
			set
			{
				if (_contextMenu != value)
				{
					if (_contextMenu != null)
					{
						if (value != null)
							_contextMenu.Parent = this;
						else
							_contextMenu.Parent = null;
					}

					_contextMenu = value;
				}
			}
		}

		/// <summary>
		/// Gets a reference to the value path for the current item.
		/// </summary>
		public abstract ValuePath CurrentPath { get; }

		/// <summary>
		/// The name of the element, sometimes referred to as the key.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("value");

				if (string.Compare(_name, value, StringComparison.CurrentCulture) != 0)
				{
					string oldValue = _name;
					_name = value;

					this.OnPropertyChanged(new PropertyChangedEventArgs("Name", oldValue, value));
				}
			}
		}

		/// <summary>
		/// Gets or sets the notification balloon that appears for the given element.
		/// </summary>
		public NotificationBalloon NotificationBalloon
		{
			get { return _notificationBalloon; }
			set
			{
				UIElement originalElement = _notificationBalloon.Parent;

				_notificationBalloon = value;

				if (originalElement != null)
				{
					//When switching the notification balloon, this needs to switch
					originalElement.NotificationBalloon = null;
				}

				//Update the notification balloon to point to the current parent
				if (_notificationBalloon != null)
					_notificationBalloon.Parent = this;
			}
		}

		/// <summary>
		/// The title of the element, which may appear in a title bar or somewhere else.
		/// </summary>
		public string Title
		{
			get { return _title; }
			set
			{
				string valueCheck = (value == null ? string.Empty : value);

				if (string.Compare(_title, valueCheck, StringComparison.CurrentCulture) != 0)
				{
					string oldValue = _title;
					_title = value;

					this.OnPropertyChanged(new PropertyChangedEventArgs("Title", oldValue, value));
				}
			}
		}

		/// <summary>
		/// Whether the element is visible.
		/// </summary>
		public virtual bool Visible
		{
			get { return _visible; }
			set
			{
				if (_visible != value)
				{
					_visible = value;
					this.OnPropertyChanged(new PropertyChangedEventArgs("Visible", !value, value));
				}
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Assigns the name and title to the respective fields.
		/// </summary>
		/// <param name="name">The name of the element, sometimes referred to as the key.</param>
		/// <param name="title">The title of the element, which may appear in a title bar or somewhere else.</param>
		public UIElement(string name, string title)
		{
			Name = name;
			Title = title;
		}

		#endregion



		#region " Methods "

		public virtual EventActionCollection GetEvents()
		{
			return new EventActionCollection();
		}

		/// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="e">The event argument that contains the property change details.</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, e);
			Application.ApplicationEventsManager.FireEventNotification(ApplicationEventKeys.PropertyChangedEventName, this, this);
		}

		#endregion
	}
}
