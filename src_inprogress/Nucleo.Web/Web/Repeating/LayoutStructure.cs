using System;
using System.Collections.Generic;


using Nucleo.Collections;


namespace Nucleo.Web.Repeating
{
	public class LayoutStructure
	{
		private SimpleCollection<LayoutRow> _rows = null;



		#region " Properties "

		private SimpleCollection<LayoutRow> Rows
		{
			get
			{
				if (_rows == null)
					_rows = new SimpleCollection<LayoutRow>();
				return _rows;
			}
		}

		/// <summary>
		/// Gets the total number of rows in the list.
		/// </summary>
		public int RowCount
		{
			get { return this.Rows.Count; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Appends the item to a row and appends the row to the structure.
		/// </summary>
		/// <param name="items">The items to append.</param>
		public void AppendRow(LayoutItem[] items)
		{
			LayoutRow row = new LayoutRow();
			foreach (LayoutItem item in items)
				row.Items.Add(item);

			this.Rows.Add(row);
		}

		/// <summary>
		/// Gets the row at the specified index.
		/// </summary>
		/// <param name="index">The index to look at.</param>
		/// <returns>The row at the specified index.</returns>
		public LayoutRow GetRow(int index)
		{
			return this.Rows[index];
		}

		/// <summary>
		/// Gets the collection of rows in enumerable form.
		/// </summary>
		/// <returns>The list of enumerated rows.</returns>
		public IEnumerable<LayoutRow> GetRows()
		{
			return this.Rows;
		}

		#endregion
	}
}
