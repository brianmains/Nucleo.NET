using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper
{
	public class AutoGenerateValue : IAutoIncrementValue
	{
		private long _current = 0;
		private long _start = 1;
		private long _step = 1;



		#region " Properties "

		public long Current
		{
			get { return _current; }
		}

		public long Start
		{
			get { return _start; }
		}
		
		public long Step
		{
			get { return _step; }
		}

		#endregion



		#region " Constructors "

		public AutoGenerateValue(long start, long step)
		{
			_start = start;
			_step = step;

			_current = start;
		}

		#endregion



		#region " Methods "

		public object GetValue()
		{
			return this.Current;
		}

		/// <summary>
		/// Increments the value by the step; the value parameter is ignored.
		/// </summary>
		/// <param name="value">Ignored.</param>
		public void Increment(object value)
		{
			_current += this.Step;
		}

		#endregion
	}
}
