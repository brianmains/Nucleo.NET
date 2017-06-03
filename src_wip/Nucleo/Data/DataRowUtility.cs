using System;
using System.Data;
using System.Reflection;


namespace Nucleo.Data
{
	/// <summary>
	/// Represents a utility class for data rows.
	/// </summary>
	public static class DataRowUtility
	{
		/// <summary>
		/// Assigns all of the fields in the data row to the object that supports it.
		/// </summary>
		/// <param name="row">The row to extract information from.</param>
		/// <param name="businessObject">The business object to assign values to.</param>
		public static void AssignFieldsToObject(DataRow row, object businessObject)
		{
			DataColumnCollection columns = row.Table.Columns;
			Type businessObjectType = businessObject.GetType();

			foreach (DataColumn column in columns)
			{
				PropertyInfo property = businessObjectType.GetProperty(column.ColumnName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (property != null && property.CanWrite)
				{
					object value = !row.IsNull(column) ? row[column] : null;
					property.SetValue(businessObject, value, null);
				}
			}
		}

		/// <summary>
		/// Gets the appropriate database object from the object specified, meaning that it converts null values into a database null value.
		/// </summary>
		/// <param name="obj">The object to convert to the appropriate type.</param>
		/// <returns>An object that is database appropriate.</returns>
		public static object GetDatabaseValue(object obj)
		{
			if (obj is DateTime)
			{
				DateTime objDate = (DateTime)obj;
				//1753 is the lowest supported year for DateTime
				if (objDate.Year >= 1753)
					return objDate;
				else
					return DBNull.Value;
			}
			else if (obj is string)
			{
				if (obj == null || ((string)obj) == string.Empty)
					return DBNull.Value;

				return (string)obj;
			}
			else
			{
				if (obj != null)
					return obj;
				else
					return DBNull.Value;
			}
		}

		/// <summary>
		/// Gets the value of the data row's column and returns it as an object.
		/// </summary>
		/// <param name="row">The row to get the column from.</param>
		/// <param name="column">The name of the column to convert.</param>
		/// <returns>An object that represents the value from the database.</returns>
		public static object GetValue(DataRow row, string column)
		{
			if (row == null)
				throw new ArgumentNullException("row", "The row passed in is null");

			if (!row.IsNull(column))
				return row[column];
			else
				return null;
		}

		/// <summary>
		/// Gets the value of the data row's column and returns it as an object.
		/// </summary>
		/// <param name="row">The row to get the column from.</param>
		/// <param name="index">The index of the column to convert.</param>
		/// <returns>An object that represents the value from the database.</returns>
		public static object GetValue(DataRow row, int index)
		{
			if (row == null)
				throw new ArgumentNullException("row", "The row passed in is null");

			if (!row.IsNull(index))
				return row[index];
			else
				return null;
		}

		/// <summary>
		/// Gets the value of the data row's column and returns it as the specific type.
		/// </summary>
		/// <param name="row">The row to get the column from.</param>
		/// <param name="column">The name of the column to convert.</param>
		/// <returns>A typed object that represents the value from the database.</returns>
		public static T GetValueAs<T>(DataRow row, string column)
		{
			if (row == null)
				throw new ArgumentNullException("row", "The row passed in is null");

			if (!row.IsNull(column))
				return (T)row[column];
			else
				return default(T);
		}

		/// <summary>
		/// Gets the value of the data row's column and returns it as the specific type.
		/// </summary>
		/// <param name="row">The row to get the column from.</param>
		/// <param name="index">The index of the column to convert.</param>
		/// <returns>A typed object that represents the value from the database.</returns>
		public static T GetValueAs<T>(DataRow row, int index)
		{
			if (row == null)
				throw new ArgumentNullException("row", "The row passed in is null");

			if (!row.IsNull(index))
				return (T)row[index];
			else
				return default(T);
		}

		/// <summary>
		/// Gets the value of the data row's column and returns it as a string.
		/// </summary>
		/// <param name="row">The row to get the column from.</param>
		/// <param name="column">The name of the column to convert.</param>
		/// <returns>A string that represents the value from the database.</returns>
		public static string GetValueAsString(DataRow row, string column)
		{
			if (row == null)
				throw new ArgumentNullException("row", "The row passed in is null");

			if (!row.IsNull(column))
				return row[column].ToString();
			else
				return null;
		}

		/// <summary>
		/// Gets the value of the data row's column and returns it as a string.
		/// </summary>
		/// <param name="row">The row to get the column from.</param>
		/// <param name="index">The index of the column to convert.</param>
		/// <returns>A string that represents the value from the database.</returns>
		public static string GetValueAsString(DataRow row, int index)
		{
			if (row == null)
				throw new ArgumentNullException("row", "The row passed in is null");

			if (!row.IsNull(index))
				return row[index].ToString();
			else
				return null;
		}
	}
}
