using System;
using System.Web.UI;

using Nucleo.Web.Styles;


namespace Nucleo.Web.Tags
{
	/// <summary>
	/// Represents a set of common tags that are normally established for controls.
	/// </summary>
	public static class CommonTagSettings
	{
		#region " Methods "

		/// <summary>
		/// Takes the client and unique ID of a control and adds it to the tag's attribute collection.
		/// </summary>
		/// <param name="tag">The tag to append to.</param>
		/// <param name="control">The control with the unique identifiers.</param>
		/// <example>
		/// TagElement tag = TagElementBuilder.Create("DIV");
		/// CommonTagSettings.SetIdentifiers(tag, controlRef);
		/// </example>
		public static void SetIdentifiers(TagElement tag, Control control)
		{
			tag.Attributes.AppendAttribute("id", control.ClientID)
				.AppendAttribute("name", control.UniqueID);
		}

		/// <summary>
		/// Takes the client and unique ID of a control and adds it to the tag's attribute collection.
		/// </summary>
		/// <param name="tag">The tag to append to.</param>
		/// <param name="control">The control with the unique identifiers.</param>
		/// <param name="partialID">A partial ID for a sub element.  Useful when rendering controls that need a unique ID.  Takes the client ID of the base control, and appends the partial ID to the end.</param>
		/// <example>
		/// TagElement childTag = TagElementBuilder.Create("DIV");
		/// CommonTagSettings.SetIdentifiers(tag, controlRef, "SUBDIV");
		/// </example>
		public static void SetIdentifiers(TagElement tag, Control control, string partialID)
		{
			tag.Attributes.AppendAttribute("id", string.Concat(control.ClientID, "_", partialID))
				.AppendAttribute("name", string.Concat(control.UniqueID, "$", partialID));
		}

		#endregion
	}
}
