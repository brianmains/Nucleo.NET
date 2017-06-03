using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Web.MathControls
{
	/// <summary>
	/// Represents an interface for a control that performs the calculation.
	/// </summary>
	public interface ICalculator
	{
		/// <summary>
		/// Gets the collection of fields that are attached to the calculator.
		/// </summary>
		SimpleCollection<CalculatedFieldExtender> Fields { get; }
		
		/// <summary>
		/// Registers a field within the calculator, which is used to provide the final calculation.
		/// </summary>
		/// <param name="field">The field to add.</param>
		void RegisterField(CalculatedFieldExtender field);
	}
}
