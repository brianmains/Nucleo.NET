using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;


namespace Nucleo.Web.Description
{
	public static class IAjaxScriptableComponentExtensions
	{
		#region " Methods "

		public static ComponentDescriptor CreateComponentDescriptor(this IAjaxScriptableComponent component, IContentRegistrar registrar)
		{
			ComponentDescriptor descriptor = null;

			if (component is Page || component is UserControl)
				descriptor = registrar.AddComponentDescriptor(new ComponentDescriptionRequestDetails(component.GetType().BaseType.FullName));
			else
				descriptor = registrar.AddComponentDescriptor(new ComponentDescriptionRequestDetails(component.GetType().FullName));
			descriptor.ComponentType = "View";

			return descriptor;
		}

		public static ComponentDescriptor CreateComponentDescriptor(this IAjaxScriptableComponent component, string clientTypeName, IContentRegistrar registrar)
		{
			ComponentDescriptor descriptor = registrar.AddComponentDescriptor(new ComponentDescriptionRequestDetails(clientTypeName));
			descriptor.ComponentType = "View";

			return descriptor;
		}

		#endregion
	}
}
