using System;
using System.Collections.Generic;


namespace Nucleo.Windows.Commands
{
	public class CommandDictionary : IEnumerable<ICommand>
	{
		private List<ICommand> _items = null;



		#region " Properties "

		public int Count
		{
			get { return this.Items.Count; }
		}

		protected List<ICommand> Items
		{
			get
			{
				if (_items == null)
					_items = new List<ICommand>();
				return _items;
			}
		}

		#endregion



		#region " Constructors "

		public CommandDictionary() { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a command to the dictionary; the command's type must be unique.
		/// </summary>
		/// <param name="command">The command to add.</param>
		public void Add(ICommand command)
		{
			this.Items.Add(command);
		}

		/// <summary>
		/// Returns whether the designated command is in the dictionary based on its type.
		/// </summary>
		/// <typeparam name="T">The type of command to check.</typeparam>
		/// <returns>Whether the item is in the collection.</returns>
		/// <remarks>Uses the <see cref="Get<T>"/> method to perform the check.</remarks>
		public bool Contains<T>()
			where T : ICommand
		{
			return (this.Get<T>() != null);
		}

		/// <summary>
		/// Gets a reference to the designated command based on its type.
		/// </summary>
		/// <typeparam name="T">The type of command to check.</typeparam>
		/// <returns>Whether the item is in the collection.</returns>
		public T Get<T>()
			where T : ICommand
		{
			foreach (ICommand command in this.Items)
			{
				if (command is T)
					return (T)command;
			}

			return default(T);
		}

		public IEnumerator<ICommand> GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Items.GetEnumerator();
		}

		/// <summary>
		/// Removes a reference to the item in the list.
		/// </summary>
		/// <typeparam name="T">The type to remove an item for.</typeparam>
		public void Remove<T>()
			where T : ICommand
		{
			this.Remove(this.Get<T>());
		}

		/// <summary>
		/// Removes a reference to the item in the list.
		/// </summary>
		/// <param name="command">The command to remove.</param>
		public void Remove(ICommand command)
		{
			this.Items.Remove(command);
		}

		#endregion
	}
}
