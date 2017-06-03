using System;


namespace Nucleo.Models.Lookups
{
	/// <summary>
	/// Represents an attribute that marks the lookup of a specific value.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class LookupInjectionAttribute : Attribute, ILookupInjection
	{
		private string _lookupName = null;



		#region " Properties "

		/// <summary>
		/// Gets the name of the lookup.
		/// </summary>
		public string LookupName
		{
			get { return _lookupName; }
		}

		#endregion



		#region " Classes "

		public LookupInjectionAttribute(string lookupName)
		{
			_lookupName = lookupName;
		}

		#endregion
	}
}
