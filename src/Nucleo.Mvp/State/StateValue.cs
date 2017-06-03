using System;


namespace Nucleo.State
{
	/// <summary>
	/// Gets the state value that represents the state information.
	/// </summary>
	public class StateValue
	{
		/// <summary>
		/// Gets or sets the key of the state entry.
		/// </summary>
		public object Key { get; set; }

		/// <summary>
		/// Gets or sets the value of the state entry.
		/// </summary>
		public object Value { get; set; }
	}
}
