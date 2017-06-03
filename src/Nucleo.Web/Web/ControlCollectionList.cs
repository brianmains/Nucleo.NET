using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;


namespace Nucleo.Web
{
	/// <summary>
	/// Represents a list of controls, which retains the core <see cref="ControlCollection"/> functionality, but adds a type check operation and more features.
	/// </summary>
	/// <typeparam name="T">The type of control, which can be by control type or by an interface reference.  Underlying type must be of type <see cref="Control"/>.</typeparam>
	public class ControlCollectionList<T> : ControlCollection, IEnumerable<T>
	{
		#region " Constructors "

		/// <summary>
		/// Creates the list.
		/// </summary>
		/// <param name="owner">The owning control.</param>
		public ControlCollectionList(Control owner)
			: base(owner) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Adds an item to the list.
		/// </summary>
		/// <param name="child">The child to add.</param>
		/// <exception cref="InvalidOperationException">Thrown when the child is not of the correct type.</exception>
		public override void Add(Control child)
		{
			if (!(child is T))
				throw new InvalidOperationException("Cannot add a child control of the incorrect type: " + typeof(T).FullName);

			base.Add(child);
		}

		/// <summary>
		/// Adds an item at a specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="child">The child control to add.</param>
		/// <exception cref="InvalidOperationException">Thrown when the child is not of the correct type.</exception>
		public override void AddAt(int index, Control child)
		{
			if (!(child is T))
				throw new InvalidOperationException("Cannot add a child control of the incorrect type: " + typeof(T).FullName);

			base.AddAt(index, child);
		}

		public new IEnumerator<T> GetEnumerator()
		{
			return new List<T>(this.Cast<T>()).GetEnumerator();
		}

		#endregion
	}
}
