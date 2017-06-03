using System;
using System.IO;
using System.Web;


namespace Nucleo.IO
{
	/// <summary>
	/// Represents a posted file, a file that was posted to the server.
	/// </summary>
	public class PostedFile
	{
		private HttpPostedFileBase _file = null;




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

		public PostedFile(HttpPostedFileBase file)
		{
			Guard.NotNull(file);

			_file = file;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Saves the file as a specified file name.
		/// </summary>
		/// <param name="fileName">The full name of the file.</param>
		/// <exception cref="ArgumentNullException">Thrown when the file name is null or empty.</exception>
		public void SaveAs(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new ArgumentNullException("fileName");

			_file.SaveAs(fileName);
		}

		#endregion
	}
}
