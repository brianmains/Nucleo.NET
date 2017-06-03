using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;


namespace Nucleo.Web.DataFields
{
	public abstract class BaseSingleDataField : BasePrimitiveDataField
	{
		#region " Methods "

		/// <summary>
		/// Adds an entry to the dictionary, based on the cell and data field.
		/// </summary>
		/// <param name="dictionary">The dictionary of items.</param>
		/// <param name="cell">The cell that contains a control value.</param>
		/// <param name="rowState">The current state of the row.</param>
		/// <param name="dataField">The name of the field to get data from.</param>
		protected virtual void AddDictionaryEntry(IOrderedDictionary dictionary, TableCell cell, DataControlRowState rowState, string dataField)
		{
			string value = null;

			if (cell.Controls.Count > 0)
				value = this.GetEditControlValue(cell);

			this.AddDictionaryEntry(dictionary, dataField, value);
		}

		/// <summary>
		/// Binds the editing control with the underlying data source value.
		/// </summary>
		/// <param name="control">The control to bind to.</param>
		/// <param name="insertMode">Whether the control is in insert mode.</param>
		/// <remarks>In this method, you may often use the <see cref="GetDataItemValue" /> method of the base class, the <see cref="GetDataItemFieldName" /> abstract method in this class, and the <see cref="GetEditRowState" /> method of the base class, in order to get the correct values.</remarks>
		/// <example>
		///	//In this example, this method uses the three methods defined in the remarks section to assign a value to the control:
		///	NumericTextBox box = (NumericTextBox)control;
		/// if (!insertMode)
		/// 	box.Value = this.GetDataItemValue&lt;double&gt;(box.NamingContainer, this.GetDataItemFieldName(this.GetEditRowState(insertMode))).ToString();
		/// </example>
		public abstract void BindEditControl(object control, bool insertMode);

		/// <summary>
		/// Extracts the value from the cell, and updates the dictionary with the new value.
		/// </summary>
		/// <param name="dictionary">The dictionary of values.</param>
		/// <param name="cell">The type of cell currently being rendered.</param>
		/// <param name="rowState">The current state of the row (readonly, edit, and insert).</param>
		/// <param name="includeReadOnly">Whether to include read-only fields as well.</param>
		public override void ExtractValuesFromCell(IOrderedDictionary dictionary, DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly)
		{
			base.ExtractValuesFromCell(dictionary, cell, rowState, includeReadOnly);
			this.AddDictionaryEntry(dictionary, cell, rowState, this.GetDataItemFieldName(rowState));
		}

		/// <summary>
		/// Get the name of the field that is in the data source.
		/// </summary>
		/// <returns>The name of the data item field.</returns>
		protected abstract string GetDataItemFieldName(DataControlRowState state);

		/// <summary>
		/// Gets the value extracted from the edited control.
		/// </summary>
		/// <param name="cell">The cell to extract the edited control value from.</param>
		/// <returns></returns>
		public abstract string GetEditControlValue(TableCell cell);

		/// <summary>
		/// Initializes the cell by loading the appropriate control into it, depending on the mode.
		/// </summary>
		/// <param name="cell">The cell to initialize.</param>
		/// <param name="cellType">The type of cell that is currently being initialized.</param>
		/// <param name="rowState">The current state of the row.</param>
		/// <param name="rowIndex">The index of the row being processed.</param>
		public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
		{
			base.InitializeCell(cell, cellType, rowState, rowIndex);
			Control control = null;

			if (cellType == DataControlCellType.DataCell)
			{
				if (this.IsReadMode(rowState))
					control = cell;
				else
				{
					cell.Controls.Add(this.SetupEditControl());

					if (!string.IsNullOrEmpty(this.GetDataItemFieldName(rowState)))
						control = cell.Controls[0];
				}

				if (control != null && this.Visible)
					control.DataBinding += new EventHandler(control_DataBinding);
			}
		}

		/// <summary>
		/// Returns an instance of the control that will edit the data.
		/// </summary>
		/// <returns>An instance of the control.</returns>
		public abstract Control SetupEditControl();

		#endregion



		#region " Event Handlers "

		/// <summary>
		/// Attaches to the data binding of the control, gets the data source, and binds it to that control.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void control_DataBinding(object sender, EventArgs e)
		{
			if (sender is TableCell)
			{
				TableCell cell = sender as TableCell;
				cell.Text = this.GetReadOnlyValue(cell, this.GetDataItemValue(cell.NamingContainer, this.GetDataItemFieldName(DataControlRowState.Normal)));
			}
			else
				this.BindEditControl(sender, this.InsertMode);
		}

		#endregion
	}
}
