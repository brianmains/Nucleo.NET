using System;


namespace Nucleo.Routing
{
	public interface IRoutingSecurity
	{
		bool HasPermission(object routingSource);
	}
}
