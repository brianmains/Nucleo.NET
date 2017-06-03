using System;
using System.Windows.Forms;

using Nucleo.Windows.Actions;
using API = Nucleo.Windows.UI;


namespace Nucleo.Windows.Application
{
	public class WindowsStripApplicationController : BaseUIApplicationController
	{
		#region " Constructors "

		public WindowsStripApplicationController(ApplicationModel application, MenuStrip menu, TabControl documentArea, TabControl leftSidebar, TabControl rightSidebar)
			: base(application, WindowsMenuRenderer.GetRenderer(menu, application), null, null, WindowsDocumentRenderer.GetRenderer(documentArea, application), WindowsToolWindowRenderer.GetRenderer(leftSidebar, rightSidebar, null, application)) { }

		public WindowsStripApplicationController(ApplicationModel application, MenuStrip menu, ToolStripPanel toolbar, TabControl documentArea, TabControl leftSidebar, TabControl rightSidebar, TabControl bottomSidebar, ToolStripPanel statusBar)
			: base(application, WindowsMenuRenderer.GetRenderer(menu, application), WindowsToolbarRenderer.GetRenderer(toolbar, statusBar, application), WindowsToolbarItemRenderer.GetRenderer(toolbar, statusBar, application), WindowsDocumentRenderer.GetRenderer(documentArea, application), WindowsToolWindowRenderer.GetRenderer(leftSidebar, rightSidebar, bottomSidebar, application)) { }

		#endregion



		#region " Methods "

		///// <summary>
		///// Adds a new document to the document area, by creating a tab for it.
		///// </summary>
		///// <param name="index">The index to add the document at.</param>
		///// <param name="window">The window to add.</param>
		///// <exception cref="Exception">Thrown when the document area is not being used.</exception>
		//protected override void AddDocumentWindow(int index, API.DocumentWindow window)
		//{
		//    if (!this.UseDocumentArea)
		//        throw new Exception();

		//    TabPage page = this.CreateTabPage(window);
		//    _documentArea.TabPages.Insert(index, page);
		//}

		///// <summary>
		///// Adds a menu item to a root menu or a parent menu.
		///// </summary>
		///// <param name="index">The index to add an item to.</param>
		///// <param name="menu">The menu to add.</param>
		///// <exception cref="Exception">Thrown when the menu is not being used.</exception>
		//protected override void AddMenuItem(int index, API.MenuItem menu)
		//{
		//    if (!this.UseMenu)
		//        throw new Exception();

		//    if (menu.Parent == null)
		//        _menu.Items.Insert(index, this.CreateMenu(menu));
		//    else
		//    {
		//        ToolStripMenuItem parentMenu = this.GetParent(menu.Parent);
		//        parentMenu.DropDownItems.Insert(index, this.CreateMenu(menu));
		//    }
		//}

		///// <summary>
		///// Adds a toolbar to the underlying UI control.
		///// </summary>
		///// <param name="index">The index to add an item to.</param>
		///// <param name="toolbar">The toolbar to add.</param>
		///// <exception cref="Exception">Thrown when toolbars are not being used.</exception>
		//protected override void AddToolbar(int index, Nucleo.Windows.UI.Toolbar toolbar)
		//{
		//    if (!this.UseToolbar)
		//        throw new Exception();

		//    ToolStrip strip = new ToolStrip();
		//    strip.Name = toolbar.Name;
		//    strip.Text = toolbar.Title;
		//    strip.Tag = toolbar;

		//    this.GetToolbarPanel(toolbar).Controls.Add(strip);
		//}

		//protected override void AddToolbarItem(int index, Nucleo.Windows.UI.ToolbarItem toolbarItem)
		//{
		//    if (!this.UseToolbar)
		//        throw new Exception();
		//    if (index == -1)
		//        index = 0;

		//    ToolStripItem item = API.ToolbarAssistant.CreateToolbarItem(toolbarItem);
		//    ((ToolStrip)this.GetToolbarPanel(toolbarItem.Parent).Controls[toolbarItem.Parent.Name]).Items.Add(item);
		//}

		///// <summary>
		///// Adds a tool window to the parent collection, by creating a tab page for it.
		///// </summary>
		///// <param name="index">The index to add an item to.</param>
		///// <param name="window">The window to add.</param>
		///// <exception cref="Exception">Thrown when the appropriate tool window area is not being used.</exception>
		//protected override void AddToolWindow(int index, API.ToolWindow window)
		//{
		//    TabPage page = this.CreateTabPage(window);

		//    if (window.Location == API.ToolWindowLocation.Left)
		//    {
		//        if (!this.UseLeftWindow)
		//            throw new Exception();

		//        _leftSidebar.TabPages.Insert(index, page);
		//    }
		//    else if (window.Location == API.ToolWindowLocation.Right)
		//    {
		//        if (!this.UseRightWindow)
		//            throw new Exception();

		//        _rightSidebar.TabPages.Insert(index, page);
		//    }
		//    else if (window.Location == API.ToolWindowLocation.Bottom)
		//    {
		//        if (!this.UseBottomSidebar)
		//            throw new Exception();

		//        _bottomSidebar.TabPages.Insert(index, page);
		//    }
		//    else
		//        throw new NotSupportedException();
		//}

		///// <summary>
		///// This method creates a new menu from a menu item object.
		///// </summary>
		///// <param name="menu"></param>
		///// <returns></returns>
		//private ToolStripMenuItem CreateMenu(API.MenuItem menu)
		//{
		//    ToolStripMenuItem item = new ToolStripMenuItem(menu.Title);
		//    item.Name = menu.Name;
		//    item.Tag = menu;

		//    item.Click += new EventHandler(MenuItem_Click);
		//    return item;
		//}

		///// <summary>
		///// This method creates a new tab page from the information provided by a window.
		///// </summary>
		///// <param name="window">The window to create the tab page for.</param>
		///// <returns></returns>
		//private TabPage CreateTabPage(API.BaseWindow window)
		//{
		//    TabPage page = new TabPage(window.Title);
		//    page.Name = window.Name;
		//    page.Tag = window;
		//    page.Controls.Add(this.GetControlReference(window.UIInterface));
		//    page.Controls[0].Dock = DockStyle.Fill;
		//    this.PerformTheming(page);
		//    return page;
		//}

		///// <summary>
		///// This method iterates through the value path of the parent to find the parent tool strip item.
		///// </summary>
		///// <param name="parent">The menu item that is the parent.</param>
		///// <returns></returns>
		//private ToolStripMenuItem GetParent(API.MenuItem parent)
		//{
		//    ToolStripMenuItem parentItem = null;
		//    bool first = true;

		//    foreach (string pathItem in parent.CurrentPath)
		//    {
		//        if (!first)
		//            parentItem = (ToolStripMenuItem)parentItem.DropDownItems[pathItem];
		//        else
		//        {
		//            parentItem = (ToolStripMenuItem)_menu.Items[pathItem];
		//            first = false;
		//        }
		//    }

		//    return parentItem;
		//}

		//private ToolStripPanel GetToolbarPanel(API.Toolbar toolbar)
		//{
		//    if (toolbar.Location == API.ToolbarLocation.Top)
		//        return _toolbars;
		//    else
		//        return _statusbars;
		//}

		///// <summary>
		///// Allows certain controls to be re-themed appropriately.
		///// </summary>
		///// <param name="control">The control to apply any theming to.</param>
		//protected virtual void PerformTheming(Control control) { }
		
		///// <summary>
		///// Removes a document window from the UI container.
		///// </summary>
		///// <param name="window">The window to remove.</param>
		///// <exception cref="Exception">Thrown when the document area is not being used.</exception>
		//protected override void RemoveDocumentWindow(API.DocumentWindow window)
		//{
		//    if (!this.UseDocumentArea)
		//        throw new Exception();

		//    _documentArea.TabPages.RemoveByKey(window.Name);
		//}

		///// <summary>
		///// Removes a menu item from the UI container, either the root or the parent menu.
		///// </summary>
		///// <param name="menu">The menu to remove.</param>
		///// <exception cref="Exception">Thrown when the menu is not being used.</exception>
		//protected override void RemoveMenuItem(API.MenuItem menu)
		//{
		//    if (!this.UseMenu)
		//        throw new Exception();

		//    ToolStripItem[] items = _menu.Items.Find(menu.Name, true);
		//    if (items == null || items.Length == 0)
		//        return;

		//    ToolStripMenuItem item = items[0] as ToolStripMenuItem;
		//    if (item != null)
		//    {
		//        if (item.OwnerItem != null && item.OwnerItem is ToolStripMenuItem)
		//            ((ToolStripMenuItem)item.OwnerItem).DropDownItems.Remove(item);
		//        else
		//            _menu.Items.Remove(item);
		//    }
		//}

		///// <summary>
		///// Removes a menu item from the UI container, either the root or the parent menu.
		///// </summary>
		///// <param name="toolbar">The toolbar to remove.</param>
		//protected override void RemoveToolbar(API.Toolbar toolbar)
		//{
		//    this.GetToolbarPanel(toolbar).Controls.RemoveByKey(toolbar.Name);
		//}

		//protected override void RemoveToolbarItem(Nucleo.Windows.UI.ToolbarItem toolbarItem)
		//{
		//    this.GetToolbarPanel(toolbarItem.Parent).Controls[toolbarItem.Parent.Name].Controls.RemoveByKey(toolbarItem.Name);
		//}

		///// <summary>
		///// The tool window to remove from the UI collection, based on the location.
		///// </summary>
		///// <param name="window">The window to remove.</param>
		///// <exception cref="Exception">Thrown when the appropriate tool window area is not being used.</exception>
		//protected override void RemoveToolWindow(API.ToolWindow window)
		//{
		//    if (window.Location == API.ToolWindowLocation.Left)
		//    {
		//        if (!this.UseLeftWindow)
		//            throw new Exception();

		//        _leftSidebar.TabPages.RemoveByKey(window.Name);
		//    }
		//    else if (window.Location == API.ToolWindowLocation.Right)
		//    {
		//        if (!this.UseRightWindow)
		//            throw new Exception();

		//        _rightSidebar.TabPages.RemoveByKey(window.Name);
		//    }
		//    else
		//        throw new NotSupportedException();
		//}

		//#endregion



		//#region " Event Handlers "

		///// <summary>
		///// Captures the menu item click and processes it accordingly.
		///// </summary>
		///// <param name="sender">The control raising the event.</param>
		///// <param name="e">Empty.</param>
		//void MenuItem_Click(object sender, EventArgs e)
		//{
		//    ToolStripMenuItem item = (ToolStripMenuItem)sender;
		//    API.MenuItem menu = (API.MenuItem)item.Tag;

		//    this.Application.PerformAction(menu, new ClickAction());
		//}

		#endregion
	}
}
