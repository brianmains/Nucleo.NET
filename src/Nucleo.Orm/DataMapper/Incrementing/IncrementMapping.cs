using System;


namespace Nucleo.DataMapper.Incrementing
{
	/// <summary>
	/// Represents the mapping involved in the incrementing process.
	/// </summary>
	public class IncrementMapping
	{
		private int _currentValueIndex = 0;
		private string _field = null;
		private object[] _values = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the current value index.
		/// </summary>
		public int CurrentValueIndex
		{
			get { return _currentValueIndex; }
			set { _currentValueIndex = value; }
		}

		/// <summary>
		/// Gets or sets the field that's involved in the mapping.
		/// </summary>
		public string Field 
		{ 
			get { return _field; }
			set { _field = value; }
		}

		/// <summary>
		/// Gets or sets the collection of values involved in the mapping.
		/// </summary>
		public object[] Values
		{
			get { return _values; }
			set { _values = value; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the value from the mapping, if the value is within the current range.
		/// </summary>
		/// <returns>The value at the <see cref="CurrentValueIndex">CurrentValueIndex property value</see> or null if out of bounds.</returns>
		public object GetValue()
		{
			if (this.CurrentValueIndex >= this.Values.Length)
				return null;

			return this.Values[this.CurrentValueIndex];
		}

		/// <summary>
		/// Increments the index, returning whether a value exists at the specified index.
		/// </summary>
		/// <returns>Whether the incrementing actually returned a value.</returns>
		public bool Increment()
		{
			this.CurrentValueIndex++;
	
			if (this.CurrentValueIndex >= this.Values.Length)
				return false;

			return true;
		}

		/// <summary>
		/// Resets the index.
		/// </summary>
		public void Reset()
		{
			this.CurrentValueIndex = 0;
		}

		#endregion
	}
}
