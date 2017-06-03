using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Web.Routing
{
	public class DirectRoute
	{
		public string Area
		{
			get;
			set;
		}

		public bool IsShared
		{
			get;
			set;
		}

		public string View
		{
			get;
			set;
		}
	}
}
