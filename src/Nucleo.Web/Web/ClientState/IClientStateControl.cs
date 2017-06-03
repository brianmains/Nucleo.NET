using System;
using System.Collections.Generic;


namespace Nucleo.Web.ClientState
{
	public interface IClientStateControl
	{
		void LoadClientState(ClientStateData stateData);
		ClientStateData SaveClientState();
	}
}
