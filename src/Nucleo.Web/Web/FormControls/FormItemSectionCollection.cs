using System;
using System.Web.UI;


namespace Nucleo.Web.FormControls
{
	/// <summary>
	/// Represents the collection of sections that appear within a form container.
	/// </summary>
	public class FormItemSectionCollection : ControlCollection
	{
		#region " Constructors "

		public FormItemSectionCollection(Control owner)
			: base(owner) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a form section to the collection; all other object types will throw an exception.
		/// </summary>
		/// <param name="child">The child section to add.</param>
		/// <exception cref="InvalidCastException">Thrown when an invalid control is being added.</exception>
		public override void Add(Control child)
		{
			if (!(child is FormItemSection))
				throw new InvalidCastException();

			base.Add(child);
		}

		/// <summary>
		/// Adds a form section to the collection at a specific index; all other object types will throw an exception.
		/// </summary>
		/// <param name="child">The child section to add.</param>
		/// <exception cref="InvalidCastException">Thrown when an invalid control is being added.</exception>
		public override void AddAt(int index, Control child)
		{
			if (!(child is FormItemSection))
				throw new InvalidCastException();

			base.AddAt(index, child);
		}

		#endregion
	}
}
