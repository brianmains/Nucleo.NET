using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Web.EventsManagement
{
	public class ProviderErrorEvent : WebMonitoringEventBase
	{
		private const string EVENT_MESSAGE = "An error occurred within the provider '{0}', with an exception of: {1}";
		private const int EVENT_CODE = 100101;


		#region " Constructors "

		public ProviderErrorEvent(Type providerType, object source, Exception ex)
			: base(string.Format(EVENT_MESSAGE, providerType.FullName, ex.ToString()), source, EVENT_CODE) { }

		#endregion
	}
}
