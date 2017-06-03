using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Reflection
{
	/// <summary>
	/// Represents a helpful type checking class.
	/// </summary>
	public static class TypeUtility
	{
		public static bool IsEnumeratedType(string typeName)
		{
			Guard.NotNullOrEmpty(typeName);

			return IsEnumeratedType(Type.GetType(typeName));
		}

		public static bool IsEnumeratedType(Type type)
		{
			Guard.NotNull(type);
			
			return type.IsEnum;
		}

		public static bool IsNumericType(string typeName)
		{
			if (string.IsNullOrEmpty(typeName))
				throw new ArgumentNullException("typeName");

			if (typeName.ToLower() == "int")
				return IsNumericType(typeof(int));
			else if (typeName.ToLower() == "long")
				return IsNumericType(typeof(long));
			else if (typeName.ToLower() == "short")
				return IsNumericType(typeof(short));
			else if (typeName.ToLower() == "double")
				return IsNumericType(typeof(double));
			else if (typeName.ToLower() == "decimal")
				return IsNumericType(typeof(decimal));
			else if (typeName.ToLower() == "float")
				return IsNumericType(typeof(float));

			return IsNumericType(Type.GetType(typeName));
		}

		public static bool IsNumericType(Type type)
		{
			if (!type.IsValueType)
				return false;

			return type.Equals(typeof(int)) ||
				type.Equals(typeof(long)) ||
				type.Equals(typeof(short)) ||
				type.Equals(typeof(double)) ||
				type.Equals(typeof(decimal)) ||
				type.Equals(typeof(float)) ||
				type.Equals(typeof(Single)) ||
				type.Equals(typeof(Int32)) ||
				type.Equals(typeof(Int16)) ||
				type.Equals(typeof(Int64)) ||
				type.Equals(typeof(Double));
		}

		public static bool IsValueType(string typeName)
		{
			return IsValueType(Type.GetType(typeName));
		}

		public static bool IsValueType(Type type)
		{
			return type.IsValueType;
		}
	}
}
