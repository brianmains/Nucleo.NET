using Nucleo;


namespace System
{
	public static class DateTimeExtensions
	{
		#region " Methods "

		public static DateTime AddBusinessDays(this DateTime date, int days)
		{
			return (new BusinessDays(days)).AddTo(date);
		}

		public static DateTime SubtractBusinessDays(this DateTime date, int days)
		{
			return (new BusinessDays(days)).SubtractFrom(date);
		}

		#endregion
	}
}
