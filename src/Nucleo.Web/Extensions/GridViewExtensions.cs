using System;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace System.Web.UI.WebControls
{
	public static class GridViewExtensions
	{

		/// <summary>
		/// Binds data to the grid.
		/// </summary>
		/// <param name="grid">The grid to bind.</param>
		/// <param name="data">The data to bind.</param>
		public static void BindData(this GridView grid, object data)
		{
			grid.DataSource = data;
			grid.DataBind();
		}

		/// <summary>
		/// Gets a column based on the header text.
		/// </summary>
		/// <param name="grid">The grid to extend.</param>
		/// <param name="headerText">The header text of the column.</param>
		/// <returns>An instance of the column matching the header text.</returns>
		public static DataControlField GetColumn(this GridView grid, string headerText)
		{
			foreach (DataControlField field in grid.Columns)
			{
				if (string.Compare(field.HeaderText, headerText, true) == 0)
					return field;
			}

			return null;
		}

		/// <summary>
		/// Gets a column based on the header text.
		/// </summary>
		/// <typeparam name="T">The type of the column to cast the result as (derives from DataControlField).</typeparam>
		/// <param name="grid">The grid to extend.</param>
		/// <param name="headerText">The header text of the column.</param>
		/// <returns>An instance of the column matching the header text.</returns>
		public static T GetColumn<T>(this GridView grid, string headerText)
			where T : DataControlField
		{
			var column = GetColumn(grid, headerText);

			if (column != null)
				return (T)column;
			else
				return null;
		}

		public static object GetDataKeyValue(this GridViewRow row)
		{
			GridView view = (GridView)row.Parent;
			return view.DataKeys[row.DataItemIndex].Value;
		}

		public static IOrderedDictionary GetDataKeyValues(this GridViewRow row)
		{
			GridView view = (GridView)row.Parent;
			return view.DataKeys[row.DataItemIndex].Values;
		}
	}
}
