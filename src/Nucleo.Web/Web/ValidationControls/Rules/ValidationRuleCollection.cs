using System;
using System.Web.UI;


namespace Nucleo.Web.ValidationControls.Rules
{
	/// <summary>
	/// Represents the collection of validation rules.
	/// </summary>
	public class ValidationRuleCollection : ControlCollection
	{
		#region " Properties "

		/// <summary>
		/// Gets a reference to the validation rule by the index.
		/// </summary>
		/// <param name="index">The index value.</param>
		/// <returns>The validation rule.</returns>
		new public BaseValidationRule this[int index]
		{
			get { return (BaseValidationRule)base[index]; }
		}

		#endregion



		#region " Constructors "

		public ValidationRuleCollection(BaseValidator owner)
			: base(owner) { }

		#endregion



		#region " Methods "

		public override void Add(Control child)
		{
			if (!(child is IValidationRule))
				throw new InvalidOperationException("Only IValidationRule controls are supported.");

			if (child is BaseValidationRule)
				((BaseValidationRule)child).Validator = (BaseValidator)base.Owner;

			base.Add(child);
		}

		public override void AddAt(int index, Control child)
		{
			if (!(child is IValidationRule))
				throw new InvalidOperationException("Only IValidationRule controls are supported.");

			base.AddAt(index, child);

			ValidationManager.GetCurrent().AddRule((IValidationRule)child);
		}

		#endregion
	}
}
