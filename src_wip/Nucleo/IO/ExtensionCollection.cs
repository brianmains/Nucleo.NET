using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Collections;


namespace Nucleo.IO
{
	public class ExtensionCollection : SimpleCollection<Extension>
	{
		public bool HasExtension(string extension)
		{
			string val = extension.ToLower();
			if (val.StartsWith("."))
				val = val.Substring(1);

			return this.Any(i => i.Name.ToLower() == extension);
		}
	}
}
