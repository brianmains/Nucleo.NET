using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Nucleo.Registration;
using Nucleo.Registration.Configuration;


namespace Nucleo.Web.Registration
{
	public class CustomRegistrationDetailsViewItem : TableRow
	{
		private CustomRegistrationPropertyElement _property = null;



		#region " Properties "

		public CustomRegistrationPropertyElement Property
		{
			get { return _property; }
		}

		#endregion



		#region " Constructors "

		public CustomRegistrationDetailsViewItem(CustomRegistrationPropertyElement property)
		{
			_property = property;
		}

		#endregion



		#region " Methods "

		protected override void CreateChildControls()
		{
			TableCell cell = new TableCell();
			this.Cells.Add(cell);

			Label propLabel = new Label();
			cell.Controls.Add(propLabel);
			propLabel.Text = this.Property.Name;

			TextBox propEditor = new TextBox();
			cell.Controls.Add(propEditor);
			if (this.Property.MaximumLength > 0)
				propEditor.MaxLength = this.Property.MaximumLength;
			propLabel.AssociatedControlID = propEditor.ID;

			if (this.Property.IsRequired)
			{
				RequiredFieldValidator validator = new RequiredFieldValidator();
				cell.Controls.Add(validator);
				validator.ControlToValidate = propEditor.ID;
				validator.ErrorMessage = string.Format("Please enter a value for {0}.", this.Property.Name);
				validator.ToolTip = validator.ErrorMessage;
				validator.Text = "*";
			}

			if (this.Property.MinimumLength > 0)
			{
				RegularExpressionValidator validator = new RegularExpressionValidator();
				cell.Controls.Add(validator);
				validator.ControlToValidate = propEditor.ID;
				validator.ErrorMessage = string.Format("Please enter a value that is between {0} and {1} characters long.", this.Property.MinimumLength, this.Property.MaximumLength);
				validator.ToolTip = validator.ErrorMessage;
				validator.Text = "*";
				validator.ValidationExpression = string.Format(".{{{0},{1}}}", this.Property.MinimumLength, this.Property.MaximumLength);
			}
		}

		#endregion
	}
}
