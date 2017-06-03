using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using Nucleo;


namespace Nucleo.Services
{
	public class InMemoryServerVariablesService : BaseCollectionService, IServerVariablesService
	{
		#region " Methods "

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
