using System;
using System.Collections.Generic;


namespace Nucleo.Web.ClientState
{
	public class ClientStateDictionary
	{
		private Dictionary<string, object> _items = null;



		#region " Properties "

		public int Count
		{
			get { return this.Items.Count; }
		}

		private Dictionary<string, object> Items
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
			get { return this.Get(key); }
			set
			{
				if (this.Items.ContainsKey(key))
					this.Items[key] = value;
				else
					this.Items.Add(key, value);
			}
		}

		#endregion



		#region " Constructors "

		public ClientStateDictionary() { }

		public ClientStateDictionary(Dictionary<string, object> list)
		{
			foreach (KeyValuePair<string, object> item in list)
				this.Items.Add(item.Key, item.Value);
		}

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			this.Items.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return this.Items.ContainsKey(key);
		}

		public object Get(string key)
		{
			if (this.Items.ContainsKey(key))
				return this.Items[key];
			else
				return null;
		}

		public T Get<T>(string key)
		{
			return (T)(this.Get(key) ?? default(T));
		}

		public static ClientStateDictionary FromDictionary(Dictionary<string, object> dict)
		{
			ClientStateDictionary dictionary = new ClientStateDictionary();
			dictionary._items = dict;

			return dictionary;
		}

		public void Remove(string key)
		{
			this.Items.Remove(key);
		}

		public Dictionary<string, object> ToDictionary()
		{
			return this.Items;
		}

		#endregion
	}
}
