using System;
using System.Windows.Forms;

using API = Nucleo.Windows.UI;


namespace Nucleo.Windows.Application
{
	public class WindowsToolbarRenderer : InterfaceRenderer<API.Toolbar>
	{
		private ApplicationModel _application = null;
		private ToolStripPanel _toolbars = null;
		private ToolStripPanel _statusbars = null;



		#region " Properties "

		public ApplicationModel Application
		{
			get { return _application; }
		}

		public ToolStripPanel Statusbars
		{
			get { return _statusbars; }
		}

		public ToolStripPanel Toolbars
		{
			get { return _toolbars; }
		}

		#endregion



		#region " Constructors "

		public WindowsToolbarRenderer(ToolStripPanel toolbars, ApplicationModel application)
		{
			if (toolbars == null)
				throw new ArgumentNullException("toolbars");

			_toolbars = toolbars;
			_application = application;

			if (!_toolbars.IsHandleCreated)
				_toolbars.CreateControl();
		}

		public WindowsToolbarRenderer(ToolStripPanel toolbars, ToolStripPanel statusbars, ApplicationModel application)
			: this(toolbars, application)
		{
			if (statusbars == null)
				throw new ArgumentNullException("statusbars");

			_statusbars = statusbars;

			if (!_statusbars.IsHandleCreated)
				_statusbars.CreateControl();
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an item to the end of the designated UI collection.
		/// </summary>
		/// <param name="uiItem">The item to add.</param>
		public override void AddItem(API.Toolbar uiItem)
		{
			ToolStripPanel panel = this.GetToolstrip(uiItem.Location);
			this.AddItem(panel.Controls.Count - 1, uiItem);
		}

		/// <summary>
		/// Adds an item to the designated UI collection at a specified location.
		/// </summary>
		/// <param name="index">The index to add an item at.</param>
		/// <param name="uiItem">The item to add.</param>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the index is out of the range of index values.</exception>
		/// <exception cref="ArgumentNullException">Thrown when the item provided is null.</exception>
		public override void AddItem(int index, API.Toolbar uiItem)
		{
			if (index < 0)
				throw new ArgumentOutOfRangeException("index");
			if (uiItem == null)
				throw new ArgumentNullException("uiItem");

			ToolStrip uiToolbar = this.CreateStrip(uiItem);
			this.GetToolstrip(uiItem.Location).Controls.Add(uiToolbar);
		}

		/// <summary>
		/// Creates an instance of the UI interface for the designated toolbar.
		/// </summary>
		/// <param name="toolbar">The API version of the item to create a UI version for.</param>
		/// <returns>An instance of the UI control.</returns>
		private ToolStrip CreateStrip(API.Toolbar toolbar)
		{
			ToolStrip strip = new ToolStrip();
			strip.Name = toolbar.Name;
			strip.Text = toolbar.Title;
			strip.Visible = toolbar.Visible;
			strip.Tag = toolbar;

			return strip;
		}

		public static WindowsToolbarRenderer GetRenderer(ToolStripPanel toolbar, ToolStripPanel statusBar, ApplicationModel application)
		{
			if (toolbar != null)
			{
				if (statusBar != null)
					return new WindowsToolbarRenderer(toolbar, statusBar, application);
				else
					return new WindowsToolbarRenderer(toolbar, application);
			}
			else
				return null;
		}

		/// <summary>
		/// Gets the designated tool strip control that matches the specified location.
		/// </summary>
		/// <param name="location">The location of the toolbar to get.</param>
		/// <returns>An instance of the UI control representing the toolbar.</returns>
		private ToolStripPanel GetToolstrip(API.ToolbarLocation location)
		{
			if (location == API.ToolbarLocation.Top)
				return this.Toolbars;
			else if (location == API.ToolbarLocation.Bottom)
				return this.Statusbars;
			else
				throw new NotImplementedException();
		}

		/// <summary>
		/// Removes a toolbar from the designated UI location.
		/// </summary>
		/// <param name="uiItem">The item to remove.</param>
		/// <exception cref="ArgumentNullException">Thrown when the toolbar parameter is null.</exception>
		public override void RemoveItem(API.Toolbar uiItem)
		{
			if (uiItem == null)
				throw new ArgumentNullException("uiItem");

			this.GetToolstrip(uiItem.Location).Controls.RemoveByKey(uiItem.Name);
		}

		#endregion
	}
}
