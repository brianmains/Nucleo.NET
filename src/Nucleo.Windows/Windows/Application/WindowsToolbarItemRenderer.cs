using System;
using System.Windows.Forms;

using Nucleo.Windows.UI;

namespace Nucleo.Windows.Application
{
	public class WindowsToolbarItemRenderer : InterfaceRenderer<ToolbarItem>
	{
		private ApplicationModel _application = null;
		private ToolStripPanel _statusBars = null;
		private ToolStripPanel _toolbars = null;



		#region " Properties "

		public ApplicationModel Application
		{
			get { return _application; }
		}

		public ToolStripPanel Statusbars
		{
			get { return _statusBars; }
		}

		public ToolStripPanel Toolbars
		{
			get { return _toolbars; }
		}

		#endregion



		#region " Constructors "

		public WindowsToolbarItemRenderer(ToolStripPanel toolbars, ApplicationModel application)
		{
			if (toolbars == null)
				throw new ArgumentNullException("toolbars");

			_toolbars = toolbars;
			_application = application;

			if (!_toolbars.IsHandleCreated)
				_toolbars.CreateControl();
		}

		public WindowsToolbarItemRenderer(ToolStripPanel toolbars, ToolStripPanel statusBars, ApplicationModel application)
			: this(toolbars, application)
		{
			if (statusBars == null)
				throw new ArgumentNullException("statusBars");

			_statusBars = statusBars;
			if (!_statusBars.IsHandleCreated)
				_statusBars.CreateControl();
		}

		#endregion



		#region " Methods "

		public override void AddItem(ToolbarItem uiItem)
		{
			ToolStrip strip = this.GetParent(uiItem);
			this.AddItem(strip.Items.Count == 0 ? 0 : strip.Items.Count - 1, uiItem);
		}

		/// <summary>
		/// Adds a new toolbar item, whatever type that may be, to the underlying UI control.
		/// </summary>
		/// <param name="index">The index of the item to insert it in the collection.</param>
		/// <param name="uiItem">The item to insert into the collection.</param>
		public override void AddItem(int index, ToolbarItem uiItem)
		{
			ToolStripItem stripItem = null;

			if (uiItem is ToolbarLabel)
				stripItem = new ToolStripLabel(((ToolbarLabel)uiItem).Text);
			else if (uiItem is ToolbarTextBox)
			{
				stripItem = new ToolStripTextBox();
				stripItem.Text = ((ToolbarTextBox)uiItem).Text;
			}
			else if (uiItem is ToolbarDropDown)
			{
				stripItem = new ToolStripComboBox();
				ToolStripComboBox combo = (ToolStripComboBox)stripItem;

				foreach (object dropDownItem in ((ToolbarDropDown)uiItem).Items)
				{
					if (dropDownItem is IToolbarListItem)
						combo.Items.Add(((IToolbarListItem)dropDownItem).ToDisplay());
					else
						combo.Items.Add(dropDownItem.ToString());
				}

				combo.SelectedIndexChanged += new EventHandler(ToolStripItem_SelectedIndexChanged);
			}
			else if (uiItem is ToolbarButton)
			{
				ToolbarButton button = (ToolbarButton)uiItem;
				stripItem = new ToolStripButton(button.Text);

				if (button.Image != null)
					stripItem.Image = button.Image;
				stripItem.Click += ToolStripItem_Click;
			}
			else if (uiItem is ToolbarSeparator)
				stripItem = new ToolStripSeparator();
			else
				throw new NotImplementedException();

			stripItem.Name = uiItem.Name;
			stripItem.Tag = uiItem;

			ToolStrip strip = this.GetParent(uiItem);
			strip.Items.Add(stripItem);
		}

		private ToolStrip GetParent(ToolbarItem uiItem)
		{
			ToolStripPanel panel = this.GetParentPanel(uiItem);
			return (ToolStrip)panel.Controls[uiItem.Parent.Name];
		}

		private ToolStripPanel GetParentPanel(ToolbarItem uiItem)
		{
			if (uiItem.Parent.Location == ToolbarLocation.Top)
				return _toolbars;
			else if (uiItem.Parent.Location == ToolbarLocation.Bottom)
				return _statusBars;
			else
				throw new NotImplementedException();
		}

		public static WindowsToolbarItemRenderer GetRenderer(ToolStripPanel toolbars, ToolStripPanel statusBars, ApplicationModel application)
		{
			if (toolbars != null)
			{
				if (statusBars != null)
					return new WindowsToolbarItemRenderer(toolbars, statusBars, application);
				else
					return new WindowsToolbarItemRenderer(toolbars, application);
			}

			return null;
		}

		public override void RemoveItem(ToolbarItem uiItem)
		{
			ToolStrip strip = this.GetParent(uiItem);
			strip.Items.RemoveByKey(uiItem.Name);
		}

		#endregion



		#region " Event Handlers "

		void ToolStripItem_Click(object sender, EventArgs e)
		{
			ToolStripButton buttonControl = (ToolStripButton)sender;
			ToolbarButton button = buttonControl.Tag as ToolbarButton;

			if (button == null)
				return;
		}

		void ToolStripItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			ToolStripComboBox box = (ToolStripComboBox)sender;
			ToolbarDropDown dropDown = box.Tag as ToolbarDropDown;

			if (dropDown == null)
				return;
			object selectedItem = null;

			foreach (object dropDownItem in dropDown.Items)
			{
				if (dropDownItem is IToolbarListItem)
				{
					if (string.Compare(((IToolbarListItem)dropDownItem).ToDisplay(), box.SelectedItem.ToString(), true) == 0)
						selectedItem = dropDownItem;
				}
				else
				{
					if (string.Compare(dropDownItem.ToString(), box.SelectedItem.ToString(), true) == 0)
						selectedItem = dropDownItem;
				}

				if (selectedItem != null)
					break;
			}

		}

		#endregion
	}
}
