using System;


namespace Nucleo.Windows.Commands
{
	public abstract class BaseCommand : ICommand
	{
		#region " Events "

		/// <summary>
		/// Notifies that the command was successfully executed.
		/// </summary>
		public event EventHandler Executing;

		#endregion



		#region " Properties "

		public abstract string CommandName { get; }

		#endregion



		#region " Methods "

		/// <summary>
		/// Whether the command can be executed.
		/// </summary>
		/// <returns>Whether the command can be executed.</returns>
		public virtual bool CanExecute()
		{
			return (this.Executing != null);
		}

		/// <summary>
		/// Executes the command.  Throws an exception if the command can't be executed.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown whenever the <see cref="CanExecute" /> method returns false.</exception>
		public virtual void Execute()
		{
			if (!this.CanExecute())
				throw new InvalidOperationException("The command cannot be executed");

			this.OnExecuting(EventArgs.Empty);
		}

		/// <summary>
		/// Triggers the <see cref="Executing" /> event.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected virtual void OnExecuting(EventArgs e)
		{
			if (Executing != null)
				Executing(this, e);
		}
		
		#endregion
	}
}
