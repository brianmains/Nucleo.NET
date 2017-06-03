using System;
using Nucleo.Providers;



namespace Nucleo.State
{
	public abstract class StateValuesProvider : ProviderBase
	{
		#region " Methods "

		public abstract object GetRegionValue(StateUser user, StateProperty property, string regionName);

		public abstract object GetValue(StateUser user, StateProperty property);

		public abstract bool SetRegionValue(StateUser user, StateProperty property, string regionName, object propertyValue);

		public abstract bool SetValue(StateUser user, StateProperty property, object propertyValue);

		#endregion
	}
}
