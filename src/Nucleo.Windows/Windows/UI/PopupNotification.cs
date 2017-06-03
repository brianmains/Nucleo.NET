using System;
using System.Collections.Generic;
using System.Timers;

using Nucleo.EventArguments;


namespace Nucleo.Windows.UI
{
	/// <summary>
	/// A brief notification about some UI element, that some action took place (like a balloon popup that goes away).
	/// </summary>
	public class PopupNotification : UIElement
	{
		private UIElement _associatedElement = null;
		private PopupNotificationLocation _location = PopupNotificationLocation.BottomLeft;
		private string _message = null;
		private bool _visible = false;



		#region " Events "

		/// <summary>
		/// The event that fires whenever the notification is hiding.
		/// </summary>
		public event EventHandler Hiding;

		/// <summary>
		/// The event that fires whenever the notification is showing.
		/// </summary>
		public event EventHandler Showing;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets the UI element that is associated with the popup notification.
		/// </summary>
		public UIElement AssociatedElement
		{
			get { return _associatedElement; }
			set { _associatedElement = value; }
		}

		/// <summary>
		/// Gets the current path.
		/// </summary>
		public override ValuePath CurrentPath
		{
			get
			{
				if (this.AssociatedElement != null)
					return new ValuePath(this.AssociatedElement.Name, this.Name);
				else
					return new ValuePath(this.Name);
			}
		}

		/// <summary>
		/// Gets or sets the location where the popup notification will appear.
		/// </summary>
		public PopupNotificationLocation Location
		{
			get { return _location; }
			set { _location = value; }
		}

		/// <summary>
		/// Gets or sets the message to display to the end user.
		/// </summary>
		public string Message
		{
			get { return _message; }
			set { _message = value; }
		}

		/// <summary>
		/// Gets or sets the visibility of the popup notification.
		/// </summary>
		public override bool Visible
		{
			get { return _visible; }
			set { }
		}

		#endregion



		#region " Constructors "

		public PopupNotification(string name, string title, string message, PopupNotificationLocation location, UIElement associatedElement)
			: base(name, title)
		{
			_message = message;
			_location = location;
			_associatedElement = associatedElement;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Hides the popup notification.
		/// </summary>
		public void Hide()
		{
			this.Visible = false;
			this.OnHiding(EventArgs.Empty);
		}

		/// <summary>
		/// Fires the hiding event.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected virtual void OnHiding(EventArgs e)
		{
			if (Hiding != null)
				Hiding(this, e);
		}

		/// <summary>
		/// Fires the showing event.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnShowing(EventArgs e)
		{
			if (Showing != null)
				Showing(this, e);
		}

		/// <summary>
		/// Shows the popup notification.
		/// </summary>
		public void Show()
		{
			this.Visible = true;
			this.OnShowing(EventArgs.Empty);
		}

		public void Show(double autoHideMilliseconds)
		{
			if (!this.Visible)
				throw new Exception("The popup notification is already visible; please wait until the notification is closed.");

			this.Show();

			Timer timer = new Timer(autoHideMilliseconds);
			timer.Elapsed += Timer_Elapsed;
			timer.Start();
		}

		#endregion



		#region " Event Handlers "

		void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			this.Visible = false;
		}

		#endregion
	}
}
