using System;
using System.Collections.Generic;
using System.Reflection;


namespace Nucleo.Models
{
	/// <summary>
	/// Stores the information needed for the inspection.
	/// </summary>
	public class ModelInspectorOptions
	{
		private IDictionary<string, object> _attributes = null;
		private object _model = null;
		private PropertyInfo _property = null;



		#region " Properties "

		/// <summary>
		/// Gets or sets the collection of attributes, which are arbitrary attributes passed along.
		/// </summary>
		public IDictionary<string, object> Attributes
		{
			get { return _attributes; }
			set { _attributes = value; }
		}

		/// <summary>
		/// Gets or sets the reference to the model.
		/// </summary>
		public object Model
		{
			get { return _model; }
			set { _model = value; }
		}

		/// <summary>
		/// Gets or sets the current property being evaluated.
		/// </summary>
		public PropertyInfo Property
		{
			get { return _property; }
			set { _property = value; }
		}

		#endregion
	}
}
