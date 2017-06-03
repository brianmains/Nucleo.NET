using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Views;


namespace Nucleo.EventsManagement
{
	[TestClass]
	public class BaseEventTest
	{
		protected class TestEvent : BaseEvent
		{
			public bool WasInitialized { get; set; }

			public bool WasRaised { get; set; }

			public void CallInitialize(string name, object security)
			{
				this.WasInitialized = true;
				this.Initialize(name, security);
			}

			protected override void Raise(Views.IView view)
			{
				WasRaised = true;

				base.Raise(view);
			}
		}


		[TestMethod]
		public void InitializingCallsOverloadedMethod()
		{
			var evt = new TestEvent();

			//Act
			evt.CallInitialize("XYZ", new object());

			//Assert
			Assert.IsTrue(evt.WasInitialized);
		}

		[TestMethod]
		public void InitializingPassesToMembers()
		{
			var evt = new TestEvent();

			//Act
			evt.CallInitialize("XYZ", new object());
		
			//Assert
			Assert.AreEqual("XYZ", evt.Name);
			Assert.IsNotNull(evt.SecurityAccess);
		}

		[TestMethod]
		public void RaisingEventWithSourceAndArgsFiresInternally()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(EventsManager));
			var e = new TestEvent();
			var view = Isolate.Fake.Instance<IView>();

			//Act
			e.Raise(view, new Dictionary<string, object>());

			//Assert
			Assert.IsTrue(e.WasRaised);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RaisingEventWithSourceFiresInternally()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(EventsManager));
			var e = new TestEvent();

			//Act
			e.Raise(Isolate.Fake.Instance<IView>());

			//Assert
			Assert.IsTrue(e.WasRaised);

			Isolate.CleanUp();
		}
	}
}
