using System;


namespace Nucleo.Windows.Actions
{
	public interface IActionableElement
	{
		void PerformAction(IAction action, object target);
	}
}
