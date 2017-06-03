using System;
using System.Windows.Forms;
using API = Nucleo.Windows.UI;


namespace Nucleo.Windows.Application
{
	public class WindowsMenuRenderer : InterfaceRenderer<API.MenuItem>
	{
		private ApplicationModel _application = null;
		private MenuStrip _strip = null;



		#region " Properties "

		public ApplicationModel Application
		{
			get { return _application; }
		}

		public MenuStrip Menu
		{
			get { return _strip; }
		}

		#endregion



		#region " Constructors "

		public WindowsMenuRenderer(MenuStrip strip, ApplicationModel application)
		{
			if (strip == null)
				throw new ArgumentNullException("strip");
			if (application == null)
				throw new ArgumentNullException("application");

			_strip = strip;
			_application = application;

			if (!_strip.IsHandleCreated)
				_strip.CreateControl();
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an item to the menu at the specified index.
		/// </summary>
		/// <param name="index">The index to insert the item in.</param>
		/// <param name="uiItem">The item to add.</param>
		public override void AddItem(int index, API.MenuItem uiItem)
		{
			ToolStripMenuItem childItem = this.CreateMenuItem();
			childItem.Name = uiItem.Name;
			childItem.Text = uiItem.Title;
			childItem.Tag = uiItem;
			childItem.Click += MenuItem_Click;

			if (uiItem.Parent != null)
			{
				ToolStripItem[] parentMenu = this._strip.Items.Find(uiItem.Parent.Name, true);
				if (parentMenu == null || parentMenu.Length == 0) return;
				((ToolStripMenuItem)parentMenu[0]).DropDownItems.Insert(index, childItem);
			}
			else
				this._strip.Items.Insert(index, childItem);
		}

		/// <summary>
		/// Adds an item to the menu.
		/// </summary>
		/// <param name="uiItem">The item to add.</param>
		public override void AddItem(API.MenuItem uiItem)
		{
			if (uiItem.Parent != null)
				this.AddItem(uiItem.Parent.Items.Count - 1, uiItem);
			else
				this.AddItem(this._strip.Items.Count - 1, uiItem);
		}

		/// <summary>
		/// Creates an instance of a menu item being displayed in the windows menu system.
		/// </summary>
		/// <param name="uiItem">The item to add.</param>
		/// <returns>An instance of a tool strip menu item class.</returns>
		protected virtual ToolStripMenuItem CreateMenuItem()
		{
			return new ToolStripMenuItem();
		}

		public static WindowsMenuRenderer GetRenderer(MenuStrip control, ApplicationModel application)
		{
			if (control != null)
				return new WindowsMenuRenderer(control, application);
			else
				return null;
		}

		public override void RemoveItem(API.MenuItem uiItem)
		{
			if (uiItem.Parent != null)
			{
				ToolStripItem[] parentMenu = this._strip.Items.Find(uiItem.Parent.Name, true);
				if (parentMenu == null || parentMenu.Length == 0) return;
				((ToolStripMenuItem)parentMenu[0]).DropDownItems.RemoveByKey(uiItem.Name);
			}
			else
				this._strip.Items.RemoveByKey(uiItem.Name);
		}

		#endregion



		#region " Event Handlers "

		void MenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = sender as ToolStripMenuItem;
			if (item == null) return;
			API.MenuItem menu = (API.MenuItem)item.Tag;

			if (menu.Command != null && menu.Command.CanExecute())
				menu.Command.Execute();
			
		}

		//void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		//{
		//    ToolStripMenuItem item = e.ClickedItem as ToolStripMenuItem;
		//    if (item == null) return;
		//    API.MenuItem menu = (API.MenuItem)item.Tag;

		//    this.Application.PerformAction(menu, Actions.ActionsList.Click());
		//}

		#endregion
	}
}
