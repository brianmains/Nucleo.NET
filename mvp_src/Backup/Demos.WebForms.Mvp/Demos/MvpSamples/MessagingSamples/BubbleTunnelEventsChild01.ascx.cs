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
	public class BubbleTunnelEventsChild01Presenter : BasePresenter<IBubbleTunnelEventsChild01View>, IEventSubscriber
	{
		public BubbleTunnelEventsChild01Presenter(IBubbleTunnelEventsChild01View view)
			: base(view)
		{

		}

		public void Receive(PublishedEventDetails eventDetails)
		{
			this.View.Message = "Event received with information: " + eventDetails.Criteria.ToString();
		}
	}

	public interface IBubbleTunnelEventsChild01View : IView
	{
		string Message { get; set; }
	}

	[PresenterBinding(typeof(BubbleTunnelEventsChild01Presenter))]
	public partial class BubbleTunnelEventsChild01 : DemoViewUserControl, IBubbleTunnelEventsChild01View
	{
		public string Message
		{
			get { return this.lblOutput.Text; }
			set { this.lblOutput.Text = value; }
		}

	}
}