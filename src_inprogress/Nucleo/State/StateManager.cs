using System;
using System.Reflection;

using Nucleo.EventArguments;
using Nucleo.Exceptions;
using Nucleo.Providers;
using Nucleo.State.Configuration;


namespace Nucleo.State
{
	public class StateManager : IStateManager
	{
		private StateManagementSection _configuration = null;
		//private string _defaultConditionProviderName = null;



		#region " Events "

		public static event StatePropertyChangedEventHandler PropertyChanged;

		#endregion



		#region " Properties "

		private StateManagementSection Configuration
		{
			get { return _configuration; }
		}

		#endregion



		#region " Constructors "

		private StateManager() { }

		#endregion



		#region " Methods "

		//private StateCondition GetCachedCondition(string conditionName)
		//{
		//    if (this.Conditions.Count == 0)
		//        return null;

		//    StateCondition returnValue = this.Conditions[conditionName];
		//    if (returnValue != null)
		//        return returnValue;
		//    else
		//        return null;
		//}

		///// <summary>
		///// Gets the condition by its name.  This condition is used to execute a routine of condition logic.
		///// </summary>
		///// <param name="name">The name of the condition.</param>
		///// <returns>The state condition reference created from one of the providers.</returns>
		//public StateCondition GetCondition(string name)
		//{
		//    if (string.IsNullOrEmpty(name))
		//        throw new ArgumentNullException("name");

		//    StateCondition returnValue = this.GetCachedCondition(name);
		//    if (returnValue != null)
		//        return returnValue;

		//    returnValue = this.GetConditionForDefaultProvider(name);
		//    if (returnValue != null)
		//        return returnValue;

		//    returnValue = this.GetConditionForOtherProviders(name);
		//    if (returnValue != null)
		//        return returnValue;

		//    throw new NotFoundException("The condition name wasn't found in any of the configuration sources");
		//}

		//private StateCondition GetConditionForDefaultProvider(string conditionName)
		//{
		//    StateConditionProvider defaultProvider = _conditionProviders[_defaultConditionProviderName];
		//    StateCondition returnValue = defaultProvider.GetCondition(conditionName);

		//    if (returnValue != null)
		//    {
		//        this.Conditions.Add(returnValue);
		//        return returnValue;
		//    }

		//    return null;
		//}

		//private StateCondition GetConditionForOtherProviders(string conditionName)
		//{
		//    StateCondition returnValue = null;

		//    foreach (StateConditionProvider provider in _conditionProviders)
		//    {
		//        if (provider.Name != _defaultConditionProviderName)
		//        {
		//            returnValue = provider.GetCondition(conditionName);
		//            if (returnValue != null)
		//            {
		//                this.Conditions.Add(returnValue);
		//                return returnValue;
		//            }
		//        }
		//    }

		//    return null;
		//}

		private StateValuesProvider GetDefaultProvider()
		{
			return (StateValuesProvider)Activator.CreateInstance(Type.GetType(this.Configuration.ValueProviders.Providers[this.Configuration.ValueProviders.DefaultProvider].Type));
		}

		/// <summary>
		/// Gets the instance of the state manager.
		/// </summary>
		/// <returns>The instance of the state manager.</returns>
		public static StateManager GetInstance()
		{
			StateManagementSection section = StateManagementSection.Instance;
			if (section == null)
				throw new System.Configuration.ConfigurationErrorsException("The state management section is null");
			
			StateManager manager = new StateManager();
			manager._configuration = section;

			return manager;
		}

		/// <summary>
		/// Gets the property by its name.
		/// </summary>
		/// <param name="name">The name of the property.</param>
		/// <returns>The property instance.</returns>
		public StateProperty GetProperty(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			StatePropertyElement property = this.Configuration.StateProperties[name];
			if (property == null)
				return null;

			return new StateProperty(property.Name, property.Isolation, property.DefaultValue);
		}

		/// <summary>
		/// Gets a property within a specific region.
		/// </summary>
		/// <param name="regionName">The name of the region.</param>
		/// <param name="name">The name of the property within the region.</param>
		/// <returns>The property information, if the region and property name can be found.</returns>
		public StateProperty GetRegionProperty(string regionName, string propertyName)
		{
			if (regionName == null)
				throw new ArgumentNullException("regionName");
			if (string.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException("propertyName");

			StateRegionElement regionElement = this.Configuration.StateRegions[regionName];
			if (regionElement == null)
				return null;

			StatePropertyElement propertyElement = regionElement.Properties[propertyName];
			if (propertyElement == null)
				return null;

			return new StateProperty(propertyElement.Name, propertyElement.Isolation, propertyElement.DefaultValue);
		}

		public object GetRegionStateValue(StateUser user, StateProperty property, string regionName)
		{
			if (property == null)
				throw new ArgumentNullException("property");

			object value = this.GetDefaultProvider().GetRegionValue(user, property, regionName);
			if (this.IsNotNull(value))
				return value;
			else
				return property.DefaultValue;
		}

		public object GetRegionStateValue(StateUser user, string propertyName, string regionName)
		{
			return this.GetRegionStateValue(user, this.GetRegionProperty(regionName, propertyName), regionName);
		}

		/// <summary>
		/// Gets a state value with a property reference.
		/// </summary>
		/// <param name="property">The property reference.</param>
		/// <returns>The value for the state property.</returns>
		public object GetStateValue(StateUser user, StateProperty property)
		{
			if (property == null)
				throw new ArgumentNullException("property");

			object value = this.GetDefaultProvider().GetValue(user, property);
			if (this.IsNotNull(value))
				return value;
			else
				return property.DefaultValue;
		}

		/// <summary>
		/// Gets the value of a state property by its name.
		/// </summary>
		/// <param name="statePropertyName">The name of the state property.</param>
		/// <returns>The object that represents the state property.</returns>
		public object GetStateValue(StateUser user, string statePropertyName)
		{
			if (statePropertyName == null)
				throw new ArgumentNullException("statePropertyName");

			return GetStateValue(user, this.GetProperty(statePropertyName));			
		}

		/// <summary>
		/// Returns whether the value passed in is not null.
		/// </summary>
		/// <param name="value">The value to evaluate.</param>
		/// <returns>Whether the value is not null.</returns>
		private bool IsNotNull(object value)
		{
			if (value is string)
				return !string.IsNullOrEmpty((string)value);
			else
				return (value != null);
		}

		protected virtual void OnPropertyChanged(StatePropertyChangedEventArgs e)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, e);
		}

		public void SetRegionStateValue(StateUser user, StateProperty property, string regionName, object value)
		{
			if (property == null)
				throw new ArgumentNullException("property");
			if (string.IsNullOrEmpty(regionName))
				throw new ArgumentNullException("regionName");

			this.GetDefaultProvider().SetRegionValue(user, property, regionName, value);
		}

		public void SetRegionStateValue(StateUser user, string propertyName, string regionName, object value)
		{
			this.SetRegionStateValue(user, this.GetRegionProperty(regionName, propertyName), regionName, value);
		}

		/// <summary>
		/// Sets the value of a state property to the specified value.
		/// </summary>
		/// <param name="statePropertyName">The name of the state property.</param>
		/// <param name="value">The value to use for the state property.</param>
		public void SetStateValue(StateUser user, string statePropertyName, object value)
		{
			StateProperty property = this.GetProperty(statePropertyName);
			if (property == null)
				throw new NotFoundException("The state property could not be found with the name " + statePropertyName);

			this.SetStateValue(user, property, value);
		}

		/// <summary>
		/// Sets the value of a state property to the specified value.
		/// </summary>
		/// <param name="property">The state property.</param>
		/// <param name="value">The value to use for the state property.</param>
		public void SetStateValue(StateUser user, StateProperty property, object value)
		{
			if (property == null)
				throw new ArgumentNullException("property");

			bool result;
			if (value == null || DBNull.Value.Equals(value))
				result = this.GetDefaultProvider().SetValue(user, property, null);
			else
				result = this.GetDefaultProvider().SetValue(user, property, value);

			if (result)
				this.OnPropertyChanged(new StatePropertyChangedEventArgs(property, value));
		}

		#endregion
	}
}
