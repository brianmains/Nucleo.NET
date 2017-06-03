using System;
using System.ComponentModel;
using Nucleo.EventArguments;


namespace Nucleo.Windows.UI
{
	public class Toolbar : UIElement, IParentElement
	{
		private ToolbarItemCollection _items = null;
		private ToolbarLocation _location = ToolbarLocation.Top;



		#region " Event Handlers "

		public event DataEventHandler<ToolbarItem> ChildItemAdded;
		public event CancelEventHandler ChildItemAdding;
		public event DataEventHandler<ToolbarItem> ChildItemInserted;
		public event CancelEventHandler ChildItemInserting;
		public event DataEventHandler<ToolbarItem> ChildItemRemoved;
		public event CancelEventHandler ChildItemRemoving;

		#endregion



		#region " Properties "

		public override ValuePath CurrentPath
		{
			get { return new ValuePath(this.Name); }
		}

		public ToolbarItemCollection Items
		{
			get
			{
				if (_items == null)
				{
					_items = new ToolbarItemCollection();
					_items.ItemAdded += ChildItems_ItemAdded;
					_items.ItemAdding += ChildItems_ItemAdding;
					_items.ItemInserted += ChildItems_ItemInserted;
					_items.ItemInserting += ChildItems_ItemInserting;
					_items.ItemRemoved += ChildItems_ItemRemoved;
					_items.ItemRemoving += ChildItems_ItemRemoving;
				}
				return _items;
			}
		}

		/// <summary>
		/// Gets or sets the location of the toolbar in the API.
		/// </summary>
		public ToolbarLocation Location
		{
			get { return _location; }
			set
			{
				if (_location != value)
				{
					ToolbarLocation oldValue = _location;
					_location = value;

					this.OnPropertyChanged(new Nucleo.EventArguments.PropertyChangedEventArgs("Location", oldValue, _location));
				}
			}
		}

		#endregion



		#region " Constructors "

		public Toolbar(string name, string title)
			: base(name, title) { }

		public Toolbar(string name, string title, ToolbarLocation location)
			: this(name, title)
		{
			_location = location;
		}

		#endregion



		#region " Methods "

		protected virtual void OnChildItemAdded(DataEventArgs<ToolbarItem> e)
		{
			if (ChildItemAdded != null)
				ChildItemAdded(this, e);
		}

		protected virtual void OnChildItemAdding(CancelEventArgs e)
		{
			if (ChildItemAdding != null)
				ChildItemAdding(this, e);
		}

		protected virtual void OnChildItemInserted(DataEventArgs<ToolbarItem> e)
		{
			if (ChildItemInserted != null)
				ChildItemInserted(this, e);
		}

		protected virtual void OnChildItemInserting(CancelEventArgs e)
		{
			if (ChildItemInserting != null)
				ChildItemInserting(this, e);
		}

		protected virtual void OnChildItemRemoved(DataEventArgs<ToolbarItem> e)
		{
			if (ChildItemRemoved != null)
				ChildItemRemoved(this, e);
		}

		protected virtual void OnChildItemRemoving(CancelEventArgs e)
		{
			if (ChildItemRemoving != null)
				ChildItemRemoving(this, e);
		}

		#endregion



		#region " Event Handlers "

		void ChildItems_ItemAdded(object sender, DataEventArgs<ToolbarItem> e)
		{
			this.OnChildItemAdded(e);
		}

		void ChildItems_ItemAdding(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.OnChildItemAdding(e);
		}

		void ChildItems_ItemInserted(object sender, DataEventArgs<ToolbarItem> e)
		{
			this.OnChildItemInserted(e);
		}

		void ChildItems_ItemInserting(object sender, CancelEventArgs e)
		{
			this.OnChildItemInserting(e);
		}

		void ChildItems_ItemRemoved(object sender, DataEventArgs<ToolbarItem> e)
		{
			this.OnChildItemRemoved(e);
		}

		void ChildItems_ItemRemoving(object sender, CancelEventArgs e)
		{
			this.OnChildItemRemoving(e);
		}

		#endregion



		#region " IParentElement Members "

		IElementCollection IParentElement.Items
		{
			get { return this.Items; }
		}

		#endregion
	}
}
