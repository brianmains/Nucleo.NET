using System;
using System.Collections.Generic;


namespace Nucleo.Web.Description
{
	public class EventDescriptionCollection : Dictionary<string, string>
	{
		#region " Methods "

		public string GetScript()
		{
			if (this.Count == 0)
				return "{}";

			string script = "{ ";
			bool comma = false;

			foreach (KeyValuePair<string, string> prop in this)
			{
				if (comma)
					script += ", ";
				else
					comma = true;

				//script += string.Concat(prop.Key, ":\"", prop.Value, "\"");
				script += string.Concat(prop.Key, ":", prop.Value);
			}

			return script + " }";
		}

		#endregion
	}
}
