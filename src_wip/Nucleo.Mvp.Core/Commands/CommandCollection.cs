using System;
using System.Collections.Generic;
using System.Linq;
using Nucleo.Collections;


namespace Nucleo.Commands
{
    /// <summary>
    /// Represents a collection of <see cref="ICommand"/> objects.
    /// </summary>
    /// <seealso cref="ICommand"/>
    public class CommandCollection : SimpleCollection<ICommand>
    {
        /// <summary>
        /// Gets the command by name.  Returns null if not found.
        /// </summary>
        /// <param name="name">The name to find.</param>
        /// <returns>The command, or null if not found.</returns>
        public ICommand GetByName(string name)
        {
            for (int i = 0, len = this.Count; i < len; i++)
            {
                if (String.Compare(name, this[i].Name, StringComparison.OrdinalIgnoreCase) == 0)
                    return this[i];
            }

            return null;
        }
    }
}
