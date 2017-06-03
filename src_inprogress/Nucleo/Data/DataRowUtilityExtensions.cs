using System;
using System.Data;


namespace Nucleo.Data
{
	public static class DataRowUtilityExtensions
	{
		public static void AssignFieldsToObject(this DataRow row, object businessObject)
		{
			DataRowUtility.AssignFieldsToObject(row, businessObject);
		}

		public static object GetValue(this DataRow row, string column)
		{
			return DataRowUtility.GetValue(row, column);
		}

		public static object GetValue(this DataRow row, int index)
		{
			return DataRowUtility.GetValue(row, index);
		}
	}
}
