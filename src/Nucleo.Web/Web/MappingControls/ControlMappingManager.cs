using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Reflection;

using Nucleo.Collections;
using Nucleo.EventArguments;
using Nucleo.Web.Mappings;


namespace Nucleo.Web.MappingControls
{
	/// <summary>
	/// Represents a central manager for control mappings.
	/// </summary>
	[
	WebScriptMetadata(typeof(ControlMappingManagerScriptMetadata)),
	WebRenderer(typeof(ControlMappingManagerRenderer))
	]
	public class ControlMappingManager : BaseAjaxControl
	{
		#region " Properties "


		#endregion



		#region " Methods "

		protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
		{
			base.GetAjaxScriptDescriptors(registrar);

			NucleoScriptControlDescriptor descriptor = registrar.AddDescriptor<NucleoScriptControlDescriptor>(
				new ScriptDescriptionRequestDetails(this, typeof(ControlMappingManager), this.ClientID));
		}

		/// <summary>
		/// Gets an instance of the manager.
		/// </summary>
		/// <param name="page">The page to use to find the instance.</param>
		/// <returns>The instance of the manager.</returns>
		public static ControlMappingManager GetInstance(Page page)
		{
			if (page == null)
				throw new ArgumentNullException("page");

			return page.Items[typeof(ControlMappingManager)] as ControlMappingManager;
		}

		#endregion
	}
}
