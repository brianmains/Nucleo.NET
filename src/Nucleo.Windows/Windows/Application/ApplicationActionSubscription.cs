using System;
using Nucleo.Windows.Actions;


namespace Nucleo.Windows.Application
{
	internal class ApplicationActionSubscription
	{
		private IAction _action = null;
		private Type _objectType = null;
		private string _objectName = null;

		private ApplicationActionSubscriptionCallback _callback = null;



		#region " Properties "

		/// <summary>
		/// Gets the action that is being targeted.
		/// </summary>
		public IAction Action
		{
			get { return _action; }
		}

		/// <summary>
		/// Gets the callback that will be invoked.
		/// </summary>
		internal ApplicationActionSubscriptionCallback Callback
		{
			get { return _callback; }
		}

		/// <summary>
		/// Gets the name of the object to match against.  Although there is only one name per object, there can be multiple subscriptions.
		/// </summary>
		public string ObjectName
		{
			get { return _objectName; }
		}

		/// <summary>
		/// Gets the type of object to match against.
		/// </summary>
		public Type ObjectType
		{
			get { return _objectType; }
		}

		#endregion



		#region " Constructors "

		internal ApplicationActionSubscription(Type objectType, string objectName, IAction action, ApplicationActionSubscriptionCallback callback)
		{
			_objectType = objectType;
			_objectName = objectName;
			_action = action;
			_callback = callback;
		}

		#endregion
	}


	public delegate void ApplicationActionSubscriptionCallback(IActionableElement element, IAction action);
}
