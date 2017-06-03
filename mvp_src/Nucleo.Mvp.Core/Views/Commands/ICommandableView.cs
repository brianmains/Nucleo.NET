using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Commands;
using Nucleo.EventArguments;


namespace Nucleo.Views.Commands
{
    public interface ICommandableView
    {
        ICommand GetCommand(string commandName);

        void RegisterCommand(ICommand command);
    }
}
