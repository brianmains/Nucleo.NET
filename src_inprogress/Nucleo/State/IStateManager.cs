using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.State
{
	public interface IStateManager
	{
		#region " Methods "

		object GetStateValue(StateUser user, StateProperty property);
		object GetStateValue(StateUser user, string statePropertyName);
		void SetStateValue(StateUser user, StateProperty property, object value);
		void SetStateValue(StateUser user, string statePropertyName, object value);

		#endregion
	}
}
