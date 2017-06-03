using System;
using System.Web.UI;

using Nucleo.Web;
using Nucleo.Web.Controls;


namespace Nucleo
{
	public class CommonScriptMetadata : WebScriptMetadata
	{
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(Check).Assembly.FullName, "Nucleo.Common", ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(Check).Assembly.FullName, "Nucleo.Common", ScriptMode.Release));
#endif

			return list;
		}
	}
}