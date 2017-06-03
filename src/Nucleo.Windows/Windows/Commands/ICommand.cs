using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.Commands
{
	public interface ICommand
	{
		bool CanExecute();
		void Execute();
	}
}
