using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace Nucleo.IO
{
	public class DirectorySearcher : IDirectorySearcher
	{
		private FoundFileCollection ProcessFilesInFolder(string folder, DirectorySearcherOptions options)
		{
			var files = Directory.GetFiles(folder).Where(i => options.Extensions.Count > 0
				? options.Extensions.HasExtension(Path.GetExtension(i).Substring(1))
				: true);
			var output = new FoundFileCollection();

			foreach (var f in files)
				output.Add(new FoundFile(Path.GetFileName(f), f));

			return output;
		}

		private FoundDirectory ProcessFolder(string folder, DirectorySearcherOptions options)
		{
			if (folder.EndsWith(@"\"))
				folder = folder.Substring(0, folder.Length - 1);

			string shortName = folder;
			if(shortName.Contains(@"\"))
				shortName = shortName.Substring(shortName.LastIndexOf(@"\") + 1);

			var root = new FoundDirectory(shortName, folder);
			root.Files = this.ProcessFilesInFolder(folder, options);

			var directoryNames = Directory.GetDirectories(folder);

			//recursively add any child directories
			foreach (var directoryName in directoryNames)
				root.Directories.Add(this.ProcessFolder(directoryName, options));

			return root;
		}


		public FoundDirectory Search(DirectorySearcherOptions options)
		{
			Guard.NotNull(options);

			return this.ProcessFolder(options.RootFolder, options);
		}
	}
}
