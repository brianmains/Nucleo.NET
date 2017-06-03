using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using Nucleo.Context.Services;


namespace Nucleo.Web.Context.Services
{
	public class InlineQuerystringService : BaseInlineServiceDictionary, IQuerystringService
	{

		#region IQuerystringService Members

		public NameValueCollection GetAll()
		{
			return base.ToNameValueCollection();
		}

		#endregion
	}
}
