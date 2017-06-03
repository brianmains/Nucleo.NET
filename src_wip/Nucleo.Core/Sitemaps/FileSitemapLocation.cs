using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace Nucleo.Sitemaps
{
	public class FileSitemapLocation : ISitemapLocation
	{
		public string FullName
		{
			get;
			private set;
		}



		public FileSitemapLocation(string fullName)
		{
			Guard.NotNull(fullName);

			FullName = fullName;
		}
	}
}
