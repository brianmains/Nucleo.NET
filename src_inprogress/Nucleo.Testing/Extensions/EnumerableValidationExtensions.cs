using System;
using System.Collections;
using System.Collections.Generic;



namespace Nucleo.Collections
{
#if NET20
#else
	public static class EnumerableValidationExtensions
	{
		#region " Methods "

		public static bool AreEqual<T>(this IList<T> list, IList<T> compare)
		{
			if (list == null && compare == null)
				return true;
			if (list == null || compare == null)
				return false;
			if (list.Count != compare.Count)
				return false;

			for(int i = 0; i < list.Count; i++)
			{
				if (!Object.Equals(list[i], compare[i]))
					return false;
			}

			return true;
		}

		public static bool AreEqual<T>(this IEnumerable<T> list, IEnumerable<T> compare)
		{
			if (list == null && compare == null)
				return true;
			if (list == null || compare == null)
				return false;

			var listEnum = list.GetEnumerator();
			var compareEnum = compare.GetEnumerator();

			while (listEnum.MoveNext())
			{
				if (!compareEnum.MoveNext())
					return false;

				if (!Object.Equals(listEnum.Current, compareEnum.Current))
					return false;
			}

			//Compare list has one too many
			if (compareEnum.MoveNext())
				return false;

			return true;
		}

		public static bool IsAll<T>(this IEnumerable<T> list, Func<T, bool> evaluationExpression, ValidationIsAllCheck checkType)
		{
			foreach (T item in list)
			{
				bool val = evaluationExpression(item);
				//Each item should evaluate to the expected value

				if (checkType == ValidationIsAllCheck.True && val != true || 
					checkType == ValidationIsAllCheck.False && val != false)
					return false;
			}

			return true;
		}

		public static bool IsAllTrue<T>(this IEnumerable<T> list, Func<T, bool> evaluationExpression)
		{
			foreach (T item in list)
			{
				bool val = evaluationExpression(item);
				//Each item should evaluate to the expected value

				if (val != true)
					return false;
			}

			return true;
		}

		public static bool IsInRange<T>(this IEnumerable<T> list, Func<T, bool> expr, int minCount)
		{
			return IsInRange(list, expr, minCount, null);
		}

		public static bool IsInRange<T>(this IEnumerable<T> list, Func<T, bool> expr, long maxCount)
		{
			return IsInRange(list, expr, null, maxCount);
		}

		public static bool IsInRange<T>(this IEnumerable<T> list, Func<T, bool> expr, int? minCount, long? maxCount)
		{
			long count = 0;

			foreach (T item in list)
			{
				if (expr(item))
					count++;
			}

			if ((minCount.HasValue && minCount.Value > count) ||
				(maxCount.HasValue && maxCount.Value < count))
				return false;

			return true;
		}

		public static bool IsInstanceOf<T, V>(this IEnumerable<T> list, Func<T, object> expr)
		{
			foreach (T item in list)
			{
				object value = expr(item);

				if (!(value is V))
					return false;
			}

			return true;
		}

		public static bool IsNotNull<T>(this IEnumerable<T> list)
		{
			return IsNotNull(list, null);
		}

		public static bool IsNotNull<T>(this IEnumerable<T> list, Func<T, object> expr)
		{
			return NullStatus(list, expr, false);
		}

		public static bool IsNull<T>(this IEnumerable<T> list)
		{
			return IsNull(list, null);
		}

		public static bool IsNull<T>(this IEnumerable<T> list, Func<T, object> expr)
		{
			return NullStatus(list, expr, true);
		}

		private static bool NullStatus<T>(this IEnumerable<T> list, Func<T, object> expr, bool shouldBeNull)
		{
			foreach (T expectedItem in list)
			{
				object value = (expr != null)
					? expr(expectedItem)
					: expectedItem;

				if (value == null || DBNull.Value.Equals(value))
				{
					//Null, ensure looking for null
					if (!shouldBeNull)
						return false;
				}
				else
				{
					//Not null, ensure looking for not null
					if (shouldBeNull)
						return false;
				}
			}

			return true;
		}

		#endregion
	}
#endif
}
