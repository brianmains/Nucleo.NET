using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.EventArguments;


namespace Nucleo.Commands
{
	/// <summary>
	/// Represents the base class for using commands as a way to signal events in the MVP framework.
	/// </summary>
    public abstract class BaseCommand : ICommand
    {
		/// <summary>
		/// Represents the event that fires when the fire method is invoked.
		/// </summary>
        public event CommandEventHandler Fired;



		/// <summary>
		/// Gets the name of the command.
		/// </summary>
        public abstract string Name
        {
            get;
        }



		/// <summary>
		/// Fires the command with the given arguments.
		/// </summary>
		/// <param name="args">The arguments to pass along.</param>
        public void Fire(object args)
        {
            this.OnFired(new CommandEventArgs(this, args));
        }

		/// <summary>
		/// Fires the <see cref="Fired"/> event.
		/// </summary>
		/// <param name="e">The arguments to pass along.</param>
        protected virtual void OnFired(CommandEventArgs e)
        {
            if (Fired != null)
                Fired(this, e);
        }
    }
}