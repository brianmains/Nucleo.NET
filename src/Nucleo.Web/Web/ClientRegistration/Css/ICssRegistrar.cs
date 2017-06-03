using System;
using System.Collections.Generic;


namespace Nucleo.Web.ClientRegistration.Css
{
	public interface ICssRegistrar
	{
		CssReferenceRequestDetailsCollection GetPrimaryDetails(object target);
	}
}
