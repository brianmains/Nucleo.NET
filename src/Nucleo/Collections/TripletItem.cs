using System;
using System.Collections.Generic;


namespace Nucleo.Collections
{
	public class TripletItem<TKey, TValue1, TValue2>
	{
		private TKey _key = default(TKey);
		private TValue1 _value1 = default(TValue1);
		private TValue2 _value2 = default(TValue2);



		#region " Properties "

		/// <summary>
		/// Gets the key of the key/value/value pairing.
		/// </summary>
		public TKey Key
		{
			get { return _key; }
		}

		/// <summary>
		/// Gets or sets the first value of the pairing.
		/// </summary>
		public TValue1 Value1
		{
			get { return _value1; }
			set { _value1 = value; }
		}

		/// <summary>
		/// Gets or sets the second value of the pairing.
		/// </summary>
		public TValue2 Value2
		{
			get { return _value2; }
			set { _value2 = value; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Constructs the triplet item; assigns the parameters to the local values.
		/// </summary>
		/// <param name="key">The key of the key/value/value pairing</param>
		/// <param name="value1">The first value of the pairing.</param>
		/// <param name="value2">The second value of the pairing.</param>
		public TripletItem(TKey key, TValue1 value1, TValue2 value2)
		{
			_key = key;
			_value1 = value1;
			_value2 = value2;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets a key/value pair out of the values.
		/// </summary>
		/// <returns>A key/value pairing, using the first value as the key and the second value as the value.</returns>
		public KeyValuePair<TValue1, TValue2> GetValues()
		{
			return new KeyValuePair<TValue1, TValue2>(this.Value1, this.Value2);
		}

		#endregion
	}
}
