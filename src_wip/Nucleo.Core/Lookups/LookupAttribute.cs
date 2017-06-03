using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.Lookups
{
	/// <summary>
	/// Represents an attribute to specify that a certain operation can be associated with an attribute.
	/// </summary>
	/// <example>
	/// [Lookup("Test")]
	/// public void LoadData(LookupCollection values) { .. }
	/// </example>
	[AttributeUsage(AttributeTargets.All)]
	public class LookupAttribute : Attribute
	{
		private string _lookupName = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the lookup to bind values to.
		/// </summary>
		public string LookupName
		{
			get { return _lookupName; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the lookup attribute with the specified lookup name.
		/// </summary>
		/// <param name="lookupName">The name of the lookup.</param>
		public LookupAttribute(string lookupName)
		{
			_lookupName = lookupName;
		}

		#endregion
	}
}
