using System;
using Nucleo.Context.Services;


namespace Nucleo.Web.Context.Services
{
	public class InlineRequestHeaderService : BaseInlineServiceDictionary, IRequestHeaderService
	{
		#region IRequestHeaderService Members

		public System.Collections.Specialized.NameValueCollection GetAll()
		{
			return base.ToNameValueCollection();
		}

		#endregion
	}
}
