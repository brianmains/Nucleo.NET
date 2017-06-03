using System;
using System.Collections.Generic;
using System.Linq;
using Nucleo.EventArguments;


namespace Nucleo.Commands
{
    /// <summary>
    /// Represents a command object that fires an event.
    /// </summary>
    public interface ICommand
    {
        event CommandEventHandler Fired;



        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        string Name { get; }



        /// <summary>
        /// Fires the command.
        /// </summary>
        void Fire(object args);
    }
}
