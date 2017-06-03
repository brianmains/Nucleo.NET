using System;
using System.Data;
using System.Collections.Generic;


namespace Nucleo.Data
{
	/// <summary>
	/// Represents a utility for data tables.
	/// </summary>
	public static class DataTableUtility
	{
		public static T[] GetColumnAsArrayOf<T>(DataTable table)
		{
			return GetColumnAsArrayOf<T>(table, 0);
		}

		public static T[] GetColumnAsArrayOf<T>(DataTable table, int columnIndex)
		{
			return GetColumnAsArrayOf<T>(table, columnIndex, true);
		}

		public static T[] GetColumnAsArrayOf<T>(DataTable table, int columnIndex, bool includeEmptyValues)
		{
			if (table == null)
				throw new ArgumentNullException("table");
			if (columnIndex < 0 || columnIndex > table.Columns.Count)
				throw new ArgumentOutOfRangeException("columnIndex");

			List<T> items = new List<T>();
			foreach (DataRow row in table.Rows)
			{
				if (!row.IsNull(columnIndex))
					items.Add((T)row[columnIndex]);
				else
				{
					if (includeEmptyValues)
						items.Add(default(T));
				}
			}

			return items.ToArray();
		}

		public static T[] GetColumnAsArrayOf<T>(DataTable table, string columnName)
		{
			return GetColumnAsArrayOf<T>(table, columnName, true);
		}

		public static T[] GetColumnAsArrayOf<T>(DataTable table, string columnName, bool includeEmptyValues)
		{
			if (table == null)
				throw new ArgumentNullException("table");
			if (!table.Columns.Contains(columnName))
				throw new ArgumentException(string.Format("Column '{0}' does not exist", columnName), "columnName");

			List<T> items = new List<T>();
			foreach (DataRow row in table.Rows)
			{
				if (!row.IsNull(columnName))
					items.Add((T)row[columnName]);
				else
				{
					if (includeEmptyValues)
						items.Add(default(T));
				}
			}

			return items.ToArray();
		}

		public static int GetNullColumnCount(DataTable table, string columnName)
		{
			int count = 0;

			foreach (DataRow row in table.Rows)
			{
				if (row.IsNull(columnName))
					count++;
			}

			return count;
		}

		public static string[] GetRowErrorInformation(DataTable table)
		{
			if (!table.HasErrors)
				return new string[] { };
			List<string> errors = new List<string>();

			foreach (DataRow row in table.GetErrors())
			{
				DataColumn[] columns = row.GetColumnsInError();
				foreach (DataColumn column in columns)
					errors.Add(row.GetColumnError(column));
			}

			return errors.ToArray();
		}

		public static string[] GetRowErrorInformation(DataTable table, string pkColumnName)
		{
			if (!table.HasErrors)
				return new string[] { };
			if (!table.Columns.Contains(pkColumnName))
				throw new ArgumentException(string.Format("Column {0} doesn't exist", pkColumnName));
			List<string> errors = new List<string>();

			foreach (DataRow row in table.GetErrors())
			{
				string errorMsg = string.Empty;
				if (!row.IsNull(pkColumnName))
					errorMsg += row[pkColumnName].ToString();
				else
					errorMsg += "<NULL>";

				DataColumn[] columns = row.GetColumnsInError();
				string columnNames = string.Empty;

				for (int i = 0; i < columns.Length; i++)
				{
					if (i != 0) columnNames += ", ";
					columnNames += columns[i].ColumnName;
				}
			}

			return errors.ToArray();
		}
	}
}
