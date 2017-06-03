using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Routing
{
	public interface IRoutingFailureHandler
	{
		void HandleFailure(IRoutingEngine engine, object routingSource, RoutingFailureReason reason);
	}
}