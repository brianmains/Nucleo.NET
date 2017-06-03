using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web.ClientRegistration
{
	public class ClientDescriptorPropertyCollection : SimpleCollection<ClientDescriptorProperty>
	{
		public void AddRange(IEnumerable<ClientDescriptorProperty> properties)
		{
			foreach (var propertyInfo in properties)
				this.Add(propertyInfo);
		}
	}
}
