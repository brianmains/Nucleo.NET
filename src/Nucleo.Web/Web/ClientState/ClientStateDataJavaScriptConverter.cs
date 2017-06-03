using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace Nucleo.Web.ClientState
{
	public class ClientStateDataJavaScriptConverter : JavaScriptConverter
	{
		#region " Properties "

		public override IEnumerable<Type> SupportedTypes
		{
			get { return new Type[] { typeof(ClientStateData) }; }
		}

		#endregion



		#region " Methods "

		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			ClientStateData stateData = new ClientStateData();
			if (dictionary.ContainsKey("values"))
			{
				Dictionary<string, object> values = (Dictionary<string, object>)dictionary["values"];

				foreach (KeyValuePair<string, object> value in values)
					stateData.Values.Add(value.Key, value.Value);
			}

			return stateData;
		}

		public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
		{
			ClientStateData stateData = (ClientStateData)obj;
			Dictionary<string, object> output = new Dictionary<string, object>();
			output.Add("values", stateData.Values.ToDictionary());

			return output;
		}

		#endregion
	}
}
