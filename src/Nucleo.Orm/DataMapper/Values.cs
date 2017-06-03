using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.DataMapper
{
	public static class Values
	{
		#region " Methods "

		public static AutoGenerateValue AutoGenerate(long start, long step)
		{
			return new AutoGenerateValue(start, step);
		}

		public static DirectValue AsIs(object value)
		{
			return new DirectValue(value);
		}

		public static IgnoreValue Ignore()
		{
			return new IgnoreValue();
		}

		public static ListValue List(IEnumerable list)
		{
			return new ListValue(list);
		}

		public static ListValue List<T>(IEnumerable<T> list)
		{
			return new ListValue((IEnumerable)list);
		}

		public static NullValue Null()
		{
			return new NullValue();
		}

		public static RangesValue Range(long min, long max)
		{
			return new RangesValue(min, max, 1);
		}

		public static RangesValue Range(long min, long max, long step)
		{
			return new RangesValue(min, max, step);
		}

		public static DirectValue Text(string text)
		{
			return new DirectValue(text);
		}

		#endregion
	}
}
