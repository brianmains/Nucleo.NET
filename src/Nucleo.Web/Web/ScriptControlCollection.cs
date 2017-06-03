using System;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Collections;


namespace Nucleo.Web
{
	public class ScriptControlCollection : SimpleCollection<IScriptControl>
	{
		#region " Constructors "

		public ScriptControlCollection() { }

		public ScriptControlCollection(IEnumerable<IScriptControl> controls)
		{
			foreach (IScriptControl control in controls)
				this.Add(control);
		}

		#endregion
	}
}
