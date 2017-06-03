using System;
using System.Collections.Generic;


namespace Nucleo.Windows.UI
{
	public sealed class ValuePath : IEnumerable<string>
	{
		private List<string> _values = null;



		#region " Properties "

		public string Separator
		{
			get { return ">"; }
		}

		internal List<string> Values
		{
			get
			{
				if (_values == null)
					_values = new List<string>();

				return _values;
			}
		}

		#endregion



		#region " Constructors "

		public ValuePath() { }

		public ValuePath(string singlePath)
		{
			this.Values.Add(singlePath);
		}

		public ValuePath(params string[] paths)
		{
			this.Values.AddRange(paths);
		}

		#endregion



		#region " Methods "

		public void AddValue(string value)
		{
			this.Values.Add(value);
		}

		public void AddValues(params string[] values)
		{
			this.Values.AddRange(values);
		}

		public IEnumerator<string> GetEnumerator()
		{
			return this.Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Values.GetEnumerator();
		}

		public override string ToString()
		{
			if (this.Values.Count == 0)
				return string.Empty;

			string output = this.Values[0];
			if (this.Values.Count == 1)
				return output;

			for (int i = 1; i < this.Values.Count; i++)
				output += this.Separator + this.Values[i];

			return output;
		}

		#endregion
	}
}
