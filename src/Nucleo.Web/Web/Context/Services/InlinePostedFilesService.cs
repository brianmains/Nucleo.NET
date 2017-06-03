using System;
using System.Collections.Generic;


namespace Nucleo.Web.Context.Services
{
	public class InlinePostedFilesService : IPostedFilesService
	{
		private List<PostedFile> _files = new List<PostedFile>();



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
