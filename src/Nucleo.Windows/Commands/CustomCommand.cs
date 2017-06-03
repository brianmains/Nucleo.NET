using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	/// <summary>
	/// This classed is used to dynamically invoke a method that has a particular attribute defined.
	/// </summary>
	public class CustomCommand : ICommand
	{
		private string _commandAction = string.Empty;



		#region " Properties "

		/// <summary>
		/// The action to perform; this should match the command-based attribute.
		/// </summary>
		public string CommandAction
		{
			get { return _commandAction; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Passes the command to the inner property.  The command action should match the command-based attribute.
		/// </summary>
		/// <param name="commandAction">The command to execute.</param>
		public CustomCommand(string commandAction)
		{
			_commandAction = commandAction;
		}

		#endregion



		#region " Methods "

		bool ICommand.PerformCommand()
		{
			return false;
		}

		#endregion
	}
}
