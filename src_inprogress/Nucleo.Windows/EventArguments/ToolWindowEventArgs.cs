using System;
using Nucleo.Windows.UI;


namespace Nucleo.EventArguments
{
	public class ToolWindowEventArgs
	{
		private ToolWindow _window = null;



		#region " Properties "

		public ToolWindow Window
		{
			get { return _window; }
		}

		#endregion



		#region " Constructors "

		public ToolWindowEventArgs(ToolWindow window)
		{
			_window = window;
		}

		#endregion
	}


	public delegate void ToolWindowEventHandler(object sender, ToolWindowEventArgs e);
}
