using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.IO
{
	public class Extension
	{
		public string Name
		{
			get;
			private set;
		}



		public Extension(string name)
		{
			Guard.NotNullOrEmpty(name);

			this.Name = (name.StartsWith(".")) ? name.Substring(1) : name;
		}
	}
}
