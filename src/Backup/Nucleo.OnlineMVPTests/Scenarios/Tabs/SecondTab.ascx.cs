using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Scenarios.Tabs
{
	public class SecondTabSaveEventArgs : EventArgs
	{
		public string Text { get; set; }
	}

	public delegate void SecondTabSaveEventHandler(object sender, SecondTabSaveEventArgs e);

	public class SecondTabPresenter : BasePresenter<ISecondTabView>
	{
		public SecondTabPresenter(ISecondTabView view)
			: base(view) 
		{
			view.Starting += View_Starting;
			view.Save += View_Save;
		}

		void View_Save(object sender, SecondTabSaveEventArgs e)
		{
			this.View.Model = new SecondTabModel { FinalValue = "The final value was: " + e.Text };
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new SecondTabModel { FinalValue = "Initial loading." };
		}
	}

	public class SecondTabModel
	{
		public string FinalValue { get; set; }
	}

	public interface ISecondTabView : IView<SecondTabModel>
	{
		event SecondTabSaveEventHandler Save;
	}

	[PresenterBinding(typeof(SecondTabPresenter))]
	public partial class SecondTab : BaseViewUserControl<SecondTabModel>, ISecondTabView
	{
		public event SecondTabSaveEventHandler Save;

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (Save != null)
				Save(this, new SecondTabSaveEventArgs { Text = this.txtOutput.Text });
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model != null)
				this.lblOutput.Text = this.Model.FinalValue;
		}
	}
}