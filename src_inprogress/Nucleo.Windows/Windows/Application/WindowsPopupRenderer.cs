using System;
using System.Windows.Forms;
using API = Nucleo.Windows.UI;


namespace Nucleo.Windows.Application
{
	public class WindowsPopupRenderer : InterfaceRenderer<API.PopupWindow>
	{
		private ApplicationModel _application = null;



		#region " Constructors "

		public WindowsPopupRenderer(ApplicationModel application)
		{
			_application = application;
		}

		#endregion



		#region " Methods "

		public override void AddItem(Nucleo.Windows.UI.PopupWindow uiItem)
		{
			Form form = new Form();
			form.Controls.Add(ControlUtility.GetWindowsControlReference(uiItem.UIInterface));
			form.Controls[0].Dock = DockStyle.Fill;
			form.StartPosition = FormStartPosition.CenterScreen;

			form.Show();
		}

		public override void AddItem(int index, Nucleo.Windows.UI.PopupWindow uiItem)
		{
			this.AddItem(uiItem);
		}

		public override void RemoveItem(Nucleo.Windows.UI.PopupWindow uiItem)
		{
			//TODO:Figure out
		}

		#endregion
	}
}
