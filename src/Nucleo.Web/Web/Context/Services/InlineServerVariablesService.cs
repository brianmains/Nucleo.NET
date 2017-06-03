using System;

using Nucleo.Context.Services;


namespace Nucleo.Web.Context.Services
{
	public class InlineServerVariablesService : BaseInlineServiceDictionary, IServerVariablesService
	{
		#region " Methods "

		public System.Collections.Specialized.NameValueCollection GetAll()
		{
			return base.ToNameValueCollection();
		}

		#endregion
	}
}
