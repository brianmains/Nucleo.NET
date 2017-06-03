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
	public class BubbleTunnelEventsSubchild01Presenter : BasePresenter<IBubbleTunnelEventsSubchild01View>, IEventSubscriber
	{
		public BubbleTunnelEventsSubchild01Presenter(IBubbleTunnelEventsSubchild01View view)
			: base(view)
		{
			view.SendBubbledMessage += View_SendBubbledMessage;
		}

		void View_SendBubbledMessage(object sender, EventArgs e)
		{
			this.CurrentContext.EventRegistry.SendEvent(this, new PublishedEventDetails(
				ListenerCriterion.EntityType<BubbleTunnelEventsSubchild01Presenter>()), EventDirection.Bubble);
		}

		public void Receive(PublishedEventDetails eventDetails)
		{
			this.View.Message = "Event received with information: " + eventDetails.Criteria.ToString();
		}
	}

	public interface IBubbleTunnelEventsSubchild01View : IView
	{
		event EventHandler SendBubbledMessage;

		string Message { get; set; }
	}

	[PresenterBinding(typeof(BubbleTunnelEventsSubchild01Presenter))]
	public partial class BubbleTunnelEventsSubchild01 : BaseViewUserControl, IBubbleTunnelEventsSubchild01View
	{
		public event EventHandler SendBubbledMessage;

		public string Message
		{
			get { return this.lblOutput.Text; }
			set { this.lblOutput.Text = value; }
		}

		protected void btnSendBubbledMessage_Click(object sender, EventArgs e)
		{
			if (SendBubbledMessage != null)
				SendBubbledMessage(this, e);
		}
	}
}