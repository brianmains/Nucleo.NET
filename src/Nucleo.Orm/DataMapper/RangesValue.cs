using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper
{
	public class RangesValue : IRangeValue
	{
		private long _minimum = 0;
		private long _maximum = 0;
		private long _step = 1;



		#region " Properties "

		public long Maximum
		{
			get { return _maximum; }
		}

		public long Minimum
		{
			get { return _minimum; }
		}

		public long Step
		{
			get { return _step; }
		}

		#endregion



		#region " Constructors "

		public RangesValue(long min, long max, long step)
		{
			_minimum = min;
			_maximum = max;
			_step = (step > 0) ? step : 1;
		}

		#endregion



		#region " Methods "

		public object GetValue()
		{
			return (object)this.GetValues();
		}

		public object[] GetValues()
		{
			List<object> values = new List<object>();

			for (long i = this.Minimum; i <= this.Maximum; i += this.Step)
				values.Add(i);

			return values.ToArray();
		}

		#endregion
	}
}
