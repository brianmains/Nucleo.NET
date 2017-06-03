using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.EventsManagement
{
	[TestClass]
	public class EventsManagerTest
	{
		protected class TestEvent : BaseEvent
		{
			public bool WasInitialized { get; set; }

			public bool WasRaised { get; set; }

			public void CallInitialize(string name, object security)
			{
				this.Initialize(name, security);
			}

			protected override void Raise(Views.IView view)
			{
				WasRaised = true;

				base.Raise(view);
			}
		}



		[TestMethod]
		public void RegisteringEventReturnsCorrectEventInitialized()
		{
			//Arrange
			
		}
	}
}
