using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Nucleo.Web.DataFields
{
	/// <summary>
	/// Provides a primitive set of functions when working with custom data control fields.
	/// </summary>
	public abstract class BasePrimitiveDataField : DataControlField
	{
		private bool _insertMode = false;



		#region " Properties "

		/// <summary>
		/// Gets whether the data field is in insert mode.
		/// </summary>
		[
		Browsable(false)
		]
		protected bool InsertMode
		{
			get { return _insertMode; }
		}

		/// <summary>
		/// Gets or sets whether the data field should be read-only.
		/// </summary>
		[
		DefaultValue(false)
		]
		public bool ReadOnly
		{
			get
			{
				object o = ViewState["ReadOnly"];
				return (o == null) ? false : (bool)o;
			}
			set { ViewState["ReadOnly"] = value; }
		}
		
		#endregion



		#region " Methods "

		/// <summary>
		/// Adds or inserts a dictionary entry for the data field/value.
		/// </summary>
		/// <param name="dictionary">The dictionary of items.</param>
		/// <param name="dataField">The name of the data field.</param>
		/// <param name="value"></param>
		protected virtual void AddDictionaryEntry(System.Collections.Specialized.IOrderedDictionary dictionary, string dataField, object value)
		{
			if (dictionary == null)
				throw new ArgumentNullException("dictionary");
			if (string.IsNullOrEmpty(dataField))
				throw new ArgumentNullException("dataField");

			if (dictionary.Contains(dataField))
				dictionary[dataField] = value;
			else
				dictionary.Add(dataField, value);
		}

		/// <summary>
		/// Returns a new instance of the derived data field.
		/// </summary>
		/// <returns></returns>
		protected override DataControlField CreateField()
		{
			return (DataControlField)Activator.CreateInstance(this.GetType());
		}

		/// <summary>
		/// Loops through all of the controls in the cell and returns the first control of the specified type.
		/// </summary>
		/// <typeparam name="T">The type to use to retrieve a specific control reference.</typeparam>
		/// <param name="cell">The cell to use.</param>
		/// <returns>An instance of a control, or null if not found.</returns>
		protected T ExtractControl<T>(TableCell cell) where T:Control
		{
			if (cell == null)
				throw new ArgumentNullException("cell");

			foreach (Control control in cell.Controls)
			{
				if (control is T)
					return (T)control;
			}

			return null;
		}

		/// <summary>
		/// Extracts the control from the cell, at the specified cell index.
		/// </summary>
		/// <typeparam name="T">The type of control that is being dealt with.</typeparam>
		/// <param name="cell">The cell to use to extract a control.</param>
		/// <param name="controlIndex">The index of the control.</param>
		/// <returns>An instance of the control that was found at the cell index, converted to the appropriate type.</returns>
		protected T ExtractControl<T>(TableCell cell, int controlIndex) where T : Control
		{
			if (cell == null)
				throw new ArgumentNullException("cell");
			if (controlIndex < 0 || controlIndex >= cell.Controls.Count)
				throw new ArgumentOutOfRangeException("index", Errors.OUT_OF_RANGE);

			Control control = cell.Controls[controlIndex];
			if (control == null)
				throw new InvalidOperationException(Errors.CANT_EXTRACT_CONTROL_IN_CELL);

			return (T)control;
		}

		/// <summary>
		/// Determines whether the row is in insert mode.
		/// </summary>
		/// <param name="dictionary">The dictionary of items.</param>
		/// <param name="cell">The cell currently being processed.</param>
		/// <param name="rowState">The current state of the row.</param>
		/// <param name="includeReadOnly">Whether to include read only fields.</param>
		public override void ExtractValuesFromCell(System.Collections.Specialized.IOrderedDictionary dictionary, DataControlFieldCell cell, DataControlRowState rowState, bool includeReadOnly)
		{
			base.ExtractValuesFromCell(dictionary, cell, rowState, includeReadOnly);
			_insertMode = (rowState == DataControlRowState.Insert);
		}

		/// <summary>
		/// Gets an instance of the property 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="container"></param>
		/// <param name="property"></param>
		/// <returns></returns>
		protected T GetDataItemValue<T>(object container, string propertyName)
		{
			object value = this.GetDataItemValue(container, propertyName);

			if (value == null || DBNull.Value.Equals(value))
				return default(T);
			else
				return (T)value;
		}

		protected object GetDataItemValue(object container, string propertyName)
		{
			if (container == null || this.DesignMode)
				return null;
			if (string.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException("propertyName");

			//Get the data item from the container
			object dataItem = DataBinder.GetDataItem(container);
			if (dataItem == null) return null;
			object value = null;

			//TODO:Not quite working yet; figure chaining solution
			if (!propertyName.Contains("."))
				//Get the value from the data item
				value = DataBinder.GetPropertyValue(dataItem, propertyName);
			else
			{
				value = dataItem;
				string[] propertyList = propertyName.Split('.');

				foreach (string propertyItem in propertyList)
				{
					value = DataBinder.GetPropertyValue(value, propertyItem);
					if (value == null) return null;
				}
			}

			return value;
		}

		/// <summary>
		/// Determines if the row state is insert or edit (read-only is left out in this situation).
		/// </summary>
		/// <param name="insertMode">Whether the control is in insert mode.</param>
		/// <returns>The current state of the control (edit or insert).</returns>
		protected DataControlRowState GetEditRowState(bool insertMode)
		{
			if (insertMode)
				return DataControlRowState.Insert;
			else
				return DataControlRowState.Edit;
		}

		/// <summary>
		/// Gets the value of the data item in read-only form.
		/// </summary>
		/// <param name="cell">The cell to use to retrieve data items with, or inner cell values from.</param>
		/// <param name="initialValue">The value that is the initial value to be set in the cell.</param>
		/// <returns>The value that is displayed in the table cell.</returns>
		protected virtual string GetReadOnlyValue(TableCell cell, object initialValue)
		{
			if (initialValue != null)
				return initialValue.ToString();
			else
				return null;
		}

		/// <summary>
		/// Determines whether the cell's inner text is empty, or whether the control count is zero.
		/// </summary>
		/// <param name="cell">The cell to compare.</param>
		/// <returns>Whether the cell's inner text is empty.</returns>
		public static bool IsEmptyCell(TableCell cell)
		{
			if (!IsEmptyCellText(cell))
				return false;

			return (cell.Controls.Count == 0);
		}

		/// <summary>
		/// Determines whether the cell's inner text is empty.
		/// </summary>
		/// <param name="cell">The cell to compare.</param>
		/// <returns>Whether the cell's inner text is empty.</returns>
		public static bool IsEmptyCellText(TableCell cell)
		{
			return (string.IsNullOrEmpty(cell.Text) || (string.Compare(cell.Text, "&nbsp;", true) == 0));
		}

		protected bool IsReadMode(DataControlRowState rowState)
		{
			return (this.ReadOnly || rowState == DataControlRowState.Normal || rowState == DataControlRowState.Alternate || rowState == DataControlRowState.Selected);
		}

		#endregion
	}
}
