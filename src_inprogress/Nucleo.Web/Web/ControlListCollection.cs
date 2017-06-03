using System;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a control collection that's generically typed to ensure the correct type of control is allowed.  The type can be the base class or the actual class type.
	/// </summary>
	/// <typeparam name="T">The type of control to allow into the collection.</typeparam>
	public class ControlListCollection<T> : ControlCollection
		where T: Control
	{
		#region " Constructors "

		public ControlListCollection(Control owner)
			: base(owner) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds a control to the collection.  If the control isn't of the generic type, an exception is thrown.
		/// </summary>
		/// <param name="child">The control to add.</param>
		public override void Add(Control child)
		{
			if (!(child is T))
				throw new InvalidCastException("The control is not of the type: " + typeof(T).Name);

			base.Add(child);
		}

		/// <summary>
		/// Adds a control to the collection at a specific index.  If the control isn't of the generic type, an exception is thrown.
		/// </summary>
		/// <param name="child">The control to add.</param>
		public override void AddAt(int index, Control child)
		{
			if (!(child is T))
				throw new InvalidCastException("The control is not of the type: " + typeof(T).Name);

			base.AddAt(index, child);
		}

		#endregion
	}
}
