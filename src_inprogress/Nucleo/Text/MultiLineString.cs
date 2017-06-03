using System;
using System.Text;
using Nucleo.Collections;


namespace Nucleo.Text
{
	public class MultiLineString
	{
		private CollectionBase<string> _lines = null;
		private bool _allowEmptyLines = false;
		private static object _lock = new object();



		#region " Properties "

		public bool AllowEmptyLines
		{
			get { return _allowEmptyLines; }
			set { _allowEmptyLines = value; }
		}

		public int LineCount
		{
			get { return _lines.Count; }
		}

		public string this[int index]
		{
			get { return _lines[index]; }
		}

		#endregion



		#region " Constructors "

		public MultiLineString(string text) : this(text, false) { }

		public MultiLineString(string text, bool allowEmptyLines)
		{
			_allowEmptyLines = allowEmptyLines;
			_lines = new CollectionBase<string>();

			string[] lines = text.Split('\n');

			foreach (string line in lines)
			{
				if (line != null && line != "\r")
					this.AddLine(line);
				else if ((string.IsNullOrEmpty(line) || line == "\r") && this.AllowEmptyLines)
					this.AddLine(string.Empty);
			}
		}

		public MultiLineString(StringBuilder builder) : this(builder, false) { }

		public MultiLineString(StringBuilder builder, bool allowEmptyLines) : this(builder.ToString(), allowEmptyLines) { }

		#endregion



		#region " Methods "

		public void AddLine(string line)
		{
			if (!this.AllowEmptyLines && string.IsNullOrEmpty(line))
				throw new ArgumentNullException("line");

			lock (_lock)
			{
				_lines.Add(this.TrimLine(line));
			}
		}

		public void AddText(string text)
		{
			string[] lines;
			if (text.Contains("\n"))
				lines = text.Split('\n');
			else
				lines = new string[] { text };

			foreach (string line in lines)
				this.AddLine(line);
		}

		public void RemoveLine(int index)
		{
			lock (_lock)
			{
				_lines.RemoveAt(index);
			}
		}

		public override string ToString()
		{
			string output = string.Empty;

			foreach (string line in _lines)
				output += line + "\n";

			return output;
		}

		private string TrimLine(string line)
		{
			return line.Trim(new char[] { ' ', '\t', '\r' });
		}

		#endregion
	}
}
