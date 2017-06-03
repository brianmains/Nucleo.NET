using System;
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
	//This would not typically be the subscriber; whatever needs to receive the event (another presenter,etc.)
	//can implement this interface and receive this event
	public class TestEventSubscriber : IEventSubscriber
	{
		public void Receive(PublishedEventDetails eventDetails)
		{
			throw new NotImplementedException();
		}
	}

	public interface ISubscriptionTypesView : IView
	{

	}

	public class SubscriptionTypesPresenter : BasePresenter<ISubscriptionTypesView>
	{
		public SubscriptionTypesPresenter(ISubscriptionTypesView view)
			: base(view)
		{
			this.CurrentContext.EventRegistry.Subscribe(new SubscriptionEventDetails(
				ListenerCriterion.Identifier("1"), (p) => { }));
			this.CurrentContext.EventRegistry.Subscribe(new SubscriptionEventDetails(
				ListenerCriterion.Identifier("2"), new TestEventSubscriber()));

			this.CurrentContext.EventRegistry.Subscribe(new[]
			{
				new SubscriptionEventDetails(ListenerCriterion.Identifier("3"), (p) => { }),
				new SubscriptionEventDetails(ListenerCriterion.Identifier("4"), (p) => { })
			});

			this.CurrentContext.EventRegistry.Subscribe(
				ListenerCriterion.Identifier("5"), new TestEventSubscriber());
			this.CurrentContext.EventRegistry.Subscribe(
				ListenerCriterion.Identifier("6"), (p) => { });

			this.CurrentContext.EventRegistry.Subscribe(
				new[]
				{
					ListenerCriterion.Identifier("7"), 
					ListenerCriterion.Identifier("8")
				},
				new TestEventSubscriber());

			this.CurrentContext.EventRegistry.Subscribe(
				new[]
				{
					ListenerCriterion.Identifier("9"), 
					ListenerCriterion.Identifier("10")
				}, (p) => { });
		}



	}

	[PresenterBinding(typeof(SubscriptionTypesPresenter))]
	public partial class SubscriptionTypes : DemoViewPage, ISubscriptionTypesView
	{
		public override string Description
		{
			get { return "The types of subscriptions."; }
		}
	}
}