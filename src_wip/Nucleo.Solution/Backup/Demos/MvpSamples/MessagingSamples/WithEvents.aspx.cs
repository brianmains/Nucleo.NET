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
	public class SaveEvent : BaseEvent { }

	public class CancelEvent : BaseEvent { }



	public interface IWithEventsView : IView
	{
		void AddMessage(string message);
	}

	public class WithEventsPresenter : BasePresenter<IWithEventsView>
	{
		public WithEventsPresenter(IWithEventsView view)
			: base(view)
		{
			this.CurrentContext.EventRegistry.Subscribe(new SubscriptionEventDetails(
				ListenerCriterion.EntityType<SaveEvent>(),
				(p) =>
				{
					this.View.AddMessage("The save event fired for: " + p.Source.GetType().Name);
				}));
			this.CurrentContext.EventRegistry.Subscribe(new SubscriptionEventDetails(
				ListenerCriterion.Identifier("Cancel"),
				(p) =>
				{
					this.View.AddMessage("The cancel event fired for: " + p.Source.GetType().Name);
				}));
		}
	}


	[PresenterBinding(typeof(WithEventsPresenter))]
	public partial class WithEvents : DemoViewPage, IWithEventsView
	{
		public override string Description
		{
			get { return "An overview of events."; }
		}

		public void AddMessage(string message)
		{
			this.lblOutput.Controls.Add(new LiteralControl(message + "<br/>"));
		}
	}
}