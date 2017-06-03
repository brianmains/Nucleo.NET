using System;

using Nucleo.Collections;
using Nucleo.Windows.UI;
using Nucleo.Windows.Commands;


namespace Nucleo.Windows.Application
{
	public abstract class BaseModule : IModule
	{
		private ModuleElementCollection _associates = null;
		private CommandDictionary _commands = null;



		#region " Events "

		public event EventHandler Activated;
		public event EventHandler Inactivated;
		public event EventHandler Hiding;
		public event EventHandler Showing;

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets a list of associated items that aren't in the user interface, but are associated with the module.
		/// </summary>
		public ModuleElementCollection Associates
		{
			get
			{
				if (_associates == null)
					_associates = new ModuleElementCollection();
				return _associates;
			}
		}

		/// <summary>
		/// Gets a list of commands that are linked to the base module.
		/// </summary>
		public CommandDictionary Commands
		{
			get
			{
				if (_commands == null)
					_commands = new CommandDictionary();
				return _commands;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Hides all of the items in the module.
		/// </summary>
		public virtual void Hide()
		{
			foreach (UIElement item in this.Associates)
				item.Visible = false;
			foreach (ICommand command in this.Commands)
			{
				if (command is HideCommand)
				{
					if (command.CanExecute())
						command.Execute();
				}
			}

			this.OnHiding(EventArgs.Empty);
			this.OnInactivated(EventArgs.Empty);
		}

		void IModule.Hide()
		{
			this.Hide();
		}

		protected internal virtual void Initialize() { }

		void IModule.Initialize()
		{
			this.Initialize();
		}

		/// <summary>
		/// Raises the activated event.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected virtual void OnActivated(EventArgs e)
		{
			if (Activated != null)
				Activated(this, e);
		}

		/// <summary>
		/// Raises the inactivated event.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected virtual void OnInactivated(EventArgs e)
		{
			if (Inactivated != null)
				Inactivated(this, e);
		}

		protected virtual void OnHiding(EventArgs e)
		{
			if (Hiding != null)
				Hiding(this, e);
		}

		protected virtual void OnShowing(EventArgs e)
		{
			if (Showing != null)
				Showing(this, e);
		}

		/// <summary>
		/// Shows all of the items in the module.  Shows all associated items, and triggers any show commands.
		/// </summary>
		public virtual void Show()
		{
			foreach (UIElement item in this.Associates)
				item.Visible = true;
			foreach (ICommand command in this.Commands)
			{
				if (command is ShowCommand)
				{
					if (command.CanExecute())
						command.Execute();
				}
			}

			this.OnShowing(EventArgs.Empty);
			this.OnActivated(EventArgs.Empty);
		}

		void IModule.Show()
		{
			this.Show();
		}

		protected internal virtual void Shutdown() { }

		void IModule.Shutdown()
		{
			this.Shutdown();
		}

		#endregion
	}
}
