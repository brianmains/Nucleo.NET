using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Nucleo;


namespace Nucleo.Services
{
	public class InMemoryRequestHeaderService : BaseCollectionService, IRequestHeaderService
	{
		#region IRequestHeaderService Members

		public NameValueCollection GetAll()
		{
			NameValueCollection values = new NameValueCollection();
			foreach (KeyValuePair<string, object> value in this.Items)
				values.Add(value.Key, (value.Value != null) ? value.Value.ToString() : string.Empty);

			return values;
		}

		#endregion
	}
}
