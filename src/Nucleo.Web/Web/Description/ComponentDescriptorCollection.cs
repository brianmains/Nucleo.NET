using System;

using Nucleo.Collections;


namespace Nucleo.Web.Description
{
	public class ComponentDescriptorCollection : SimpleCollection<ComponentDescriptor>
	{
		#region " Methods "

		/// <summary>
		/// Finds a component descriptor by its request details.
		/// </summary>
		/// <param name="details">The details used to find a component.</param>
		/// <returns>The matching descriptor, or null.</returns>
		public ComponentDescriptor GetByDetails(ComponentDescriptionRequestDetails details)
		{
			foreach (ComponentDescriptor descriptor in this)
			{
				if (string.Compare(descriptor.ClientType, details.ClientTypeName, StringComparison.InvariantCultureIgnoreCase) == 0)
					return descriptor;
			}

			return null;
		}

		#endregion
	}
}
