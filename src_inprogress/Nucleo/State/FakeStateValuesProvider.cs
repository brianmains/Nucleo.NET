using System;
using System.Collections.Generic;


namespace Nucleo.State
{
	/// <summary>
	/// A fake state values provider that defines five pre-defined values, or you can provide your own.
	/// </summary>
	/// <remarks>The values are: "Requires Authentication", "Days Without Accident", "Current Volunteer Count", "Current Employee Count", and "Application Name".</remarks>
	public class FakeStateValuesProvider : StateValuesProvider
	{
		private Dictionary<string, object> _items = null;



		#region " Properties "

		public Dictionary<string, object> Items
		{
			get
			{
				if (_items == null)
				{
					_items = new Dictionary<string, object>();
					_items.Add("Requires Authentication", true);
					_items.Add("Days Without Accident", 197);
					_items.Add("Current Volunteer Count", 3);
					_items.Add("Current Employee Count", 376);
					_items.Add("Application Name", "Site Manager");
				}

				return _items;
			}
		}

		#endregion



		#region " Constructors "

		public FakeStateValuesProvider()
			: base() { }

		public FakeStateValuesProvider(Dictionary<string, object> values)
		{
			_items = values;
		}

		#endregion



		#region " Methods "

		private string GetRegionKey(StateProperty property, string regionName)
		{
			return property.Name + "_" + regionName;
		}

		public override object GetRegionValue(StateUser user, StateProperty property, string regionName)
		{
			return GetValueInternal(GetRegionKey(property, regionName), property.DefaultValue);
		}

		public override object GetValue(StateUser user, StateProperty property)
		{
			return GetValueInternal(property.Name, property.DefaultValue);
		}

		private object GetValueInternal(string key, object defaultValue)
		{
			if (this.Items.ContainsKey(key))
				return this.Items[key];
			else
				return defaultValue;
		}

		public override bool SetRegionValue(StateUser user, StateProperty property, string regionName, object propertyValue)
		{
			return this.SetValueInternal(GetRegionKey(property, regionName), propertyValue); 
		}

		public override bool SetValue(StateUser user, StateProperty property, object propertyValue)
		{
			return this.SetValueInternal(property.Name, propertyValue);
		}

		private bool SetValueInternal(string key, object propertyValue)
		{
			if (!this.Items.ContainsKey(key))
			{
				this.Items.Add(key, propertyValue);
				return true;
			}
			else
			{
				if (this.Items[key] != propertyValue)
				{
					this.Items[key] = propertyValue;
					return true;
				}
				else
					return false;
			}
		}

		#endregion
	}
}
