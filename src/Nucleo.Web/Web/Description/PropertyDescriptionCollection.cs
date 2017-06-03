using System;
using System.Web.Script.Serialization;
using System.Collections.Generic;


namespace Nucleo.Web.Description
{
	public class PropertyDescriptionCollection : Dictionary<string, object>
	{
		#region " Methods "

		public string GetScript()
		{
			if (this.Count == 0)
				return "{}";

			string script = "{ ";
			bool comma = false;

			foreach (KeyValuePair<string, object> prop in this)
			{
				if (comma)
					script += ", ";
				else
					comma = true;

				script += string.Concat(prop.Key, ":");

				JavaScriptSerializer ser = new JavaScriptSerializer();
				script += ser.Serialize(prop.Value);
			}

			return script + " }";
		}

		#endregion
	}
}
