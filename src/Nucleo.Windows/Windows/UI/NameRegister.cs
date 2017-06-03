using System;
using Nucleo.Collections;
using System.Collections.Generic;


namespace Nucleo.Windows.UI
{
	internal class NameRegister
	{
		private TripletDictionary<string, ValuePath, Type> _items = null;



		#region " Properties "

		private TripletDictionary<string, ValuePath, Type> Items
		{
			get
			{
				if (_items == null)
					_items = new TripletDictionary<string, ValuePath, Type>();
				return _items;
			}
		}

		#endregion



		#region " Methods "

		public void Add(UIElement element)
		{
			this.Items.Add(element.Name, element.CurrentPath, element.GetType());
		}

		public bool Contains(string name)
		{
			return this.Items.ContainsKey(name);
		}

		public System.Collections.Generic.KeyValuePair<ValuePath, Type> GetValues(string key)
		{
			TripletItem<string, ValuePath, Type> item = this.Items[key];
			//If null, return an empty value
			if (item == null)
				return new System.Collections.Generic.KeyValuePair<ValuePath, Type>();

			return item.GetValues();
		}

		public bool Remove(UIElement element)
		{
			return this.Remove(element.Name);
		}

		public bool Remove(string name)
		{
			return this.Items.Remove(name);
		}

		#endregion
	}
}
