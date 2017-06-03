using System;
using Nucleo.Windows.Actions;


namespace Nucleo.EventArguments
{
	public class ApplicationEventEventArgs
	{
		private IAction _action = null;
		private int _index = -1;
		private string _name = string.Empty;
		private object _sourceObject = null;
		private object _targetObject = null;



		#region " Properties "

		/// <summary>
		/// The action that has taken place.
		/// </summary>
		public IAction Action
		{
			get { return _action; }
		}

		/// <summary>
		/// The index that an event occurred, for list-based events.
		/// </summary>
		public int Index
		{
			get { return _index; }
		}

		/// <summary>
		/// Gets the name of the event that is taking place.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets the object raising the event.
		/// </summary>
		public object SourceObject
		{
			get { return _sourceObject; }
		}

		/// <summary>
		/// Gets the target that is the object causing the event to occur.
		/// </summary>
		public object TargetObject
		{
			get { return _targetObject; }
		}

		#endregion



		#region " Constructors "

		public ApplicationEventEventArgs(string name, object sourceObject, object targetObject)
		{
			_name = name;
			_sourceObject = sourceObject;
			_targetObject = targetObject;
		}

		public ApplicationEventEventArgs(string name, object sourceObject, object targetObject, int index)
			: this(name, sourceObject, targetObject)
		{
			_index = index;
		}

		public ApplicationEventEventArgs(string name, object sourceObject, object targetObject, IAction action)
			: this(name, sourceObject, targetObject)
		{
			_action = action;
		}

		#endregion
	}


	public delegate void ApplicationEventEventHandler(object sender, ApplicationEventEventArgs e);
}
