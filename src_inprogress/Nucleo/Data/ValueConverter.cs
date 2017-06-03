using System;


namespace Nucleo.Data
{
	public static class ValueConverter
	{
		#region " Methods "

		public static T GetValue<T>(object originalValue)
		{
			if (originalValue == null || DBNull.Value.Equals(originalValue))
				return default(T);

			if (originalValue is T)
				return (T)originalValue;
			else if (typeof(T).Equals(typeof(string)))
			{
				//Have to use an object to trick the compiler
				object stringValue = originalValue.ToString();
				return (T)stringValue;
			}
			else if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				Type parameterType = typeof(T).GetGenericArguments()[0];
				Type nullableType = typeof(Nullable<>).MakeGenericType(parameterType);
				return (T)Activator.CreateInstance(nullableType, new object[] { Convert.ChangeType(originalValue, parameterType) });
			}
			else
				return (T)Convert.ChangeType(originalValue, typeof(T));
		}

		#endregion
	}
}
