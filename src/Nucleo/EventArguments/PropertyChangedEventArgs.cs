using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.EventArguments
{
	/// <summary>
	/// Event args that notes when property values are changed within any object.
	/// </summary>
	public class PropertyChangedEventArgs
	{
		private object _newValue;
		private object _oldValue;
		private string _propertyName;



		#region " Properties "

		/// <summary>
		/// The new value for the object property.
		/// </summary>
		public object NewValue
		{
			get { return _newValue; }
		}

		/// <summary>
		/// The old value for the object property.
		/// </summary>
		public object OldValue
		{
			get { return _oldValue; }
		}

		/// <summary>
		/// The name of the property.
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Assigns the property values to the local fields.
		/// </summary>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="oldValue">The old value for the object property.</param>
		/// <param name="newValue">The new value for the object property.</param>
		public PropertyChangedEventArgs(string propertyName, object oldValue, object newValue)
		{
			_propertyName = propertyName;
			_oldValue = oldValue;
			_newValue = newValue;
		}

		#endregion
	}


	public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
}
