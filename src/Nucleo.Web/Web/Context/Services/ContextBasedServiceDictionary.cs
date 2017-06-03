using System;
using System.Collections.Specialized;

using Nucleo.Context;
using Nucleo.Web.Core;


namespace Nucleo.Web.Context.Services
{
	public abstract class ContextBasedServiceDictionary : IServiceDictionary
	{
		#region " Properties "

		public int Count
		{
			get { return this.GetUnderlyingCollection().Count; }
		}

		public object this[string key]
		{
			get { return this.GetUnderlyingCollection()[key]; }
			set { this.GetUnderlyingCollection()[key] = (value != null) ? value.ToString() : default(string); }
		}

		#endregion



		#region " Methods "

		public void Add(string key, object value)
		{
			this.GetUnderlyingCollection().Add(key, (value != null) ? value.ToString() : default(string));
		}

		public bool Contains(string key)
		{
			return (this.GetUnderlyingCollection().Get(key) != null);
		}

		public object Get(string key)
		{
			return this.GetUnderlyingCollection().Get(key);
		}

		public object Get(int index)
		{
			return this.GetUnderlyingCollection().Get(index);
		}

		protected abstract NameValueCollection GetUnderlyingCollection();

		public void Remove(string key)
		{
			this.GetUnderlyingCollection().Remove(key);
		}

		public void RemoveAt(int index)
		{
			string key = this.GetUnderlyingCollection().Keys[index];
			this.Remove(key);
		}

		#endregion
	}
}
