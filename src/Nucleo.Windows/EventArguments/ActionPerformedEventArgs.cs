using System;
using Nucleo.Windows.Actions;
using Nucleo.Windows.UI;


namespace Nucleo.EventArguments
{
	public class ActionPerformedEventArgs
	{
		private IAction _action = null;
		private IActionableElement _targetObject = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the action that took place.
		/// </summary>
		public IAction Action
		{
			get { return _action; }
			set { _action = value; }
		}

		/// <summary>
		/// Gets or sets the element that is the target of the action.
		/// </summary>
		public IActionableElement TargetObject
		{
			get { return _targetObject; }
			set { _targetObject = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event argument and assigns the parameters to the local values.
		/// </summary>
		/// <param name="targetObject">The target element that triggered the event.</param>
		/// <param name="action">The action that took place.</param>
		public ActionPerformedEventArgs(IActionableElement targetObject, IAction action)
		{
			_targetObject = targetObject;
			_action = action;
		}

		#endregion
	}


	public delegate void ActionPerformedEventHandler(object sender, ActionPerformedEventArgs e);
}
