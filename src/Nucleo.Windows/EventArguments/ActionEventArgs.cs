using System;
using Nucleo.Windows.Actions;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// The event arguments for actions that take place within the application model framework.
	/// </summary>
	public class ActionEventArgs : EventArgs
	{
		IAction _action = null;



		#region " Properties "

		/// <summary>
		/// Gets the action that took place.
		/// </summary>
		public IAction Action
		{
			get { return _action; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event argument and assigns the action to the local variable.
		/// </summary>
		/// <param name="action">The action that occurred.</param>
		public ActionEventArgs(IAction action)
		{
			_action = action;
		}

		#endregion
	}


	/// <summary>
	/// The delegate for actions that take place within the application model framework.
	/// </summary>
	/// <param name="sender">The object sending the event.</param>
	/// <param name="e">The details regarding the action.</param>
	public delegate void ActionEventHandler(object sender, ActionEventArgs e);
}
