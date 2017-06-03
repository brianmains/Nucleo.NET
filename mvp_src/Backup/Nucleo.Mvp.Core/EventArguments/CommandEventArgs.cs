using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Commands;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the arguments of a command that fired.
	/// </summary>
    public class CommandEventArgs
    {
		/// <summary>
		/// Gets the optional argument value.
		/// </summary>
        public object Arguments
        {
            get;
            private set;
        }

		/// <summary>
		/// Gets the reference to the command that fired.
		/// </summary>
        public ICommand Command
        {
            get;
            private set;
        }



		/// <summary>
		/// Creates the command args with the given <see cref="ICommand"/> instance.
		/// </summary>
		/// <param name="command">The command that fired.</param>
		/// <param name="args">The arguments.</param>
        public CommandEventArgs(ICommand command, object args)
        {
            this.Command = command;
            this.Arguments = args;
        }
    }

	/// <summary>
	/// Represents the handler of a command which fired.
	/// </summary>
	/// <param name="sender">The object sending the notification.</param>
	/// <param name="e">The command details.</param>
    public delegate void CommandEventHandler(object sender, CommandEventArgs e);
}
