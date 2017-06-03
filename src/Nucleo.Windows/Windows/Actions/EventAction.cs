using System;
using Nucleo.EventArguments;


namespace Nucleo.Windows.Actions
{
	/// <summary>
	/// An event action that occurs in the application system.
	/// </summary>
	public class EventAction
	{
		private DefaultEventAction _defaultAction = DefaultEventAction.None;
		private string _name = null;
		private object _source = null;
		private Type _sourceType = null;



		#region " Events "

		/// <summary>
		/// Fires whenever the event is raised by an object.
		/// </summary>
		public event DataEventHandler<EventAction> Raised;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the action that's setup as the default.
		/// </summary>
		public DefaultEventAction DefaultAction
		{
			get { return _defaultAction; }
		}

		/// <summary>
		/// Gets the name of the event.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets the source object for the event, or the object raising the event.
		/// </summary>
		public object Source
		{
			get { return _source; }
		}

		/// <summary>
		/// Gets the type of object that the event is for.
		/// </summary>
		public Type SourceType
		{
			get { return _sourceType; }
		}

		#endregion



		#region " Constructors "

		private EventAction() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Copies an event from one object to another, returning the copied event.
		/// </summary>
		/// <param name="baseAction">The event to copy from.</param>
		/// <returns>The copied event.</returns>
		private static EventAction Copy(EventAction baseAction)
		{
			EventAction action = new EventAction();
			action._name = baseAction.Name;
			action._source = baseAction.Source;
			action._sourceType = baseAction.SourceType;
			action._defaultAction = baseAction.DefaultAction;

			return action;
		}

		/// <summary>
		/// Defers to the overload to create the event.
		/// </summary>
		/// <param name="name">The name of the event.</param>
		/// <param name="sourceType">The type of the source allowed.</param>
		/// <returns>The instance of the action.</returns>
		public static EventAction Create(string name, Type sourceType)
		{
			return Create(name, sourceType, DefaultEventAction.None);
		}

		/// <summary>
		/// Creates an instance of the event action.
		/// </summary>
		/// <param name="name">The name of the event.</param>
		/// <param name="sourceType">The type of the source allowed.</param>
		/// <returns>The instance of the action.</returns>
		public static EventAction Create(string name, Type sourceType, DefaultEventAction defaultAction)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");
			if (sourceType == null)
				throw new ArgumentNullException("sourceType");

			EventAction action = new EventAction();
			action._name = name;
			action._sourceType = sourceType;
			action._defaultAction = defaultAction;

			return action;
		}

		/// <summary>
		/// Fires the <see cref="Raised" /> event.
		/// </summary>
		/// <param name="e">The event arguments that contain information about the event.</param>
		protected void OnRaised(DataEventArgs<EventAction> e)
		{
			if (Raised != null)
				Raised(this, e);
		}

		/// <summary>
		/// Raises the event for an instance of an object.
		/// </summary>
		/// <param name="source">The source object to raise the event for.</param>
		public void Raise(object source)
		{
			EventAction raisedAction = EventAction.Copy(this);
			raisedAction._source = source;

			this.OnRaised(new DataEventArgs<EventAction>(raisedAction));
		}

		#endregion
	}
}
