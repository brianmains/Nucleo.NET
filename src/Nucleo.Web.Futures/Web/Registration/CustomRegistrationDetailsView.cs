using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.EventArguments;
using Nucleo.Web.Registration;
using Nucleo.Web.DataFields;
using Nucleo.Registration;
using Nucleo.Registration.Configuration;
using Nucleo.Reflection;


namespace Nucleo.Web.Registration
{
	public class CustomRegistrationDetailsView : CompositeDataBoundControl
	{
		private CustomRegistrationDetailsViewItemCollection _items = null;



		#region " Enumerations "

		public enum ViewMode
		{
			/// <summary>
			/// Readonly mode for the item.
			/// </summary>
			View,
			/// <summary>
			/// Insertion mode for a new item.
			/// </summary>
			Insert,
			/// <summary>
			/// Editing mode, which means editing existing information.
			/// </summary>
			Edit,
			/// <summary>
			/// Determines whether the key value is null; if null, render in insert mode.  Otherwise, render in edit mode.
			/// </summary>
			EditOrInsert
		}

		#endregion



		#region " Events "

		public event Nucleo.EventArguments.PropertyChangedEventHandler KeyValueChanged;

		public event EventHandler KeyValueNullStatusChanged;

		/// <summary>
		/// Fired whenever the mode changes within the control.
		/// </summary>
		public event EventHandler ModeChanged;

		/// <summary>
		/// Fired whenever the mode is starting to change.
		/// </summary>
		public event CustomRegistrationDetailsViewModeEventHandler ModeChanging;

		public event Nucleo.EventArguments.PropertyChangedEventHandler PropertyValueChanged;

		public event CancelEventHandler PropertyValueChanging;

		#endregion



		#region " Properties "

		/// <summary>
		/// The name of the configuration to use within the custom registration API.
		/// </summary>
		public string ConfigurationName
		{
			get
			{
				object o = ViewState["ConfigurationName"];
				return (o == null) ? string.Empty : (string)o;
			}
			set { ViewState["ConfigurationName"] = value; }
		}

		/// <summary>
		/// The current mode being displayed in.
		/// </summary>
		public ViewMode CurrentMode
		{
			get
			{
				object o = ViewState["CurrentMode"];
				return (o == null) ? ViewMode.View : (ViewMode)o;
			}
		}

		new private object DataSource
		{
			get { throw new InvalidOperationException(); }
		}

		new private string DataSourceID
		{
			get { throw new InvalidOperationException(); }
		}

		/// <summary>
		/// The collection of items.
		/// </summary>
		public CustomRegistrationDetailsViewItemCollection Items
		{
			get
			{
				if (_items == null)
					_items = new CustomRegistrationDetailsViewItemCollection();

				return _items;
			}
		}

		/// <summary>
		/// The key value to use when retrieving code.
		/// </summary>
		public object KeyFieldValue
		{
			get { return ViewState["KeyFieldValue"]; }
			set { ViewState["KeyFieldValue"] = value; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Changes the mode to an alternative mode.
		/// </summary>
		/// <param name="mode">The mode to change to.</param>
		public void ChangeMode(ViewMode mode)
		{
			bool changing = false;
			ViewMode oldMode = this.CurrentMode;

			if (ViewState["CurrentMode"] == null)
			{
				changing = true;
			}
			if (!changing && !ViewState["CurrentMode"].Equals(mode))
			{
				changing = true;
				oldMode = (ViewMode)ViewState["CurrentMode"];
			}

			if (changing)
			{
				CustomRegistrationDetailsViewModeEventArgs args = new CustomRegistrationDetailsViewModeEventArgs(oldMode, mode);
				this.OnModeChanging(args);

				if (!args.Cancel)
					ViewState["CurrentMode"] = mode;
			}

			if (mode == ViewMode.View)
			{
				if (this.KeyFieldValue == null)
					throw new Exception("The key needs to be provided when changing modes to view mode");
			}
		}

		/// <summary>
		/// Creates the table structure within the system.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown if the <see cref="ConfigurationName">ConfigurationName property</see> is null or if the configuration doesn't exist.</exception>
		protected override void CreateChildControls()
		{
			//if (string.IsNullOrEmpty(this.ConfigurationName))
			//    throw new ArgumentNullException("ConfigurationName");
			//CustomRegistrationSetupElement setupElement = CustomRegistrationSetupSection.Instance.Setups[this.ConfigurationName];
			//if (setupElement == null)
			//    throw new ArgumentNullException("The configuration could not be found in the configuration file");

			//this.Controls.Clear();
			//Table table = new Table();
			//this.Controls.Add(table);
			////Add an empty header row, so the header is rendered
			//table.Rows.Add(new TableHeaderRow());

			//CustomRegistration registration = this.GetRegistration();
			////Create the label and the UI control for each property
			//foreach (CustomRegistrationPropertyElement prop in setupElement.PropertyFields)
			//{
			//    CustomRegistrationDetailsViewItem item = this.CreateItem(table, prop);
			//    this.Items.Add(item);
			//}

			
		}

		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		/// <summary>
		/// Creates the control that will edit or insert the value.
		/// </summary>
		/// <param name="parentCell">The parent cell for the control adding the values to.</param>
		/// <param name="property">The property to edit or insert.</param>
		protected virtual void CreateEditingControl(TableCell parentCell, CustomRegistrationPropertyElement property, object propertyValue)
		{
			bool skipMinimumLengthCheck = false;

			//if (TypeUtility.IsNumericType(property.Type))
			//    this.CreateNumericEditor(parentCell, property);
			//else if (TypeUtility.IsEnumeratedType(property.Type))
			//    this.CreateEnumeratedEditor(parentCell, property);
			//else
			//    this.CreateStandardEditor(parentCell, property);

			if (property.IsRequired)
			{
				RequiredFieldValidator validator = new RequiredFieldValidator();
				parentCell.Controls.Add(validator);
				validator.ControlToValidate = parentCell.Controls[0].ID;
				validator.ErrorMessage = string.Format("The '{0}' field is required.", property.Name);
			}

			if (!skipMinimumLengthCheck && property.MinimumLength > 0)
			{
				RegularExpressionValidator revMinimumLength = new RegularExpressionValidator();
				parentCell.Controls.Add(revMinimumLength);
				revMinimumLength.ControlToValidate = parentCell.Controls[0].ID;
				revMinimumLength.ErrorMessage = string.Format("The value must be between {0} and {1} characters long.", property.MinimumLength, property.MaximumLength);
				revMinimumLength.ValidationExpression = string.Format(".{{{0}, {1}}}", property.MinimumLength, property.MaximumLength);
			}

			if (TypeUtility.IsNumericType(property.Type))
			{
				RegularExpressionValidator revNumericType = new RegularExpressionValidator();
				parentCell.Controls.Add(revNumericType);
				revNumericType.ControlToValidate = parentCell.Controls[0].ID;
				revNumericType.ErrorMessage = "The value provided must be numeric";
				revNumericType.ValidationExpression = @"\d+";
			}
		}

		/// <summary>
		/// Creates an editor that works with enumerated values.
		/// </summary>
		/// <param name="parentCell">The cell that contains the editor.</param>
		/// <param name="property">The property definition for the enumerated type.</param>
		protected virtual void CreateEnumeratedEditor(TableCell parentCell, CustomRegistrationPropertyElement property, object propertyValue)
		{
			DropDownList editControl = new DropDownList();
			parentCell.Controls.Add(editControl);

			Array enumValues = Enum.GetValues(Type.GetType(property.Type));
			foreach (object enumValue in enumValues)
				editControl.Items.Add(enumValue.ToString());
			editControl.SelectedValue = this.GetPropertyValueAsString(property, propertyValue);
		}

		/// <summary>
		/// Create a new item based on the properties defined.
		/// </summary>
		/// <param name="table">The parent table that contains the control structure.</param>
		/// <returns>A new instance of the row.</returns>
		/// <remarks>The row is added to the table after instantiation.</remarks>
		protected virtual CustomRegistrationDetailsViewItem CreateItem(Table table, CustomRegistrationPropertyElement property, object propertyValue)
		{
			CustomRegistrationDetailsViewItem item = new CustomRegistrationDetailsViewItem(property);
			table.Rows.Add(item);

			item.Cells.Add(new TableCell());
			item.Cells.Add(new TableCell());

			Label header = new Label();
			item.Cells[0].Controls.Add(header);
			header.Text = property.Name;

			if (this.CurrentMode == ViewMode.View)
			{
				Label value = new Label();
				item.Cells[1].Controls.Add(value);
				header.AssociatedControlID = value.ID;
				value.Text = this.GetPropertyValueAsString(property, propertyValue);
			}
			else
			{
				this.CreateEditingControl(item.Cells[1], property, propertyValue);
				header.AssociatedControlID = item.Cells[1].Controls[0].ID;
			}

			return item;
		}

		/// <summary>
		/// Creates an editor that works with numeric values.
		/// </summary>
		/// <param name="parentCell">The cell that contains the editor.</param>
		/// <param name="property">The property definition for the enumerated type.</param>
		protected virtual void CreateNumericEditor(TableCell parentCell, CustomRegistrationPropertyElement property, object propertyValue)
		{
			TextBox editControl = new TextBox();
			parentCell.Controls.Add(editControl);
			if (property.MaximumLength > 0)
				editControl.MaxLength = property.MaximumLength;
			editControl.Text = this.GetPropertyValueAsString(property, propertyValue);
		}

		/// <summary>
		/// Creates an editor that works with any value.
		/// </summary>
		/// <param name="parentCell">The cell that contains the editor.</param>
		/// <param name="property">The property definition for the enumerated type.</param>
		protected virtual void CreateStandardEditor(TableCell parentCell, CustomRegistrationPropertyElement property, object propertyValue)
		{
			TextBox editControl = new TextBox();
			parentCell.Controls.Add(editControl);
			if (property.MaximumLength > 0)
				editControl.MaxLength = property.MaximumLength;
			editControl.Text = this.GetPropertyValueAsString(property, propertyValue);
		}

		private string GetPropertyValueAsString(CustomRegistrationPropertyElement property, object propertyValue)
		{
			if (propertyValue == null)
				return string.Empty;
			else if (TypeUtility.IsValueType(property.Type))
				return propertyValue.ToString();
			else
				return string.Empty;
		}

		private CustomRegistration GetRegistration()
		{
			if (this.KeyFieldValue != null)
				return CustomRegistrationManager.GetRegistration(this.KeyFieldValue);
			else
				return CustomRegistrationManager.CreateNewRegistration();
		}

		private void HandleCommand(CommandEventArgs e)
		{
			if (string.Compare(e.CommandName, "edit", true) == 0)
				this.HandleEdit(e);
			else if (string.Compare(e.CommandName, "insert", true) == 0)
				this.HandleInsert(e);
			else if (string.Compare(e.CommandName, "delete", true) == 0)
				this.HandleDelete(e);
		}

		private void HandleDelete(CommandEventArgs e)
		{
			
		}

		private void HandleEdit(CommandEventArgs e)
		{

		}

		private void HandleInsert(CommandEventArgs e)
		{

		}

		protected override void OnInit(EventArgs e)
		{
			if (string.IsNullOrEmpty(this.ConfigurationName))
				throw new ArgumentNullException("ConfigurationName");
			CustomRegistrationManager.ChangeConfiguration(this.ConfigurationName);

			base.OnInit(e);
		}

		protected virtual void OnKeyValueChanged(Nucleo.EventArguments.PropertyChangedEventArgs e)
		{
			if (KeyValueChanged != null)
				KeyValueChanged(this, e);
		}

		protected virtual void OnKeyValueNullStatusChanged(EventArgs e)
		{
			if (KeyValueNullStatusChanged != null)
				KeyValueNullStatusChanged(this, e);
		}

		/// <summary>
		/// Loads the data based on the information provided (such as current mode, and whether a key value exists).
		/// </summary>
		/// <param name="e">Empty.</param>
		protected override void OnLoad(EventArgs e)
		{
			//TODO:Determine how to load the data

			base.OnLoad(e);
		}

		/// <summary>
		/// Raises the mode changed event.
		/// </summary>
		/// <param name="e">Empty.</param>
		protected virtual void OnModeChanged(EventArgs e)
		{
			if (ModeChanged != null)
				ModeChanged(this, e);
		}

		/// <summary>
		/// Raises the mode changing event.
		/// </summary>
		/// <param name="e">The details about the change.</param>
		protected virtual void OnModeChanging(CustomRegistrationDetailsViewModeEventArgs e)
		{
			if (ModeChanging != null)
				ModeChanging(this, e);
		}

		protected virtual void OnPropertyValueChanged(Nucleo.EventArguments.PropertyChangedEventArgs e)
		{
			if (PropertyValueChanged != null)
				PropertyValueChanged(this, e);
		}

		protected virtual void OnPropertyValueChanging(CancelEventArgs e)
		{
			if (PropertyValueChanging != null)
				PropertyValueChanging(this, e);
		}

		protected override void PerformDataBinding(System.Collections.IEnumerable data)
		{
			base.PerformDataBinding(data);
		}

		#endregion
	}
}
