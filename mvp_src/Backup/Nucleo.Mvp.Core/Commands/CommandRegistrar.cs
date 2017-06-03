using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Commands
{
	/// <summary>
	/// Represents a registrar of commands.
	/// </summary>
	public class CommandRegistrar
	{
		private CommandCollection _commands = null;



		private CommandCollection Commands
		{
			get
			{
				if (_commands == null)
					_commands = new CommandCollection();

				return _commands;
			}
		}

		/// <summary>
		/// Gets the total number of commands registered.
		/// </summary>
		public int Count
		{
			get { return Commands.Count; }
		}



		/// <summary>
		/// Creates the command register as empty.
		/// </summary>
		public CommandRegistrar() { }

		public CommandRegistrar(IEnumerable<ICommand> commands)
		{
			Guard.NotNull(commands);

			foreach (var command in commands)
				this.Commands.Add(command);
		}


		/// <summary>
		/// Ges a command by name.
		/// </summary>
		/// <param name="name">The name of the command to find.</param>
		/// <returns>The found command, or null if not found.</returns>
		public ICommand Get(string name)
		{
			return Commands.GetByName(name);
		}

		/// <summary>
		/// Gets all commands.
		/// </summary>
		/// <returns>The list of commands.</returns>
		public CommandCollection GetAll()
		{
			return Commands;
		}

		/// <summary>
		/// Registers a command into the registrar.
		/// </summary>
		/// <param name="command">The command to register.</param>
		public void Register(ICommand command)
		{
			Commands.Add(command);
		}
	}
}
