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
	public class BubbleTunnelEventsPresenter : BasePresenter<IBubbleTunnelEventsView>, IEventSubscriber
	{
		public BubbleTunnelEventsPresenter(IBubbleTunnelEventsView view)
			: base(view)
		{
			view.SendTunnelledMessage += new EventHandler(View_SendTunnelledMessage);
		}

		void View_SendTunnelledMessage(object sender, EventArgs e)
		{
			this.CurrentContext.EventRegistry.SendEvent(this, new PublishedEventDetails(
				ListenerCriterion.EntityType<BubbleTunnelEventsPresenter>()), EventDirection.Tunnel);
		}

		public void Receive(PublishedEventDetails eventDetails)
		{
			this.View.Message = "Event received with information: " + eventDetails.Criteria.ToString();
		}
	}

	public interface IBubbleTunnelEventsView : IView
	{
		event EventHandler SendTunnelledMessage;

		string Message { get; set; }
	}

	[PresenterBinding(typeof(BubbleTunnelEventsPresenter))]
	public partial class BubbleTunnelEvents : DemoViewPage, IBubbleTunnelEventsView
	{
		public event EventHandler SendTunnelledMessage;

		public override string Description
		{
			get { return "An overview of tunneling and bubbling events."; }
		}

		public string Message
		{
			get { return this.lblOutput.Text; }
			set { this.lblOutput.Text = value; }
		}

		protected void btnSendTunnelledMessage_Click(object sender, EventArgs e)
		{
			if (SendTunnelledMessage != null)
				SendTunnelledMessage(this, e);
		}
	}
}