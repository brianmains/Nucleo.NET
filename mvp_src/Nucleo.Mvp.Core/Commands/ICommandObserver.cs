using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Commands;


namespace Nucleo.Presentation.Commands
{
    /// <summary>
    /// Represents the presenter that's commandable.
    /// </summary>
    public interface ICommandObserver
    {
        /// <summary>
        /// Receives the command.
        /// </summary>
        /// <param name="command">The command to receive.</param>
        /// <param name="args">The arguments passed along.</param>
        void ReceiveCommand(ICommand command, object args);
    }
}
