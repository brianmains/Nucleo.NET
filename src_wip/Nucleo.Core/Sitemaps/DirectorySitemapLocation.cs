using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace Nucleo.Sitemaps
{
	public class DirectorySitemapLocation : ISitemapLocation
	{
		public string FullName
		{
			get;
			private set;
		}



		public DirectorySitemapLocation(string fullName)
		{
			Guard.NotNull(fullName);

			FullName = fullName;
		}
	}
}
