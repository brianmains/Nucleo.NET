using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace Nucleo.IO
{
	public class FoundFile : IFoundObject
	{
		public string FullName
		{
			get;
			private set;
		}

		public string ShortName
		{
			get;
			private set;
		}



		public FoundFile(string shortName, string fullName)
		{
			Guard.NotNullOrEmpty(shortName);
			Guard.NotNullOrEmpty(fullName);

			this.ShortName = shortName;
			this.FullName = fullName;
		}
	}
}
