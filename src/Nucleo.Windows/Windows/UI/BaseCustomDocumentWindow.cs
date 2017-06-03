using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	public abstract class BaseCustomDocumentWindow : DocumentWindow
	{
		#region " Constructors "

		protected BaseCustomDocumentWindow(string name, string title, object uiInterface)
			: base(name, title, uiInterface) { }

		#endregion
	}
}
