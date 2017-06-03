using System;
using System.IO;


namespace Nucleo.IO
{
	public class FileReaderWriter : IDisposable
	{
		private StreamReader _reader = null;
		private StreamWriter _writer = null;

		private string _filePath = string.Empty;
		private bool _appendWriting = false;
		private InputMode _mode = InputMode.Unknown;



		#region " Enumerations "

		public enum InputMode
		{
			Read,
			Write,
			Unknown
		}

		#endregion



		#region " Properties "

		public bool AppendWriting
		{
			get { return _appendWriting; }
		}

		public InputMode Mode
		{
			get { return _mode; }
		}

		#endregion



		#region " Constructors "

		private FileReaderWriter() { }

		#endregion



		#region " Methods "

		public void ChangeModeForReading()
		{
			if (_mode == InputMode.Write && _writer != null)
			{
				_writer.Dispose();
				_writer = null;
			}

			_mode = InputMode.Read;
			_reader = new StreamReader(_filePath);
		}

		public void ChangeModeForWriting(bool appendWriting)
		{
			if (_mode == InputMode.Read && _reader != null)
			{
				_reader.Dispose();
				_reader = null;
			}

			_mode = InputMode.Write;
			_writer = new StreamWriter(_filePath, appendWriting);
		}

		public static FileReaderWriter CreateReaderWriter(string filePath)
		{
			return CreateReaderWriter(filePath, InputMode.Unknown);
		}

		public static FileReaderWriter CreateReaderWriter(string filePath, InputMode mode)
		{
			if (string.IsNullOrEmpty(filePath))
				throw new ArgumentNullException("filePath");
			if (mode == InputMode.Read && !File.Exists(filePath))
				throw new FileNotFoundException("The file could not be read from", filePath);

			FileReaderWriter fileIO = new FileReaderWriter();
			fileIO._filePath = filePath;
			fileIO._mode = mode;

			if (mode == InputMode.Read)
				fileIO.ChangeModeForReading();
			else if (mode == InputMode.Write)
				fileIO.ChangeModeForWriting(true);

			return fileIO;
		}

		public void Dispose()
		{
			_mode = InputMode.Unknown;

			if (_reader != null)
			{
				_reader.Dispose();
				_reader = null;
			}

			if (_writer != null)
			{
				_writer.Dispose();
				_writer = null;
			}
		}

		public string ReadAll()
		{
			this.ValidateReadingMode();
			return _reader.ReadToEnd();
		}

		public string ReadLine()
		{
			this.ValidateReadingMode();
			return _reader.ReadLine();
		}

		private void ValidateReadingMode()
		{
			if (_mode != InputMode.Read)
				throw new Exception("The reader/writer must be in read mode");
			if (_reader == null)
				throw new Exception();
		}

		private void ValidateWritingMode()
		{
			if (_mode != InputMode.Write)
				throw new Exception("The reader/writer must be in write mode");
			if (_writer == null)
				throw new Exception();
		}

		public void Write(object data)
		{
			this.ValidateWritingMode();
			_writer.Write(data);
		}

		public void WriteLine(object data)
		{
			this.ValidateWritingMode();
			_writer.WriteLine(data);
		}

		#endregion
	}
}
