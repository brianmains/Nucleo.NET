using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.EventsManagement
{
	[TestClass]
	public class EventRegistryOptionsTest
	{
		[TestMethod]
		public void ChangingQueuedNotificationsFiresEvent()
		{
			var options = new EventRegistryOptions();
			bool fired = false;

			options.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
			{
				fired = true;
			};

			options.QueuePublishedNotifications = !options.QueuePublishedNotifications;

			Assert.IsTrue(fired);
		}
	}
}
