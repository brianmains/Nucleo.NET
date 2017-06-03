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
	public class ThirdTabSaveEventArgs : EventArgs
	{
		public string Text { get; set; }
	}

	public delegate void ThirdTabSaveEventHandler(object sender, ThirdTabSaveEventArgs e);

	public class ThirdTabPresenter : BasePresenter<IThirdTabView>
	{
		public ThirdTabPresenter(IThirdTabView view)
			: base(view) 
		{
			view.Save += View_Save;
		}

		void View_Save(object sender, ThirdTabSaveEventArgs e)
		{
			this.View.Model = new ThirdTabModel { FinalValue = "The final value was: " + e.Text };
		}
	}

	public class ThirdTabModel
	{
		public string FinalValue { get; set; }
	}

	public interface IThirdTabView : IView<ThirdTabModel>
	{
		event ThirdTabSaveEventHandler Save;
	}

	[PresenterBinding(typeof(ThirdTabPresenter))]
	public partial class ThirdTab : BaseViewUserControl<ThirdTabModel>, IThirdTabView
	{
		public event ThirdTabSaveEventHandler Save;


		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (Save != null)
				Save(this, new ThirdTabSaveEventArgs { Text = this.txtOutput.Text });
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			
			if (this.Model != null)
				this.lblOutput.Text = this.Model.FinalValue;
		}
	}
}