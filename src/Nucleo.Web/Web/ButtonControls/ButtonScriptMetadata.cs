using System;
using System.Collections.Generic;
using System.Web.UI;


namespace Nucleo.Web.ButtonControls
{
	public class ButtonScriptMetadata : WebScriptMetadata
	{
		#region " Methods "

		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(Button), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(Button), ScriptMode.Release));
#endif

			return list;
		}

		#endregion
	}
}
