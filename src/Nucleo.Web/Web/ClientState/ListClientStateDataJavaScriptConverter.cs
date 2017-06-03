using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;


namespace Nucleo.Web.ClientState
{
	public class ListClientStateDataJavaScriptConverter : JavaScriptConverter
	{
		#region " Properties "

		public override IEnumerable<Type> SupportedTypes
		{
			get { return new Type[] { typeof(ListClientStateData) }; }
		}

		#endregion



		#region " Methods "

		public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
		{
			ListClientStateData stateData = new ListClientStateData();
			if (dictionary.ContainsKey("additions"))
				stateData.Additions.AddRange((ArrayList)dictionary["additions"]);
			if (dictionary.ContainsKey("removals"))
				stateData.Removals.AddRange((ArrayList)dictionary["removals"]);
			if (dictionary.ContainsKey("updates"))
				stateData.Updates.AddRange((ArrayList)dictionary["updates"]);
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
			ListClientStateData stateData = (ListClientStateData)obj;
			Dictionary<string, object> output = new Dictionary<string, object>();

			output.Add("additions", stateData.Additions.ToArray());
			output.Add("removals", stateData.Removals.ToArray());
			output.Add("updates", stateData.Updates.ToArray());
			output.Add("values", stateData.Values.ToDictionary());

			return output;
		}

		#endregion
	}
}
