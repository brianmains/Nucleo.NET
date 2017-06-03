using System;
using System.Collections.Generic;

using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;


namespace Nucleo.EventsManagement
{
	/// <summary>
	/// Represents a base class for events.
	/// </summary>
	public abstract class BaseEvent : IEvent
	{
		private string _name = null;
		private object _securityAccess = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the event.
		/// </summary>
		public virtual string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets the current security access required for this event; this way, security permissions can be applied.
		/// </summary>
		public object SecurityAccess
		{
			get { return _securityAccess; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Initializes the component.
		/// </summary>
		public virtual void Initialize() { }

		/// <summary>
		/// Initializes the component with the initial settings.
		/// </summary>
		/// <param name="name">The name of the event.</param>
		/// <param name="securityAccess">The security access of the event.</param>
		protected internal void Initialize(string name, object securityAccess)
		{
			_name = name;
			_securityAccess = securityAccess;

			this.Initialize();
		}

		public void Raise(object source)
		{
			this.Raise(source, null);
		}

		public void Raise(object source, IDictionary<string, object> attributes)
		{
			if (source is IView)
			{
				this.Raise((IView)source);
				EventsManager.RaiseEvent((IView)source, this, attributes);
			}
		}

		protected virtual void Raise(IView view) { }

		#endregion
	}
}
