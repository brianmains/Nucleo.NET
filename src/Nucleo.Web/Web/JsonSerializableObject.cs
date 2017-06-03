using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

using Nucleo.Collections;
using Nucleo.ObjectModel;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents an object that uses attributes, and can be read to/from JSON.
	/// </summary>
	public abstract class JsonSerializableObject : AttributedObject
	{
		#region " Methods "

		/// <summary>
		/// Converts a JSON string and loads the values into this object.
		/// </summary>
		/// <param name="json">The JSON to load.</param>
		public void FromJson(string json)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			this.FromValuesList(serializer.Deserialize<Dictionary<string, object>>(json));
		}

		/// <summary>
		/// Converts the object  into a JSON string.
		/// </summary>
		/// <returns>The JSON string.</returns>
		public string ToJson()
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			return serializer.Serialize(this.ToValuesList());
		}

		#endregion
	}
}
