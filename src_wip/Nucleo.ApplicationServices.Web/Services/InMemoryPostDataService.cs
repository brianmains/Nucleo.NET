using System;
using System.Collections.Specialized;


namespace Nucleo.Services
{
	public class InMemoryPostDataService : IPostDataService
	{
		private NameValueCollection _items = null;



		#region " Constructors "

		public InMemoryPostDataService()
		{
			_items = new NameValueCollection();
		}

		public InMemoryPostDataService(NameValueCollection items)
		{
			_items = items;
		}

		#endregion



		#region " Methods "

		public string Get(string key)
		{
			return _items[key];
		}

		public string Get(int index)
		{
			return _items[index];
		}

		public System.Collections.Specialized.NameValueCollection GetAll()
		{
			return _items;
		}

		#endregion
	}
}
