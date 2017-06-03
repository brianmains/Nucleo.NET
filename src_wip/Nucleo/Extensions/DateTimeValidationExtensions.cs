using System;
using System.Collections.Generic;
using System.Text;

using Nucleo;


namespace System
{
#if NET20
#else
	public static class DateTimeValidationExtensions
	{
		public static bool AreEqual(this DateTime value, DateTime compare, bool includeTime)
		{
			if (includeTime)
				return SpecificEquals(value, compare);
			else
				return GeneralEquals(value, compare);
		}

		public static bool IsInRange(this DateTime value, DateTime beginDate, DateTime endDate)
		{
			return (value >= beginDate && value <= endDate);
		}

		private static bool GeneralEquals(DateTime date1, DateTime date2)
		{
			return date1.ToShortDateString().Equals(date2.ToShortDateString());
		}

		private static bool SpecificEquals(DateTime date1, DateTime date2)
		{
			return date1.ToString().Equals(date2.ToString());
		}
	}
#endif
}
