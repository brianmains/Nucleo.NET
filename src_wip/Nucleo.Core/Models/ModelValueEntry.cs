using System;
using System.Collections.Generic;
using Nucleo.Collections;


namespace Nucleo.Models
{
	/// <summary>
	/// Gets the model value entry.
	/// </summary>
	public class ModelValueEntry
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the attributes within the model's value.
		/// </summary>
		public ObjectCollection Attributes
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the injection definition details.
		/// </summary>
		public IModelInjection InjectionDefinition
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the entry.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets teh value of the model value entry.
		/// </summary>
		public object Value
		{
			get;
			set;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Gets the value of the value portion of the entry.
		/// </summary>
		/// <typeparam name="T">The type to convert to.</typeparam>
		/// <returns>The converted value.</returns>
		public T GetValue<T>()
		{
			
			if (this.Value is IConvertible)
				return (T)Convert.ChangeType(this.Value, typeof(T), System.Globalization.CultureInfo.CurrentCulture);

			return (T)this.Value;
		}

		#endregion
	}
}
