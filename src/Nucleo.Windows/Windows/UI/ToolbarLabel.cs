using System;


namespace Nucleo.Windows.UI
{
	public class ToolbarLabel : ToolbarTextItem
	{
		#region " Constructors "

		public ToolbarLabel(string name, string title, Toolbar parent)
			: base(name, title, parent) { }

		public ToolbarLabel(string name, string title, string text, Toolbar parent)
			: base(name, title, text, parent)
		{

		}

		#endregion
	}
}
