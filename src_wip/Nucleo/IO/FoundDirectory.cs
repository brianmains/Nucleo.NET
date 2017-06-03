using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.IO
{
	public class FoundDirectory : IFoundObject
	{
		private FoundDirectoryCollection _directories = null;
		private FoundFileCollection _files = null;



		public FoundDirectoryCollection Directories
		{
			get
			{
				if (_directories == null)
					_directories = new FoundDirectoryCollection();

				return _directories;
			}
			set { _directories = value; }
		}

		public FoundFileCollection Files
		{
			get
			{
				if (_files == null)
					_files = new FoundFileCollection();

				return _files;
			}
			set { _files = value; }
		}

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



		public FoundDirectory(string shortName, string fullName)
		{
			Guard.NotNullOrEmpty(shortName);
			Guard.NotNullOrEmpty(fullName);

			this.ShortName = shortName;
			this.FullName = fullName;
		}


	}
}
