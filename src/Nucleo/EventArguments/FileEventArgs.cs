using System;
using System.IO;


namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents the event argument that is used for a file.
	/// </summary>
	public class FileEventArgs
	{
		private string _fileName;



		#region " Properties "

		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		public string FileName
		{
			get { return _fileName; }
		}

		/// <summary>
		/// Opens up the file stream, if the file exists on disk.
		/// </summary>
		public FileStream Stream
		{
			get
			{
				if (File.Exists(_fileName))
					return File.Open(_fileName, FileMode.Open);
				return null;
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the event arguments with the file.
		/// </summary>
		/// <param name="fileName">The name of the file.</param>
		public FileEventArgs(string fileName)
		{
			_fileName = fileName;
		}

		#endregion
	}

	public delegate void FileEventHandler(object sender, FileEventArgs e);
}
