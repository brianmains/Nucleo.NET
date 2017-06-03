using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Windows.Actions
{
	public interface IEventSubscribingObject
	{
		void ReceiveEventNotification(EventAction action, object targetObject);
	}
}
