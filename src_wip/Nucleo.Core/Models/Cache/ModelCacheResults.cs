using System;
using System.Collections.Generic;


namespace Nucleo.Models.Cache
{
	/// <summary>
	/// Represents the results interpreted from the model cache.
	/// </summary>
	public class ModelCacheResults
	{
		private bool _hasValue = false;
		private object _value = null;



		#region " Properties "

		/// <summary>
		/// Gets whether the model cache has the requested value.
		/// </summary>
		public bool HasValue
		{
			get { return _hasValue; }
		}

		/// <summary>
		/// Gets the value of the cached entry.
		/// </summary>
		public object Value
		{
			get { return _value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the cached results.
		/// </summary>
		/// <param name="hasValue">Whether the results has a value.</param>
		/// <param name="value">The underlying value.</param>
		public ModelCacheResults(bool hasValue, object value)
		{
			_hasValue = hasValue;
			_value = value;
		}

		#endregion
	}
}
