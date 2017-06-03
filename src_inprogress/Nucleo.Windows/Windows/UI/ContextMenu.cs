using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.UI
{
	public class ContextMenu : UIElement
	{
		private MenuItemCollection _menuItems = null;
		private UIElement _parent = null;



		#region " Properties "

		/// <summary>
		/// Gets the current path to the context menu.
		/// </summary>
		public override ValuePath CurrentPath
		{
			get
			{
				if (_parent == null)
					return new ValuePath(this.Name);
				else
					return new ValuePath(this.Parent.Name, this.Name);
			}
		}

		/// <summary>
		/// Gets the menu items that belong to the context menu.
		/// </summary>
		public MenuItemCollection MenuItems
		{
			get
			{
				if (_menuItems == null)
					_menuItems = new MenuItemCollection();
				return _menuItems;
			}
		}

		/// <summary>
		/// Gets a reference to the parent.
		/// </summary>
		public UIElement Parent
		{
			get { return _parent; }
			internal set { _parent = value; }
		}

		#endregion



		#region " Constructors "

		public ContextMenu(string name)
			: base(name, null) { }

		#endregion
	}
}
