using System;
using Nucleo.EventArguments;


namespace Nucleo.Collections
{
	public class SelectableCollectionBase<T> : CollectionBase<T>
	{
		private T _selected = default(T);



		#region " Events "

		/// <summary>
		/// Raised when the value stored in the <see cref="Selected"/> property has changed.
		/// </summary>
		public event DataEventHandler<T> SelectionChanged;

		/// <summary>
		/// Raised when the <see cref="Selected"/> property has changed, from null to not null, or vice versa.  This event doesn't fire on every selection assignment.
		/// </summary>
		public event EventHandler SelectionNullStatusChanged;

		#endregion



		#region " Properties "

		/// <summary>
		/// The current item in the collection that is selected.
		/// </summary>
		public virtual T Selected
		{
			get { return _selected; }
			set
			{
				if (!object.Equals(_selected, value))
				{
					T oldSelected = _selected;
					_selected = value;

					this.OnSelectionChanged(new DataEventArgs<T>(value));
					if (this.IsNullChange(oldSelected, _selected))
						this.OnSelectionNullStatusChanged(EventArgs.Empty);
				}
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Determines whether the previous (selected) and the new (value) properties are different null-wise.
		/// </summary>
		/// <param name="selected">The currently selected value (previous).</param>
		/// <param name="value">The newly selected value (new).</param>
		/// <returns>Whether the null status changed.</returns>
		private bool IsNullChange(T selected, T value)
		{
			if (selected != null && value == null)
				return true;
			else if (selected == null && value != null)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Raises the selection changed event.
		/// </summary>
		/// <param name="e">The details regarding the new selection.</param>
		protected virtual void OnSelectionChanged(DataEventArgs<T> e)
		{
			if (SelectionChanged != null)
				SelectionChanged(this, e);
		}

		/// <summary>
		/// Raises the selection null status changed event.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected virtual void OnSelectionNullStatusChanged(EventArgs e)
		{
			if (SelectionNullStatusChanged != null)
				SelectionNullStatusChanged(this, e);
		}

		#endregion
	}
}
