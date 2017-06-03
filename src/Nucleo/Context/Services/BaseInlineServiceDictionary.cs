using System;
using System.Collections.Generic;
using System.Collections.Specialized;


namespace Nucleo.Context.Services
{
	public abstract class BaseInlineServiceDictionary : IServiceDictionary
	{
		private Dictionary<string, object> _items = null;



		#region " Properties "

		public int Count
		{
			get { return this.Items.Count; }
		}

		protected Dictionary<string, object> Items
		{
			get
			{
				if (_items == null)
					_items = new Dictionary<string, object>();
				return _items;
			}
		}

		public object this[string key]
		{
			get
			{
				if (this.Items.ContainsKey(key))
					return this.Items[key];
				else
					return null;
			}
			set
			{
				if (this.Items.ContainsKey(key))
					this.Items[key] = value;
				else
					this.Items.Add(key, value);
			}
		}

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			this.Items.Add(key, value);
		}

		public bool Contains(string key)
		{
			return this.Items.ContainsKey(key);
		}

		public object Get(string key)
		{
			return this.Items[key];
		}

		public object Get(int index)
		{
			string key = "";
			return this.Get(key);
		}

		public void Remove(string key)
		{
			this.Items.Remove(key);
		}

		public void RemoveAt(int index)
		{
			string key = "";
			this.Items.Remove(key);
		}

		protected virtual NameValueCollection ToNameValueCollection()
		{
			NameValueCollection values = new NameValueCollection();
			foreach (KeyValuePair<string, object> value in this.Items)
				values.Add(value.Key, (value.Value != null) ? value.Value.ToString() : string.Empty);

			return values;
		}

		#endregion
	}
}
