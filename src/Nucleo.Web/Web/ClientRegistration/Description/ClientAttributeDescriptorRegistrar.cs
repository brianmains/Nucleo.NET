using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Reflection;

using Nucleo.Reflection;


namespace Nucleo.Web.ClientRegistration.Description
{
	public class ClientAttributeDescriptorRegistrar : IDescriptorRegistrar
	{
		#region " Methods "

		private ClientDescriptorEventCollection CreateEventReflections(object target)
		{
			var events = Reflect.Public(target).Events().WithAttribute(typeof(ClientEventAttribute));
			var list = new ClientDescriptorEventCollection();

			foreach (ReflectEvent eventInfo in events)
			{
				ClientEventAttribute attribute = (ClientEventAttribute)eventInfo.GetAttribute(typeof(ClientEventAttribute), true);
				if (attribute == null)
					continue;

				list.Add(new ClientDescriptorEvent(attribute.ClientName ?? eventInfo.Name, eventInfo.Name, attribute.ClientEventHandlerPropertyName));
			}

			return list;
		}

		private ClientDescriptorEventCollection CreatePropertyEventReflections(object target)
		{
			var properties = Reflect.Public(target).Properties().WithAttribute(typeof(ClientEventAttribute));
			var list = new ClientDescriptorEventCollection();

			foreach (ReflectProperty property in properties)
			{
				ClientEventAttribute attribute = (ClientEventAttribute)property.GetAttribute(typeof(ClientEventAttribute), true);
				if (attribute == null)
					continue;

				list.Add(new ClientDescriptorEvent(attribute.ClientName ?? property.Name, property.Name));
			}

			return list;
		}

		private ClientDescriptorPropertyCollection CreatePropertyReflections(object target)
		{
			var properties = Reflect.Public(target).Properties().WithAttribute(typeof(ClientPropertyAttribute));
			var list = new ClientDescriptorPropertyCollection();

			foreach (ReflectProperty property in properties)
			{
				ClientPropertyAttribute attribute = (ClientPropertyAttribute)property.GetAttribute(typeof(ClientPropertyAttribute), true);
				if (attribute == null)
					continue;

				if (!string.IsNullOrEmpty(attribute.JavascriptConverterType))
				{
					JavaScriptConverter converter = (JavaScriptConverter)Activator.CreateInstance(Type.GetType(attribute.JavascriptConverterType));
					JavaScriptSerializer serializer = new JavaScriptSerializer();
					serializer.RegisterConverters(new JavaScriptConverter[] { converter });

					list.Add(new ClientDescriptorProperty(attribute.ClientName ?? property.Name, property.Name,
						attribute.ContentType, serializer.Serialize(property.GetValue()) ?? attribute.DefaultValue));
				}
				else
					list.Add(new ClientDescriptorProperty(attribute.ClientName ?? property.Name, property.Name,
						attribute.ContentType, property.GetValue() ?? attribute.DefaultValue));
			}

			return list;
		}

		public ClientDescriptorEventCollection GetEvents(object target)
		{
			var list = new ClientDescriptorEventCollection();
			list.AddRange(this.CreateEventReflections(target));
			list.AddRange(this.CreatePropertyEventReflections(target));

			return list;
		}

		public ClientDescriptorPropertyCollection GetProperties(object target)
		{
			var list = new ClientDescriptorPropertyCollection();
			list.AddRange(this.CreatePropertyReflections(target));

			return list;
		}

		#endregion
	}
}
