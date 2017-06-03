using System;


namespace Nucleo.EventArguments
{
	public class FileDialogEventArgs : FileEventArgs
	{
		private string _extension;
		private string _filter;
		private string _initialDirectory;
		private string _title;



		#region " Properties "

		public string Extension
		{
			get { return _extension; }
			set { _extension = value; }
		}

		public string Filter
		{
			get { return _filter; }
			set { _filter = value; }
		}

		public string InitialDirectory
		{
			get { return _initialDirectory; }
			set { _initialDirectory = value; }
		}

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		#endregion



		#region " Constructors "

		public FileDialogEventArgs(string fileName) : base(fileName) { }

		public FileDialogEventArgs(string fileName, string initialDirectory, string filter)
			: this(fileName)
		{
			_initialDirectory = initialDirectory;
			_filter = filter;
		}

		public FileDialogEventArgs(string fileName, Environment.SpecialFolder folder, string filter) 
			: this(fileName, Environment.GetFolderPath(folder), filter) { }

		public FileDialogEventArgs(string title, string fileName, string initialDirectory, string extension, string filter): this(fileName, initialDirectory, filter)
		{
			_extension = extension;
			_title = title;
		}

		public FileDialogEventArgs(string title, string fileName, Environment.SpecialFolder folder, string extension, string filter)
			: this(title, fileName, Environment.GetFolderPath(folder), extension, filter) { }

		#endregion
	}

	public delegate void FileDialogEventHandler(object sender, FileDialogEventArgs e);
}
