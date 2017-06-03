using System;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a generic component that can be used to register script metadata for a component.  This should only be used for derived classes, because of the generic, type-specific way this component works.
	/// </summary>
	public class CoreWebScriptMetadata : WebScriptMetadata
	{
		#region " Methods "

		/// <summary>
		/// Gets the primary scripts for the component.  Assumes the script uses the same name as the server-side component.
		/// </summary>
		/// <returns></returns>
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(this.Component.GetType(), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(this.Component.GetType(), ScriptMode.Release));
#endif

			return list;
		}

		#endregion
	}
}
