using System;
using Nucleo.Collections;


namespace Nucleo.Math
{
	public class IndexRow
	{
		private SimpleCollection<int> _values = null;



		#region " Properties "

		public SimpleCollection<int> Values
		{
			get
			{
				if (_values == null)
					_values = new SimpleCollection<int>();
				return _values;
			}
		}

		#endregion



		#region " Constructors "

		public IndexRow() { }

		public IndexRow(int value)
		{
			_values = new SimpleCollection<int>();
			_values.Add(value);
		}

		public IndexRow(params int[] values)
		{
			_values = new SimpleCollection<int>();

			foreach (int value in values)
				_values.Add(value);
		}

		#endregion
	}
}
