using System;
using Nucleo.Windows.Actions;


namespace Nucleo.Windows.Application
{
	public interface IApplicationActionSubscriber
	{
		void HandleAction(IActionableElement element, IAction action);
	}
}
