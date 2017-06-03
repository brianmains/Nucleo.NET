using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents the lookup.
	/// </summary>
	public class Lookup : ILookup
	{
		private string _name = null;
		private object _representationCode = null;
		private string _value = null;


		#region " Properties "

		/// <summary>
		/// Gets or sets the name of the lookup.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// Gets or sets the representation code of the lookup.
		/// </summary>
		public object RepresentationCode
		{
			get { return _representationCode; }
			set { _representationCode = value; }
		}

		/// <summary>
		/// Gets or sets the value of the lookup.
		/// </summary>
		public string Value
		{
			get { return _value; }
			set { _value = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the lookup with no values.
		/// </summary>
		public Lookup() { }

		/// <summary>
		/// Creates the lookup with values.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		/// <param name="representationCode">The code value that represents the lookup entry.</param>
		public Lookup(string name, string value, object representationCode)
		{
			_name = name;
			_value = value;
			_representationCode = representationCode;
		}

		#endregion
	}
}
