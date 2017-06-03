using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.Script.Serialization;

using Nucleo.Context;
using Nucleo.Logs;
using Nucleo.Reflection;
using Nucleo.Web.ClientRegistration.Description;


namespace Nucleo.Web.ClientRegistration
{
	public class ClientDescriptorRegistry
	{
		private ClientDescriptorEventCollection _events = null;
		private ClientDescriptorPropertyCollection _properties = null;



		#region " Properties "

		public ClientDescriptorEventCollection Events
		{
			get
			{
				if (_events == null)
					_events = new ClientDescriptorEventCollection();
				return _events;
			}
		}

		public ClientDescriptorPropertyCollection Properties
		{
			get
			{
				if (_properties == null)
					_properties = new ClientDescriptorPropertyCollection();
				return _properties;
			}
		}

		#endregion



		#region " Constructors "

		protected ClientDescriptorRegistry() { }

		#endregion



		#region " Methods "

		public static ClientDescriptorRegistry CreateFor(object target)
		{
			if (target == null)
				throw new ArgumentNullException("target");

			ClientDescriptorRegistry registry = new ClientDescriptorRegistry();

			if (target is IControlPropertyDictionaryDescriptorRegistryImplementation)
			{
				var reg = new ControlPropertyDictionaryDescriptorRegistrar();
				registry.Events.AddRange(reg.GetEvents(target));
				registry.Properties.AddRange(reg.GetProperties(target));
			}
			else
			{
				ClientDescriptionRegistrationAttribute attribute = Reflect.Public(target).Type().GetAttribute<ClientDescriptionRegistrationAttribute>(true);
				if (attribute == null)
					return null;

				var reg = new ClientAttributeDescriptorRegistrar();
				registry.Events.AddRange(reg.GetEvents(target));
				registry.Properties.AddRange(reg.GetProperties(target));
			}
		

			return registry;
		}

		#endregion
	}
}
