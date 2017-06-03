using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.State
{
	public class FakeStateManager : IStateManager
	{
		private StatePropertyCollection _properties = null;
		private Dictionary<string, object> _propertyValues = null;



		#region " Properties "

		public StatePropertyCollection Properties
		{
			get
			{
				if (_properties == null)
					_properties = new StatePropertyCollection();
				return _properties;
			}
		}

		public Dictionary<string, object> PropertyValues
		{
			get
			{
				if (_propertyValues == null)
					_propertyValues = new Dictionary<string, object>();
				return _propertyValues;
			}
		}

		#endregion



		#region " Methods "

		public object GetStateValue(StateUser user, string statePropertyName)
		{
			return this.PropertyValues[statePropertyName];
		}

		public object GetStateValue(StateUser user, StateProperty property)
		{
			return this.PropertyValues[property.Name];
		}

		public void SetStateValue(StateUser user, string statePropertyName, object value)
		{
			this.PropertyValues[statePropertyName] = value;
		}

		public void SetStateValue(StateUser user, StateProperty property, object value)
		{
			this.PropertyValues[property.Name] = value;
		}

		#endregion
	}
}
