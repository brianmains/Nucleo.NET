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
	public class ManyMessagesPresenter : BasePresenter<IManyMessagesView>
	{
		public int id = 1;

		public ManyMessagesPresenter(IManyMessagesView view)
			: base(view)
		{
			view.Initializing += new EventHandler(View_Initializing);
		}

		void View_Initializing(object sender, EventArgs e)
		{
			this.CurrentContext.EventRegistry.Subscribe(new SubscriptionEventDetails(
				ListenerCriterion.EntityType<ManyMessagesChildPresenter>(),
				(d) =>
				{
					View.AddMessage(string.Format("A subpresenter published an event: {0}", id++));
				}));
		}
	}

	public interface IManyMessagesView : IView
	{
		void AddMessage(string msg);
	}

	[PresenterBinding(typeof(ManyMessagesPresenter))]
	public partial class ManyMessages : DemoViewPage, IManyMessagesView
	{
		public override string Description
		{
			get { return "An overview of how the presenters can communicate with each other."; }
		}


		public void AddMessage(string msg)
		{
			this.lblOutput.Text += msg + "<br/>";
		}
	}
}