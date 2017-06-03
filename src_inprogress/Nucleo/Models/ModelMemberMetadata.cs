using System;
using System.Collections.Generic;
using System.Reflection;


namespace Nucleo.Models
{
	/// <summary>
	/// Represents the metadata for the model's member.
	/// </summary>
	public class ModelMemberMetadata
	{
		private IDictionary<string, object> _attributes = null;
		private IModelInjection _injectionDefinition = null;
		private object _model = null;
		private PropertyInfo _property = null;



		#region " Properties "

		/// <summary>
		/// Gets the attributes that were passed in.
		/// </summary>
		public IDictionary<string, object> Attributes
		{
			get { return _attributes; }
		}

		/// <summary>
		/// Gets the information about the injection definition.
		/// </summary>
		public IModelInjection InjectionDefinition
		{
			get { return _injectionDefinition; }
		}

		/// <summary>
		/// Gets the model instance.
		/// </summary>
		public object Model
		{
			get { return _model; }
		}

		/// <summary>
		/// Gets the underlying type of property of the model that's being injected.
		/// </summary>
		public Type ValueType
		{
			get { return _property.PropertyType; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Gets the metadata for the member of the model.
		/// </summary>
		/// <param name="model">The model instance.</param>
		/// <param name="property"> The property definition.</param>
		/// <param name="injectionDefinition">The model injection defintition.</param>
		public ModelMemberMetadata(object model, PropertyInfo property, IModelInjection injectionDefinition)
		{
			_model = model;
			_property = property;
			_injectionDefinition = injectionDefinition;
		}

		/// <summary>
		/// Gets the metadata for the member of the model.
		/// </summary>
		/// <param name="model">The model instance.</param>
		/// <param name="property"> The property definition.</param>
		/// <param name="injectionDefinition">The model injection defintition.</param>
		/// <param name="attributes">The attributes of the metadata.</param>
		public ModelMemberMetadata(object model, PropertyInfo property, IModelInjection injectionDefinition, IDictionary<string, object> attributes)
			: this(model, property, injectionDefinition)
		{
			_attributes = attributes;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Sets the member value.
		/// </summary>
		/// <param name="newValue">The new value to update with.</param>
		public void SetMemberValue(object newValue)
		{
			_property.SetValue(this.Model, newValue, null);
		}

		#endregion
	}
}
