using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ControlStorage;


namespace Nucleo.Web.ClientRegistration.Description
{
	public class ControlPropertyDictionaryDescriptorRegistrar : IDescriptorRegistrar
	{
		#region " Methods "

		public ClientDescriptorEventCollection GetEvents(object target)
		{
			if (!(target is IDictionaryControl))
				return null;

			var control = (IDictionaryControl)target;
			var list = new ClientDescriptorEventCollection();

			foreach (var propertyName in control.Values.PropertyNames)
			{
				var property = control.Values.Get(propertyName);
				if (property.Options.ContentType == ClientPropertyContentType.Event && property.Value != null)
					list.Add(new ClientDescriptorEvent(propertyName, property.Key, property.Value.ToString()));
			}

			return list;
		}

		public ClientDescriptorPropertyCollection GetProperties(object target)
		{
			if (!(target is IDictionaryControl))
				return null;

			var control = (IDictionaryControl)target;
			var list = new ClientDescriptorPropertyCollection();

			foreach (var propertyName in control.Values.PropertyNames)
			{
				var property = control.Values.Get(propertyName);

				if (property.Options.ContentType != ClientPropertyContentType.Event && property.Value != null)
				{
					list.Add(new ClientDescriptorProperty(propertyName, property.Key,
						property.Options.ContentType, property.Value.ToString()));
				}
			}

			return list;
		}

		#endregion
	}
}
