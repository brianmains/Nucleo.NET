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


namespace Nucleo.Tests.MessagingWithEvents
{
	public class SaveEvent : BaseEvent { }

	public class CancelEvent : BaseEvent { }



	public interface IMessagingWithEventsView : IView
	{
		void AddMessage(string message);
	}

	public class MessagingWithEventsPresenter : BasePresenter<IMessagingWithEventsView>
	{
		public MessagingWithEventsPresenter(IMessagingWithEventsView view)
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


	[PresenterBinding(typeof(MessagingWithEventsPresenter))]
	public partial class MessagingWithEvents : BaseViewPage, IMessagingWithEventsView
	{
		public void AddMessage(string message)
		{
			this.lblOutput.Controls.Add(new LiteralControl(message + "<br/>"));
		}
	}
}