using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ClientRegistration;


namespace Nucleo.Web.ControlStorage
{
	public class ControlPropertyOptions
	{
		public ClientPropertyContentType ContentType 
		{ 
			get; 
			set; 
		}

		public ControlPropertyStorage Storage
		{
			get;
			set;
		}
	}
}
