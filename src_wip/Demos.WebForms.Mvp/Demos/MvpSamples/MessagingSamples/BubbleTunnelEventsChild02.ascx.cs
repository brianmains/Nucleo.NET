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
	public class BubbleTunnelEventsChild02Presenter : BasePresenter<IBubbleTunnelEventsChild02View>, IEventSubscriber
	{
		public BubbleTunnelEventsChild02Presenter(IBubbleTunnelEventsChild02View view)
			: base(view)
		{

		}

		public void Receive(PublishedEventDetails eventDetails)
		{
			this.View.Message = "Event received with information: " + eventDetails.Criteria.ToString();
		}
	}

	public interface IBubbleTunnelEventsChild02View : IView
	{
		string Message { get; set; }
	}

	[PresenterBinding(typeof(BubbleTunnelEventsChild02Presenter))]
	public partial class BubbleTunnelEventsChild02 : DemoViewUserControl, IBubbleTunnelEventsChild02View
	{
		public string Message
		{
			get { return this.lblOutput.Text; }
			set { this.lblOutput.Text = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}