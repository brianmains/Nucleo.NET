using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventsManagement;
using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Demos.MvpSamples.MessagingSamples
{
	public class ManyMessagesChildPresenter : BasePresenter<IManyMessagesChildView>
	{
		public ManyMessagesChildPresenter(IManyMessagesChildView view)
			: base(view)
		{
			view.Loading += new EventHandler(View_Loading);
		}

		void View_Loading(object sender, EventArgs e)
		{
			this.CurrentContext.EventRegistry.Publish(
				new PublishedEventDetails(this, ListenerCriterion.EntityType<ManyMessagesChildPresenter>()));
		}
	}

	public interface IManyMessagesChildView : IView
	{

	}

	[PresenterBinding(typeof(ManyMessagesChildPresenter))]
	public partial class ManyMessagesChild : DemoViewUserControl, IManyMessagesChildView
	{

	}
}