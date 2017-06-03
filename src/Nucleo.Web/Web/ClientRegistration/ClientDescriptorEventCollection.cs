using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web.ClientRegistration
{
	public class ClientDescriptorEventCollection : SimpleCollection<ClientDescriptorEvent>
	{
		public void AddRange(IEnumerable<ClientDescriptorEvent> events)
		{
			foreach (var eventInfo in events)
				this.Add(eventInfo);
		}
	}
}
