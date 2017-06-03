using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.Description
{
	public class ControlDescriptionCollection : Dictionary<string, IScriptControl>
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

			foreach (KeyValuePair<string, IScriptControl> control in this)
			{
				if (comma)
					script += ", ";
				else
					comma = true;

				script += control.Key + ":" + idFormatter.GetFormattedID(((Control)control.Value).ClientID, ScriptIDFormatting.Control);
			}

			return script + " }";
		}

		#endregion
	}
}
