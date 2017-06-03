using System;
using System.Web.UI;


namespace Nucleo.Web.FormControls
{
	/// <summary>
	/// Represents the collection of <see cref="FormItemDisplay"/> controls.
	/// </summary>
	public class FormItemCollection : ControlCollection
	{
		#region " Constructors "

		public FormItemCollection(Control owner)
			: base(owner) { }

		#endregion



		#region " Methods "

		public override void Add(Control child)
		{
			if (!(child is IFormItem))
				throw new InvalidCastException();

			base.Add(child);
		}

		public override void AddAt(int index, Control child)
		{
			if (!(child is IFormItem))
				throw new InvalidCastException();

			base.AddAt(index, child);
		}

		#endregion
	}
}
