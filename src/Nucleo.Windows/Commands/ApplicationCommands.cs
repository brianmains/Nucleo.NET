using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	/// <summary>
	/// The sets of standard commands to automatically use within the system.
	/// </summary>
	public class ApplicationCommand : ICommand
	{
		private string _commandAction = string.Empty;



		#region " Constants "

		public const string ExitCommandAction = "Exit";

		#endregion



		#region " Properties "

		string ICommand.CommandAction
		{
			get { return _commandAction; }
		}

		#endregion



		#region " Constructors "

		private ApplicationCommand(string commandAction)
		{
			_commandAction = commandAction;
		}

		#endregion



		#region " Methods "

		public static ApplicationCommand Exit()
		{
			return new ApplicationCommand(ExitCommandAction);
		}

		bool ICommand.PerformCommand()
		{
			if (_commandAction.Equals(ExitCommandAction))
			{
				System.Windows.Forms.Application.Exit();
				return true;
			}

			return false;
		}

		#endregion
	}
}
