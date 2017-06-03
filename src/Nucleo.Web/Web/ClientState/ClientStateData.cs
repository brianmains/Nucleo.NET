using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Nucleo.Collections;


namespace Nucleo.Web.ClientState
{
	public class ClientStateData
	{
		
		private ClientStateDictionary _values = null;



		#region " Properties "

		/// <summary>
		/// Gets the values that were supplied in client state (changes and such).
		/// </summary>
		public ClientStateDictionary Values
		{
			get
			{
				if (_values == null)
					_values = new ClientStateDictionary();
				return _values;
			}
		}

		#endregion



		#region " Constructors "

		public ClientStateData() { }

		public ClientStateData(ClientStateDictionary values)
		{
			_values = values;
		}

		#endregion



		#region " Methods "

		public static ClientStateData FromJson(string json)
		{
			if (string.IsNullOrEmpty(json))
				throw new ArgumentNullException("json");

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { new ClientStateDataJavaScriptConverter() });

			return serializer.Deserialize<ClientStateData>(json);
		}

		public virtual string ToJson()
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			serializer.RegisterConverters(new JavaScriptConverter[] { new ClientStateDataJavaScriptConverter() });

			return serializer.Serialize(this);
		}

		#endregion
	}
}
