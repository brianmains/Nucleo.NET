using System;
using System.Windows.Forms;

using Nucleo.Text;


namespace Nucleo.Windows.UI
{
	public class ToolbarAssistant
	{
		#region " Methods "

		public static void CreateContextMenu(Toolbar toolbar, ContextMenuStrip toolbarMenu)
		{
			ToolStripMenuItem menuItem = new ToolStripMenuItem(toolbar.Title);
			menuItem.Checked = menuItem.Visible;
			toolbarMenu.Items.Add(menuItem);
		}

		public static ToolStripItem CreateToolbarItem(ToolbarItem item)
		{
			ToolStripItem stripItem = null;

			if (item is ToolbarLabel)
				stripItem = new ToolStripLabel(((ToolbarLabel)item).Text);
			else if (item is ToolbarTextBox)
			{
				stripItem = new ToolStripTextBox();
				stripItem.Text = ((ToolbarTextBox)item).Text;
			}
			else if (item is ToolbarDropDown)
			{
				stripItem = new ToolStripComboBox();
				((ToolStripComboBox)stripItem).Items.AddRange(((ToolbarDropDown)item).Items.ToArray());
			}
			else if (item is ToolbarButton)
			{
				ToolbarButton button = (ToolbarButton)item;
				stripItem = new ToolStripButton(button.Text);

				if (button.Image != null)
					stripItem.Image = button.Image;
			}
			else if (item is ToolbarSeparator)
				stripItem = new ToolStripSeparator();
			else
				return null;

			stripItem.Name = item.Name;
			stripItem.Tag = item;
			return stripItem;
		}

		#endregion
	}
}
