using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Mvc
{
	public class SettingsDictionary
	{
		private Dictionary<string, object> _items = null;



		#region " Properties "

		private Dictionary<string, object> Items
		{
			get
			{
				if (_items == null)
					_items = new Dictionary<string, object>();
				return _items;
			}
		}

		#endregion



		#region " Constructors "

		public SettingsDictionary() { }

		public SettingsDictionary(Dictionary<string, object> settings)
		{
			_items = settings;
		}

		#endregion



		#region " Methods "

		public void AddSetting(string name, object value)
		{
			if (this.Items.ContainsKey(name))
				this.Items[name] = value;
			else
				this.Items.Add(name, value);
		}

		public object GetSetting(string name)
		{
			if (this.Items.ContainsKey(name))
				return this.Items[name];
			else
				return null;
		}

		public T GetSetting<T>(string name)
		{
			object value = GetSetting(name);

			if (value != null)
				return (T)Convert.ChangeType(value, typeof(T));
			else
				return default(T);
		}

		public void RemoveSetting(string name)
		{
			if (this.Items.ContainsKey(name))
				this.Items.Remove(name);
		}

		#endregion
	}
}
