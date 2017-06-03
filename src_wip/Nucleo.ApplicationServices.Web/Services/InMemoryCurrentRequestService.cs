using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Services
{
	public class InMemoryCurrentRequestService : ICurrentRequestService
	{
		public string RawUrl
		{
			get;
			set;
		}
	}
}
