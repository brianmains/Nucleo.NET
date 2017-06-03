using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.ClientRegistration.Description
{
	public interface IDescriptorRegistrar
	{
		ClientDescriptorEventCollection GetEvents(object target);

		ClientDescriptorPropertyCollection GetProperties(object target);
	}
}
