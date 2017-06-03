using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.IO
{
	public class DirectorySearcherOptions
	{
		private ExtensionCollection _extensions = null;



		public ExtensionCollection Extensions
		{
			get
			{
				if (_extensions == null)
					_extensions = new ExtensionCollection();

				return _extensions;
			}
			set { _extensions = value; }
		}

		public string RootFolder
		{
			get;
			set;
		}
	}
}
