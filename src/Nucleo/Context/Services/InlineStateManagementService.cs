using System;
using System.Collections.Generic;


namespace Nucleo.Context.Services
{
	public class InlineStateManagementService : IStateManagementService
	{

		#region " Methods "

		public object GetStateValue(State.StateUser user, State.StateProperty property)
		{
			throw new NotImplementedException();
		}

		public object GetStateValue(State.StateUser user, string statePropertyName)
		{
			throw new NotImplementedException();
		}

		public void SetStateValue(State.StateUser user, State.StateProperty property, object value)
		{
			throw new NotImplementedException();
		}

		public void SetStateValue(State.StateUser user, string statePropertyName, object value)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
