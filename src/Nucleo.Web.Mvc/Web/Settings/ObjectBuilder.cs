using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Settings
{
	/// <summary>
	/// Represents a builder to instantiate an object, and assign its values.
	/// </summary>
	/// <typeparam name="TItem">The type of item to build.</typeparam>
	public class ObjectBuilder<TItem>
		where TItem: class
	{
		private TItem _object = default(TItem);



		#region " Constructors "

		/// <summary>
		/// Creates the builder.
		/// </summary>
		public ObjectBuilder() { }

		/// <summary>
		/// Creates the builder with the object instance.
		/// </summary>
		/// <param name="obj">The object to use for the builder.</param>
		public ObjectBuilder(TItem obj)
		{
			_object = obj;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Assigns the object's values.
		/// </summary>
		/// <param name="builder">The action to load the object.</param>
		/// <returns>The builder.</returns>
		public ObjectBuilder<TItem> Object(Action<TItem> builder)
		{
			if (builder == null)
				throw new ArgumentNullException("builder");

			builder(_object);
			return this;
		}

		#endregion
	}
}
