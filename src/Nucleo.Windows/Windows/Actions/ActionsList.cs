using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.Actions
{
	public static class ActionsList
	{
		public static IAction Click()
		{
			return new ClickAction();
		}

		public static IAction Select()
		{
			return new SelectionAction();
		}
	}
}
