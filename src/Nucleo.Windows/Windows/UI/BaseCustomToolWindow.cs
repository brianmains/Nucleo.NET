using System;


namespace Nucleo.Windows.UI
{
	public abstract class BaseCustomToolWindow : ToolWindow
	{
		#region " Constructors "

		protected BaseCustomToolWindow(string name, string title, ToolWindowLocation location, object uiInterface)
			: base(name, title, location, uiInterface) { }

		#endregion
	}
}
