using System;
using System.Web.UI;
using System.Collections.Generic;


namespace Nucleo.Web.Description
{
	public class ExtenderDescriptionCollection : Dictionary<string, IExtenderControl>
	{
		#region " Methods "

		public string GetScript()
		{
			return this.GetScript(new MSScriptIDFormatter());
		}

		public string GetScript(IScriptIDFormatter idFormatter)
		{
			if (idFormatter == null)
				throw new ArgumentNullException("idFormatter");

			if (this.Count == 0)
				return "{}";

			string script = "{ ";
			bool comma = false;

			foreach (KeyValuePair<string, IExtenderControl> extender in this)
			{
				if (comma)
					script += ", ";
				else
					comma = true;

				script += extender.Key + ":" + idFormatter.GetFormattedID(((Control)extender.Value).ClientID, ScriptIDFormatting.Extender);
			}

			return script + " }";
		}

		#endregion
	}
}
