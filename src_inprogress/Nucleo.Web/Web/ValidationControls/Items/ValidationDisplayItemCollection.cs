using System;
using System.Web.UI;


namespace Nucleo.Web.ValidationControls.Items
{
	/// <summary>
	/// Gets the collection of display items.
	/// </summary>
	public class ValidationDisplayItemCollection : ControlCollection
	{
		#region " Constructors "

		public ValidationDisplayItemCollection(Control owner)
			: base(owner) { }

		#endregion



		#region " Methods "

		public override void Add(Control child)
		{
			if (!(child is IValidationDisplayItem))
				throw new InvalidCastException("Control is not an IValidationDisplayItem");

			base.Add(child);
		}

		public override void AddAt(int index, Control child)
		{
			if (!(child is IValidationDisplayItem))
				throw new InvalidCastException("Control is not an IValidationDisplayItem");

			base.AddAt(index, child);
		}

		#endregion
	}
}
