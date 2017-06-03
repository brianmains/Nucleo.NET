using System;


namespace Nucleo.State
{
	/// <summary>
	/// Represents the metadata about a specific property that is used to manage state.
	/// </summary>
	public class StateProperty
	{
		private readonly object _defaultValue = null;
		private readonly StatePropertyIsolation _isolation = StatePropertyIsolation.Shared;
		private readonly string _name = null;



		#region " Operators "

		public static bool operator ==(StateProperty firstProp, StateProperty secondProp)
		{
			if (Equals(firstProp, null) && Equals(secondProp, null))
				return true;
			if (Equals(firstProp, null) || Equals(secondProp, null))
				return false;

			return (string.Compare(firstProp.Name, secondProp.Name, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		public static bool operator !=(StateProperty firstProp, StateProperty secondProp)
		{
			if (Equals(firstProp, null) && Equals(secondProp, null))
				return false;
			if (Equals(firstProp, null) || Equals(secondProp, null))
				return true;

			return (string.Compare(firstProp.Name, secondProp.Name, StringComparison.InvariantCultureIgnoreCase) != 0);
		}

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets the default value for the property.
		/// </summary>
		public object DefaultValue
		{
			get { return _defaultValue; }
		}

		public StatePropertyIsolation Isolation
		{
			get { return _isolation; }
		}

		/// <summary>
		/// Gets the name of the property.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		#endregion



		#region " Constructors "

		public StateProperty(string name, object defaultValue)
		{
			_name = name;
			_defaultValue = defaultValue;
		}

		public StateProperty(string name, StatePropertyIsolation isolation, object defaultValue)
			: this(name, defaultValue)
		{
				_isolation = isolation;
		}

		#endregion
	}
}
