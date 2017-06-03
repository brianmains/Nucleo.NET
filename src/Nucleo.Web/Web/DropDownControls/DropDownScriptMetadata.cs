using System;
using System.Collections.Generic;
using System.Web.UI;

using Nucleo.Web.Scripts;
using Nucleo.Web.Templates;


namespace Nucleo.Web.DropDownControls
{
	/// <summary>
	/// Represents the scripts for the drop down control.
	/// </summary>
	public class DropDownScriptMetadata : WebScriptMetadata
	{
		#region " Properties "

		new public DropDown Component
		{
			get { return (DropDown)base.Component; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the primary scripts for the drop down control.
		/// </summary>
		/// <returns>The scripts for the drop down.</returns>
		public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
		{
			ScriptReferencingRequestDetailsCollection list = new ScriptReferencingRequestDetailsCollection();

#if DEBUG
			list.Add(new ScriptReferencingRequestDetails(typeof(DropDown), ScriptMode.Debug));
#else
			list.Add(new ScriptReferencingRequestDetails(typeof(DropDown), ScriptMode.Release));
#endif

			return list;
		}

		#endregion
	}
}