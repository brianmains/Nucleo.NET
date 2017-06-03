using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	public class NotificationBalloon : UIElement
	{
		private string _message = null;
		private UIElement _parent = null;
		private bool _visible = false;



		#region " Properties "

		/// <summary>
		/// Gets or sets the path to the notification balloon.
		/// </summary>
		public override ValuePath CurrentPath
		{
			get
			{
				if (_parent != null)
					return new ValuePath(this.Parent.Name, this.Name);
				else
					return new ValuePath(this.Name);
			}
		}

		/// <summary>
		/// Gets or sets the message to display in a notification balloon.
		/// </summary>
		public string Message
		{
			get { return _message; }
			set { _message = value; }
		}

		/// <summary>
		/// Gets the UI element
		/// </summary>
		public UIElement Parent
		{
			get { return _parent; }
			internal set { _parent = value; }
		}

		/// <summary>
		/// Gets the current visibility for the notification balloon; this property cannot be set.
		/// </summary>
		public override bool Visible
		{
			get { return _visible; }
			set { }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the notification balloon with the minimal required information.
		/// </summary>
		/// <param name="name">The name of the balloon.</param>
		/// <param name="title">The title of the balloon.</param>
		/// <param name="message">The message for the balloon.</param>
		public NotificationBalloon(string name, string title, string message)
			: base(name, title)
		{
			_message = message;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Hides the notification balloon.
		/// </summary>
		public void Hide()
		{
			_visible = false;
		}

		/// <summary>
		/// Shows the notification balloon.
		/// </summary>
		public void Show()
		{
			_visible = true;
		}

		#endregion
	}
}
