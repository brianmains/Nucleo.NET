using System;


namespace Nucleo.Windows.Commands
{
	public class QuitCommand : ICommand
	{
		#region " Properties "

		public string CommandName
		{
			get { return "Quit"; }
		}

		#endregion



		#region " Methods "

		public bool CanExecute()
		{
			return true;
		}

		public void Execute()
		{
			System.Windows.Forms.Application.Exit();
		}

		#endregion
	}
}
