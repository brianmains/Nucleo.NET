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
	public class FirstTabPresenter : BasePresenter<IFirstTabView>
	{
		public FirstTabPresenter(IFirstTabView view)
			: base(view) 
		{
			view.Starting += View_Starting;
		}

		void View_Starting(object sender, EventArgs e)
		{
			this.View.Model = new FirstTabModel { Message = "This message was populated via the presenter." };
		}
	}

	public class FirstTabModel
	{
		public string Message { get; set; }
	}

	public interface IFirstTabView : IView<FirstTabModel>
	{

	}

	[PresenterBinding(typeof(FirstTabPresenter))]
	public partial class FirstTab : BaseViewUserControl<FirstTabModel>, IFirstTabView
	{
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			if (this.Model != null)
				this.lblOutput.Text = this.Model.Message;
		}
	}
}