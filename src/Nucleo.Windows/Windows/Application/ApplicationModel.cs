using System;
using System.ComponentModel;
using Nucleo.EventArguments;
using Nucleo.Windows.UI;
using Nucleo.Windows.Actions;
using Nucleo.Collections;


namespace Nucleo.Windows.Application
{
	public class ApplicationModel
	{
		private DocumentWindowCollection _documentWindows = null;
		private MenuItemCollection _menus = null;
		private PopupWindowCollection _popupWindows = null;
		private StatusLabel _statusLabel = null;
		private ToolbarCollection _toolbars = null;
		private ToolWindowCollection _toolWindows = null;
		private NameRegister _register = null;



		#region " Events "

		public event ApplicationModelEventHandler ItemAdded;
		public event ApplicationModelEventHandler ItemRemoved;

		#endregion



		#region " Properties "

		/// <summary>
		/// The collection of documents in the main windows.
		/// </summary>
		protected internal DocumentWindowCollection DocumentWindows
		{
			get
			{
				if (_documentWindows == null)
					_documentWindows = new DocumentWindowCollection();

				return _documentWindows;
			}
		}

		/// <summary>
		/// Gets the collection of top-level menu items registered with the application.
		/// </summary>
		protected internal MenuItemCollection Menus
		{
			get
			{
				if (_menus == null)
					_menus = new MenuItemCollection();

				return _menus;
			}
		}

		/// <summary>
		/// Gets the collection of popup windows registered with the application.
		/// </summary>
		protected internal PopupWindowCollection PopupWindows
		{
			get
			{
				if (_popupWindows == null)
					_popupWindows = new PopupWindowCollection();

				return _popupWindows;
			}
		}

		/// <summary>
		/// The status to display about the application, usually displayed in a status bar.
		/// </summary>
		public string Status
		{
			get
			{
				if (this._statusLabel != null)
					return this._statusLabel.Text;
				else
					return string.Empty;
			}
			set
			{
				if (this._statusLabel == null)
					throw new NullReferenceException("The Status Label has not been created");

				this._statusLabel.Text = value;
			}
		}

		/// <summary>
		/// The collection of toolbars that are displayed in the top section of the form.
		/// </summary>
		protected internal ToolbarCollection Toolbars
		{
			get
			{
				if (_toolbars == null)
					_toolbars = new ToolbarCollection();
				return _toolbars;
			}
		}

		/// <summary>
		/// The collection of tool windows that make up the left and right sides of the application.
		/// </summary>
		protected internal ToolWindowCollection ToolWindows
		{
			get
			{
				if (_toolWindows == null)
					_toolWindows = new ToolWindowCollection();
				return _toolWindows;
			}
		}

		#endregion



		#region " Constructors "

		protected ApplicationModel()
		{
			_register = new NameRegister();
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a single item to the appropriate repository.
		/// </summary>
		/// <param name="element">The element to add to the repository.</param>
		public void AddItem(UIElement element)
		{
			this.AddItemToCollection(-1, element);	
		}

		/// <summary>
		/// Adds a child to a parent element.
		/// </summary>
		/// <param name="parent">The parent to add.</param>
		/// <param name="child">The child to add to the parent.</param>
		public void AddItem(UIElement parent, UIElement child)
		{
			this.AddItemToCollection(-1, parent, child);
		}

		/// <summary>
		/// Adds an item to the repository at the specified index.
		/// </summary>
		/// <param name="index">The index value to add an item to.</param>
		/// <param name="element">The element to add.</param>
		public void AddItem(int index, UIElement element)
		{
			if (index < 0)
				throw new ArgumentOutOfRangeException("index");

			this.AddItemToCollection(index, element);
		}

		/// <summary>
		/// Adds a child item to its respective parent.  For the parent/child relationship to work, the parent must implement <see cref="UI.IParentElement" /> and the child must implement <see cref="UI.IChildElement" />.
		/// </summary>
		/// <param name="index">The index to add the item at.</param>
		/// <param name="parent">The parent item that can accept children.</param>
		/// <param name="child">The child to add to the parent collection.</param>
		public void AddItem(int index, UIElement parent, UIElement child)
		{
			if (index < 0)
				throw new ArgumentOutOfRangeException("index");

			this.AddItemToCollection(index, parent, child);
		}

		protected void AddItemToCollection(int index, UIElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			if (!this.IsValidName(element))
				throw new ArgumentException(string.Format("An element with the name '{0}' already exists, or the name is not valid.", element.Name));

			//If a child element, which means it has a parent, if the parent isn't null, use the overload
			if (element is IChildElement)
			{
				IChildElement child = (IChildElement)element;
				if (child.Parent != null)
				{
					this.AddItemToCollection(index, child.Parent, element);
					return;
				}
			}

			if (!this.IsValidSingleItem(element))
				throw new ArgumentException(string.Format("The element of type {0} cannot be added using this overload.", element.GetType().Name));

			this.OnItemAdded(new ApplicationModelEventArgs(element, index, this));
			if (index > 0)
				this.GetCollection(element.GetType()).Insert(index, element);
			else
				this.GetCollection(element.GetType()).Add(element);

			_register.Add(element);
			this.CheckForStatusLabel(element);
		}

		protected void AddItemToCollection(int index, UIElement parent, UIElement child)
		{
			if (parent == null)
				throw new ArgumentNullException("parent");
			if (child == null)
				throw new ArgumentNullException("child");
			if (!this.IsValidChildItem(parent, child))
				throw new ArgumentException(string.Format("The element {0} cannot be added as a child of {1}.", child.GetType().Name, parent.GetType().Name));
			if (!this.IsValidName(child))
				throw new ArgumentException(string.Format("An element with the name '{0}' already exists, or the name is not valid.", child.Name));

			if (index > 0)
				((IParentElement)parent).Items.Insert(index, child);
			else
				((IParentElement)parent).Items.Add(child);

			this.OnItemAdded(new ApplicationModelEventArgs(parent, child, index, this));
			_register.Add(child);
			this.CheckForStatusLabel(child);
		}

		private void CheckForStatusLabel(UIElement element)
		{
			if (element is StatusLabel)
			{
				//if the element is a status label, which only one can exist in the application,
				//then determine if one already exists, and if so throw an exception.  Otherwise,
				//assign it to the local variable.
				if (_statusLabel != null)
					throw new Exception("The status label has already been assigned");
				_statusLabel = (StatusLabel)element;
			}
		}

		/// <summary>
		/// Whether an item exists in the model with the designated name.
		/// </summary>
		/// <param name="itemName">The item to determine whether it exists.</param>
		/// <returns>Whether the item exists.</returns>
		/// <exception cref="ArgumentNullException">Thrown whenever the item name is null.</exception>
		public bool ContainsItem(string itemName)
		{
			if (string.IsNullOrEmpty(itemName))
				throw new ArgumentNullException("itemName");

			return _register.Contains(itemName);
		}

		/// <summary>
		/// Whether an item exists in the model, by reference.
		/// </summary>
		/// <param name="element">The item to determine whether it exists.</param>
		/// <returns>Whether the item exists.</returns>
		/// <exception cref="ArgumentNullException">Thrown whenever the element is null.</exception>
		public bool ContainsItem(UIElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			IElementCollection collection = this.GetCollection(element.GetType());
			if (collection != null)
				return collection.Contains(element);
			else
				return false;
		}

		/// <summary>
		/// Whether an item exists in the model for a specified type.
		/// </summary>
		/// <typeparam name="T">The type of item to look in its respective collection.</typeparam>
		/// <param name="name">The name of the item to find in the respective collection.</param>
		/// <returns>Whether the item was found by name.</returns>
		/// <exception cref="ArgumentNullException">Thrown whenever the name is null.</exception>
		public bool ContainsItem<T>(string name) where T : UIElement
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			return this.GetCollection<T>().Contains(new ValuePath(name));
		}

		/// <summary>
		/// Uses a value path to traverse the designated item collection to see if the item exists.
		/// </summary>
		/// <typeparam name="T">The specified item type to look for.</typeparam>
		/// <param name="path">The path of values to use to navigate through the list.</param>
		/// <returns>Whether the item exists.</returns>
		/// <exception cref="ArgumentNullException">Thrown whenever the path is null.</exception>
		/// <example>
		/// ValuePath path = new ValuePath("File", "New", "C# File");
		/// Assert.IsTrue(_model.ContainsItem&lt;MenuItem&gt;(path));
		/// </example>
		public bool ContainsItem<T>(ValuePath path) where T : UIElement
		{
			if (path == null)
				throw new ArgumentNullException("path");

			return this.GetCollection<T>().Contains(path);
		}

		public bool ContainsItem<T>(T item) where T : UIElement
		{
			return this.GetCollection<T>().Contains(item);
		}

		private IElementCollection GetCollection(Type elementType)
		{
			if (elementType == typeof(DocumentWindow))
				return this.DocumentWindows;
			if (elementType == typeof(ToolWindow))
				return this.ToolWindows;
			if (elementType == typeof(MenuItem))
				return this.Menus;
			if (elementType == typeof(Toolbar) ||
			         elementType == typeof(ToolbarItem) ||
			         elementType.IsAssignableFrom(elementType))
				return this.Toolbars;
			if (elementType == (typeof(PopupWindow)))
				return this.PopupWindows;

			return null;
		}

		private IElementCollection GetCollection<T>() where T : UIElement
		{
			return this.GetCollection(typeof(T));
		}

		/// <summary>
		/// Gets the count from the specified collection.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public int GetCount<T>() where T:UIElement
		{
			return this.GetCollection<T>().Count;
		}

		/// <summary>
		/// Gets the item that is in a collection with the specified name.
		/// </summary>
		/// <typeparam name="T">The type of item to retrieve, which uses the type to get the respective collection of items.</typeparam>
		/// <param name="name">The name of the item to find.</param>
		/// <returns>The instance of the item, or null if not found.</returns>
		public T GetItem<T>(string name) where T : UIElement
		{
			IElementCollection collection = this.GetCollection<T>();

			if (collection == null)
				return null;

			return (T)collection[name];
		}

		/// <summary>
		/// Gets the item from the specified value path.
		/// </summary>
		/// <typeparam name="T">The type of item to retrieve, which uses the type to get the respective collection of items.</typeparam>
		/// <param name="path">The path to use to navigate through the collection.</param>
		/// <returns>The instance of the item, or null if not found.</returns>
		public T GetItem<T>(ValuePath path) where T : UIElement
		{
			IElementCollection collection = this.GetCollection<T>();

			if (collection != null)
				return (T)collection[path];
			else
				return null;
		}

		/// <summary>
		/// Instantiates the application model object using the singleton pattern.
		/// </summary>
		/// <returns>An instance of the application model.</returns>
		public static ApplicationModel Instantiate()
		{
			return new ApplicationModel();
		}

		/// <summary>
		/// Determines whether the parent element, and the child element, are valid parent/child relationship items.
		/// </summary>
		/// <param name="parent">The parent element to compare.</param>
		/// <param name="child">The child element to compare.</param>
		/// <returns>Whether the relationship is valid.</returns>
		private bool IsValidChildItem(UIElement parent, UIElement child)
		{
			if (!(parent is IParentElement))
				return false;
			if (!(child is IChildElement))
				return false;

			return true;
		}

		/// <summary>
		/// Whether an item is a valid single root item, which means that the item cannot be added at the root level.
		/// </summary>
		/// <param name="element">The item to determine if it is a valid single-level item.</param>
		/// <returns>Whether the item is a single-level item.</returns>
		private bool IsValidSingleItem(UIElement element)
		{
			if (element is ToolbarItem)
				return false;
			else
				return true;
		}

		/// <summary>
		/// Whether the element's name is a valid name, meaning it's not null and it doesn't already exist.
		/// </summary>
		/// <param name="element">The element to determine validity for.</param>
		/// <returns></returns>
		private bool IsValidName(UIElement element)
		{
			if (string.IsNullOrEmpty(element.Name))
				return false;
			return !_register.Contains(element.Name);
		}

		/// <summary>
		/// Fires the <see cref="ItemAdded" /> event.
		/// </summary>
		/// <param name="e">The details about the added item.</param>
		protected virtual void OnItemAdded(ApplicationModelEventArgs e)
		{
			if (ItemAdded != null)
				ItemAdded(this, e);
		}

		/// <summary>
		/// Fires the <see cref="ItemRemoved" /> event.
		/// </summary>
		/// <param name="e">The details about the removed item.</param>
		protected virtual void OnItemRemoved(ApplicationModelEventArgs e)
		{
			if (ItemRemoved != null)
				ItemRemoved(this, e);
		}
		
		/// <summary>
		/// Removes an item from its designated collection.
		/// </summary>
		/// <param name="element">The item to remove.</param>
		public void RemoveItem(UIElement element)
		{
			this.RemoveItemInternal(element);
		}

		/// <summary>
		/// Removes a child from its designated parent.
		/// </summary>
		/// <param name="parent">The parent item to remove a child from.</param>
		/// <param name="child">The child to remove.</param>
		public void RemoveItem(UIElement parent, UIElement child)
		{
			if (parent == null)
				throw new ArgumentNullException("parent");
			if (child == null)
				throw new ArgumentNullException("child");
			if (!this.IsValidChildItem(parent, child))
				throw new ArgumentException(string.Format("The element {0} cannot be added as a child of {1}.", child.GetType().Name, parent.GetType().Name));
			if (!this.IsValidName(child))
				throw new ArgumentException(string.Format("An element with the name '{0}' already exists, or the name is not valid.", child.Name));

			this.OnItemRemoved(new ApplicationModelEventArgs(parent, child, -1, this));
			((IParentElement)parent).Items.Remove(child);
			_register.Remove(child);

			if (child is StatusLabel)
				_statusLabel = null;
		}

		/// <summary>
		/// Removes root-level items that are found in the specified collection by type.  Does not work for child menu items or toolbar items.
		/// </summary>
		/// <typeparam name="T">The type that denotes the collection to look in.</typeparam>
		/// <param name="name">The name of the item to find.</param>
		public void RemoveItem<T>(string name) where T: UIElement
		{
			this.RemoveItem<T>(new ValuePath(name));
		}

		/// <summary>
		/// Uses a value path to navigate through a hierarchy of items and remove the last one in the list.
		/// </summary>
		/// <typeparam name="T">The type of item to remove.</typeparam>
		/// <param name="path">The path to navigate through, and find the respective item.</param>
		/// <example>
		/// ValuePath path = new ValuePath("File", "New");
		/// _model.RemoveItem&lt;MenuItem&gt;(path);
		/// </example>
		public void RemoveItem<T>(ValuePath path) where T : UIElement
		{
			UIElement item = this.GetCollection<T>()[path];
			if (item == null)
				throw new ArgumentNullException("path", "The item does not exist at the specified path");

			this.RemoveItem(item);

			if (item is StatusLabel)
				_statusLabel = null;
		}

		/// <summary>
		/// Removes an item from the collection for the specified type.
		/// </summary>
		/// <typeparam name="T">A type that derives from UIElement.</typeparam>
		/// <param name="item">The item to remove from the collection.</param>
		public void RemoveItem<T>(T item) where T : UIElement
		{
			this.RemoveItemInternal(item);

			if (item is StatusLabel)
				_statusLabel = null;
		}

		private void RemoveItemInternal(UIElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			if (!this.IsValidSingleItem(element))
				throw new ArgumentException(string.Format("The element of type {0} cannot be removed using this overload.", element.GetType().Name));

			this.OnItemRemoved(new ApplicationModelEventArgs(element, -1, this));
			this.GetCollection(element.GetType()).Remove(element);
			_register.Remove(element);

			if (element is StatusLabel)
				_statusLabel = null;
		}

		#endregion
	}
}
