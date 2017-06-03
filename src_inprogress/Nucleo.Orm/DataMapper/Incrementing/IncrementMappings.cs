using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.DataMapper.Incrementing
{
	/// <summary>
	/// Represents the collection of mappings.
	/// </summary>
	public class IncrementMappings
	{
		private IncrementMappingCollection _values = null;



		#region " Properties "

		/// <summary>
		/// Gets the number of registered mappings.
		/// </summary>
		public int MappingCount
		{
			get { return this._values.Count; }
		}

		private IncrementMappingCollection Values
		{
			get
			{
				if (_values == null)
					_values = new IncrementMappingCollection();
				return _values;
			}
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the mapping at the specified index.
		/// </summary>
		/// <param name="index">The index to look at.</param>
		/// <returns>The mapping found or null.</returns>
		/// <remarks>If the value is out of range, a null is returned.</remarks>
		public IncrementMapping GetMapping(int index)
		{
			if (this.Values.Count >= index || index < 0)
				return null;

			return this.Values[index];
		}

		/// <summary>
		/// Gets the complete collection of mappings.
		/// </summary>
		/// <returns>The collection of mappings.</returns>
		public IncrementMappingCollection GetMappings()
		{
			return this.Values;
		}

		/// <summary>
		/// Returns whether all of the mappings, when being iterated through, are at the zero index position.
		/// </summary>
		/// <returns>Whether at all zeros.</returns>
		public bool IsAtAllZeros()
		{
			foreach (IncrementMapping mapping in this.Values)
			{
				if (mapping.CurrentValueIndex != 0)
					return false;
			}

			return true;
		}

		public void Register(string field, object[] values)
		{
			this.Values.Add(new IncrementMapping { Field = field, Values = values, CurrentValueIndex = 0 });
		}

		#endregion
	}
}
