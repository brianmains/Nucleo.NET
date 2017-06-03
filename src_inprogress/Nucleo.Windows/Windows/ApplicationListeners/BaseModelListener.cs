using System;

using Nucleo.Windows.Actions;
using Nucleo.Windows.Application;
using Nucleo.Windows.UI;
using Nucleo.EventArguments;


namespace Nucleo.Windows.ApplicationListeners
{
	public abstract class BaseModelListener
	{
		private ApplicationModel _application = null;
		private EventActionCollection _handledEvents = null;
		private ListenerControl _uiControl = null;



		#region " Events "

		/// <summary>
		/// This event fires whenever an event for a listened object fires its event.
		/// </summary>
		public event DataEventHandler<EventAction> EventFired;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the application model reference.
		/// </summary>
		public ApplicationModel Application
		{
			get { return _application; }
		}

		/// <summary>
		/// Gets the events that are handled by the application.
		/// </summary>
		public EventActionCollection HandledEvents
		{
			get { return _handledEvents; }
		}

		/// <summary>
		/// Gets the control that represents the UI.
		/// </summary>
		public ListenerControl UIControl
		{
			get { return _uiControl; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the listener for the specified UI element.
		/// </summary>
		/// <param name="uiControl">The object representing the UI.</param>
		/// <param name="application">The application model.</param>
		protected BaseModelListener(ListenerControl uiControl, ApplicationModel application)
		{
			if (uiControl == null)
				throw new ArgumentNullException("control");
			if (application == null)
				throw new ArgumentNullException("application");

			_uiControl = uiControl;
			_application = application;

			_application.ItemAdded += Application_ItemAdded;
			_application.ItemRemoved += Application_ItemRemoved;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a new item to the underlying UI control.
		/// </summary>
		/// <param name="index">The index of the item.</param>
		/// <param name="item">The item to add to the control.</param>
		public virtual void AddItem(int index, UIElement item)
		{
			this.UIControl.AddItem(index, item);
		}

		/// <summary>
		/// Attaches to an event belonging to the listened object, so that it can fire an event whenever that event fires.
		/// </summary>
		/// <param name="action">The action to attach to.</param>
		private void AttachToEvent(EventAction action)
		{
			if (action == null)
				throw new ArgumentNullException("action");

			action.Raised += Action_Raised;
		}

		protected internal void AttachToEvents()
		{
			this._handledEvents = this.GetEvents();
			foreach (EventAction eventInfo in this.HandledEvents)
				this.AttachToEvent(eventInfo);
		}

		/// <summary>
		/// Detaches from an event belonging to the listened object.
		/// </summary>
		/// <param name="action">The action to detach from.</param>
		private void DetachFromEvent(EventAction action)
		{
			if (action == null)
				throw new ArgumentNullException("action");

			action.Raised -= Action_Raised;   
		}

		protected internal void DetachFromEvents()
		{
			foreach (EventAction action in this.HandledEvents)
				this.DetachFromEvent(action);
		}

		protected virtual EventActionCollection GetEvents()
		{
			return new EventActionCollection();
		}

		/// <summary>
		/// Returns whether the UI element provided is supported by the listener.
		/// </summary>
		/// <param name="element">The element to check for support.</param>
		/// <returns>Whether the element is supported.</returns>
		protected internal abstract bool IsSupportedUIElement(UIElement element);

		/// <summary>
		/// Fires the <see cref="EventFired" /> event whenever an event that's being listened for fires.s
		/// </summary>
		/// <param name="e"></param>
		protected void OnEventFired(DataEventArgs<EventAction> e)
		{
			if (this.EventFired != null)
				EventFired(this, e);
		}

		/// <summary>
		/// Removes the item from the UI control.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		public virtual void RemoveItem(UIElement item)
		{
			this.UIControl.RemoveItem(item);
		}

		/// <summary>
		/// Removes anitem from the UI control using the specified index.
		/// </summary>
		/// <param name="index">The index of the item.</param>
		public virtual void RemoveItem(int index)
		{
			this.UIControl.RemoveItem(index);
		}

		#endregion



		#region " Event Handlers "

		/// <summary>
		/// Raised whenever an attached event fires.
		/// </summary>
		/// <param name="sender">The object raising the event.</param>
		/// <param name="e">The details about the event.</param>
		void Action_Raised(object sender, DataEventArgs<EventAction> e)
		{
			this.OnEventFired(e);
			this.UIControl.HandleEvent(e.Data);
		}

		/// <summary>
		/// Calls the <see cref="AddItem" /> method whenever the application event fires.
		/// </summary>
		/// <param name="sender">The object raising the event.</param>
		/// <param name="e">The details about the addition.</param>
		void Application_ItemAdded(object sender, ApplicationModelEventArgs e)
		{
			this.AddItem(e.Index, e.Item);
		}

		/// <summary>
		/// Calls the <see cref="RemoveItem" /> method whenever the application event fires.
		/// </summary>
		/// <param name="sender">The object raising the event.</param>
		/// <param name="e">The details about the removal.</param>
		void Application_ItemRemoved(object sender, ApplicationModelEventArgs e)
		{
			this.RemoveItem(e.Item);
		}

		#endregion
	}
}
