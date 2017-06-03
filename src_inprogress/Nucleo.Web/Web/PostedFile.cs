using System;
using System.IO;
using System.Web;


namespace Nucleo.Web
{
	public class PostedFile
	{
#if NET20
		private HttpPostedFile _file = null;
#else
		private HttpPostedFileBase _file = null;
#endif



		#region " Properties "

		public int ContentLength 
		{
			get { return _file.ContentLength; }
		}

		public string ContentType
		{
			get { return _file.ContentType; }
		}

		public Stream FileContents
		{
			get { return _file.InputStream; }
		}

		public string FileName
		{
			get { return _file.FileName; }
		}

		#endregion



		#region " Constructors "

#if NET20
		public PostedFile(HttpPostedFile file)
		{
			_file = file;
		}
#else
		public PostedFile(HttpPostedFileBase file)
		{
			_file = file;
		}
#endif

		#endregion



		#region " Methods "

		public void SaveAs(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new ArgumentNullException("fileName");

			_file.SaveAs(fileName);
		}

		#endregion
	}
}
