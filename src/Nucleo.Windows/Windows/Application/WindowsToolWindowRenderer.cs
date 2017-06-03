using System;
using System.Windows.Forms;

using API = Nucleo.Windows.UI;


namespace Nucleo.Windows.Application
{
	public class WindowsToolWindowRenderer : InterfaceRenderer<API.ToolWindow>
	{
		private ApplicationModel _application = null;
		private TabControl _bottomWindow = null;
		private TabControl _leftWindow = null;
		private TabControl _rightWindow = null;



		#region " Properties "

		public ApplicationModel Application
		{
			get { return _application; }
		}

		/// <summary>
		/// Gets a reference to the control that represents the bottom toolwindow region.
		/// </summary>
		public TabControl BottomWindow
		{
			get { return _bottomWindow; }
		}

		/// <summary>
		/// Gets a reference to the control that represents the left toolwindow region.
		/// </summary>
		public TabControl LeftWindow
		{
			get { return _leftWindow; }
		}

		/// <summary>
		/// Gets a reference to the control that represents the right toolwindow region.
		/// </summary>
		public TabControl RightWindow
		{
			get { return _rightWindow; }
		}

		#endregion



		#region " Constructors "

		public WindowsToolWindowRenderer(TabControl leftWindow, ApplicationModel application)
		{
			if (leftWindow == null)
				throw new ArgumentNullException("leftWindow");
			_leftWindow = leftWindow;
			_application = application;

			if (!_leftWindow.IsHandleCreated)
				_leftWindow.CreateControl();
		}

		public WindowsToolWindowRenderer(TabControl leftWindow, TabControl rightWindow, ApplicationModel application)
			: this(leftWindow, application)
		{
			if (rightWindow == null)
				throw new ArgumentNullException("rightWindow");
			_rightWindow = rightWindow;

			if (!_rightWindow.IsHandleCreated)
				_rightWindow.CreateControl();
		}

		public WindowsToolWindowRenderer(TabControl leftWindow, TabControl rightWindow, TabControl bottomWindow, ApplicationModel application)
			: this(leftWindow, rightWindow, application)
		{
			if (bottomWindow == null)
				throw new ArgumentNullException("bottomWindow");
			_bottomWindow = bottomWindow;

			if (!_bottomWindow.IsHandleCreated)
				_bottomWindow.CreateControl();
		}

		#endregion



		#region " Methods "

		public override void AddItem(API.ToolWindow uiItem)
		{
			this.AddItem(this.GetTabControl(uiItem.Location).TabPages.Count - 1, uiItem);
		}

		public override void AddItem(int index, API.ToolWindow uiItem)
		{
			if (uiItem == null)
				throw new ArgumentNullException("menu");

			TabPage page = this.CreateTabPage(uiItem);
			this.GetTabControl(uiItem.Location).TabPages.Insert(index, page);
		}

		/// <summary>
		/// Creates an instance of the tab page, using the information provided by the toolwindow.
		/// </summary>
		/// <param name="uiItem"></param>
		/// <returns></returns>
		private TabPage CreateTabPage(API.ToolWindow uiItem)
		{
			TabPage page = new TabPage();
			page.Name = uiItem.Name;
			page.Text = uiItem.Title;
			page.Tag = uiItem;
			page.Controls.Add(this.GetControlReference(uiItem.UIInterface));
			page.Controls[0].Dock = DockStyle.Fill;

			return page;
		}

		public static WindowsToolWindowRenderer GetRenderer(TabControl leftSidebar, TabControl rightSidebar, TabControl bottomSidebar, ApplicationModel application)
		{
			if (leftSidebar != null)
			{
				if (rightSidebar != null)
				{
					if (bottomSidebar != null)
						return new WindowsToolWindowRenderer(leftSidebar, rightSidebar, bottomSidebar, application);
					else
						return new WindowsToolWindowRenderer(leftSidebar, rightSidebar, application);
				}
				else
					return new WindowsToolWindowRenderer(leftSidebar, application);
			}

			return null;
		}

		/// <summary>
		/// Gets a reference to the underlying control at the specified location.
		/// </summary>
		/// <param name="location">The location to get a control for.</param>
		/// <returns>An instance of a control (in this case, a tab control).</returns>
		/// <exception cref="NotImplementedException">Thrown when a location does not match the list of expected locations.</exception>
		private TabControl GetTabControl(API.ToolWindowLocation location)
		{
			if (location == API.ToolWindowLocation.Left)
				return _leftWindow;
			else if (location == API.ToolWindowLocation.Right)
				return _rightWindow;
			else if (location == API.ToolWindowLocation.Bottom)
				return _bottomWindow;
			else
				throw new NotImplementedException(string.Format("A tool window container at the {0} position was not initialized", location));
		}

		public override void RemoveItem(API.ToolWindow uiItem)
		{
			this.GetTabControl(uiItem.Location).TabPages.RemoveByKey(uiItem.Name);
		}

		#endregion
	}
}
