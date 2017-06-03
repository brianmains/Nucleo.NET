using System;
using System.Web.UI;


namespace Nucleo.Web.ListControls
{
	public class PageableListScriptMetadata : WebScriptMetadata
	{
		#region " Properties "

		new public PageableList Component
		{
			get { return (PageableList)base.Component; }
		}

		#endregion



		#region " Methods "

		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(PageableList), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(PageableList), ScriptMode.Release));
#endif

			return list;
		}

		#endregion
	}
}
