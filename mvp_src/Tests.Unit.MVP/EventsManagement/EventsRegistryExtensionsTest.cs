using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.EventsManagement.Listeners;
using Nucleo.Presentation;
using Nucleo.Views;


namespace Nucleo.EventsManagement
{
	[TestClass]
	public class EventsRegistryExtensionsTest
	{
		protected class TestPresenter : BasePresenter, IEventSubscriber
		{
			public bool Received = false;

			public TestPresenter(IView view) : base(view) { }

			public void Receive(PublishedEventDetails eventDetails)
			{
				Received = true;
			}
		}



		[TestMethod]
		public void SendingEventAsBubbleMessageSendsOK()
		{
			var presenter = new TestPresenter(Isolate.Fake.Instance<IView>());
			presenter.Subpresenters.Add(new TestPresenter(Isolate.Fake.Instance<IView>()) { Parent = presenter });
			presenter.Subpresenters.Add(new TestPresenter(Isolate.Fake.Instance<IView>()) { Parent = presenter });

			presenter.Subpresenters[1].CurrentContext.EventRegistry.SendEvent(
				presenter.Subpresenters[1],
				new PublishedEventDetails(ListenerCriterion.Any()),
				EventDirection.Bubble);

			Assert.IsTrue(presenter.Received);
			Assert.IsFalse(((TestPresenter)presenter.Subpresenters[0]).Received);
			Assert.IsFalse(((TestPresenter)presenter.Subpresenters[1]).Received);
		}

		[TestMethod]
		public void SendingEventAsTunnelMessageSendsOK()
		{
			var presenter = new TestPresenter(Isolate.Fake.Instance<IView>());
			presenter.Subpresenters.Add(new TestPresenter(Isolate.Fake.Instance<IView>()) { Parent = presenter });
			presenter.Subpresenters.Add(new TestPresenter(Isolate.Fake.Instance<IView>()) { Parent = presenter });

			presenter.CurrentContext.EventRegistry.SendEvent(
				presenter,
				new PublishedEventDetails(ListenerCriterion.Any()),
				EventDirection.Tunnel);

			Assert.IsFalse(presenter.Received);
			Assert.IsTrue(((TestPresenter)presenter.Subpresenters[0]).Received);
			Assert.IsTrue(((TestPresenter)presenter.Subpresenters[1]).Received);
		}
	}
}
