using System;
using System.Collections.Generic;

using Nucleo.IO;


namespace Nucleo.Services
{
	public class InMemoryPostedFilesService : IPostedFilesService
	{
		private List<PostedFile> _files = new List<PostedFile>();



		#region " Constructors "

		public InMemoryPostedFilesService() { }

		public InMemoryPostedFilesService(List<PostedFile> files)
		{
			Guard.NotNull(files);

			_files = files;
		}

		#endregion



		#region " Methods "

		public void Add(PostedFile file)
		{
			_files.Add(file);
		}

		public PostedFile Get(string key)
		{
			foreach (PostedFile file in _files)
			{
				if (file.FileName == key)
					return file;
			}

			return null;
		}

		public PostedFile Get(int index)
		{
			return _files[index];
		}

		public void Remove(PostedFile file)
		{
			_files.Remove(file);
		}

		public void RemoveAt(int index)
		{
			_files.RemoveAt(index);
		}

		#endregion
	}
}
