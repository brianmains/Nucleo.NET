using System;
using System.Windows.Forms;

using Nucleo.Windows.Actions;
using Nucleo.Windows.UI;


namespace Nucleo.Windows.ApplicationListeners
{
	public class WindowsTabListenerControl : ListenerControl
	{
		private TabControl _control = null;



		#region " Properties "

		internal TabControl Control
		{
			get { return _control; }
		}

		#endregion



		#region " Constructors "

		public WindowsTabListenerControl(TabControl control)
		{
			_control = control;
		}

		#endregion



		#region " Methods "

		public override void AddItem(int index, UIElement item)
		{
			if (!(item is BaseWindow))
				throw new ArgumentException("Only windows are supported with this listener");

			TabPage page = this.CreateControlItem((BaseWindow)item);
			this.Control.TabPages.Insert(index, page);
		}

		private TabPage CreateControlItem(BaseWindow uiItem)
		{
			TabPage page = new TabPage();
			page.Name = uiItem.Name;
			page.Text = uiItem.Title;
			page.Tag = uiItem;

			ControlConversionManager manager = ControlConversionManager.GetManager();
			page.Controls.Add((Control)manager.ConvertReference(uiItem.UIInterface));

			return page;
		}

		public override void HandleEvent(EventAction action)
		{
			if (!(action.Source is UIElement))
				return;

			TabPage page = this.Control.TabPages[((UIElement) action.Source).Name];
			if (page == null)
				throw new NullReferenceException("The key wasn't found in the tab collection");

			if (action.Name == SelectionAction.DefaultActionName)
				page.Show();
			else if (action.Name == ClickAction.DefaultActionName)
				page.Select();
		}

		public override void RemoveItem(UIElement item)
		{
			if (!(item is BaseWindow))
				throw new ArgumentException("Only windows are supported with this listener");

			this.Control.TabPages.RemoveByKey(item.Name);
		}

		public override void RemoveItem(int index)
		{
			if (index < 0 || index >= this.Control.TabPages.Count)
				throw new ArgumentOutOfRangeException("index");
			
			this.Control.TabPages.RemoveAt(index);
		}

		#endregion
	}
}
