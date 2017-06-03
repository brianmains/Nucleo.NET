using System;
using System.Reflection;
using System.Collections.Generic;
using Nucleo.Collections;
using Nucleo.EventArguments;


namespace Nucleo.Windows.UI
{
	public abstract class BaseWindowCollection<T> : UIElementCollection<T>
		where T : BaseWindow
	{
		private T _selected = null;



		#region " Events "

		/// <summary>
		/// Occurs when the selection changed.
		/// </summary>
		public event DataEventHandler<T> SelectedIndexChanged;

		#endregion



		#region " Properties "

		/// <summary>
		/// The object that is currently selected.
		/// </summary>
		public T Selected
		{
			get { return _selected; }
			set
			{
				if (_selected != value)
				{
					_selected = value;
					this.OnSelectedIndexChanged(new DataEventArgs<T>(value));
				}
			}
		}

		#endregion



		#region " Methods "

		public override void Add(T item)
		{
			item.PropertyChanged += Item_PropertyChanged;
			base.Add(item);
		}

		public override void Insert(int index, T item)
		{
			item.PropertyChanged += Item_PropertyChanged;
			base.Insert(index, item);
		}

		/// <summary>
		/// Raises the selected index changed event.
		/// </summary>
		/// <param name="e">The item that was selected.</param>
		protected virtual void OnSelectedIndexChanged(DataEventArgs<T> e)
		{
			if (SelectedIndexChanged != null)
				SelectedIndexChanged(this, e);
		}

		public override bool Remove(T item)
		{
			item.PropertyChanged -= Item_PropertyChanged;
			return base.Remove(item);
		}

		/// <summary>
		/// Validates the name and the title of the window.
		/// </summary>
		/// <param name="name">The name of the window.</param>
		/// <param name="title">The title of the window.</param>
		protected void ValidateNameAndTitle(string name, ref string title)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");
			if (this.Contains(name))
				throw new ArgumentException("The window already exists in the collection", "name");
			if (string.IsNullOrEmpty(title))
				title = "Untitled";
		}

		#endregion



		#region " Event Handlers "

		void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (string.Compare(e.PropertyName, "Visible", true) == 0)
				this.Selected = (T)sender;
		}

		#endregion
	}
}
