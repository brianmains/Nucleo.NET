using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventArguments
{
	/// <summary>
	/// Represents that a property of an object has changed.
	/// </summary>
	public class ObjectPropertyChangedEventArgs : PropertyChangedEventArgs
	{
		private object _instance = null;



		#region " Properties "

		/// <summary>
		/// Gets the instance for the object where the property is related to.
		/// </summary>
		public object Instance
		{
			get { return _instance; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Assigns the property values to the local fields.
		/// </summary>
		/// <param name="instance">The instance object.</param>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="oldValue">The old value for the object property.</param>
		/// <param name="newValue">The new value for the object property.</param>
		public ObjectPropertyChangedEventArgs(object instance, string propertyName, object oldValue, object newValue)
			: base(propertyName, oldValue, newValue)
		{
			_instance = instance;
		}

		#endregion
	}


	public delegate void ObjectPropertyChangedEventHandler(object sender, ObjectPropertyChangedEventArgs e);
}
