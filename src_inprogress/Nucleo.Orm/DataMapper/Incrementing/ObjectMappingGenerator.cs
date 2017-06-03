using System;
using System.Reflection;


namespace Nucleo.DataMapper.Incrementing
{
	/// <summary>
	/// Represents the mapping generator that generates objects using a specific type.
	/// </summary>
	public class ObjectMappingGenerator : IMappingGenerator
	{
		Type _objectType = null;



		#region " Properties "

		/// <summary>
		/// Gets the type of object to create.
		/// </summary>
		public Type ObjectType
		{
			get { return _objectType; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the mapping generator using the specific object type.
		/// </summary>
		/// <param name="objectType">The type of object.</param>
		public ObjectMappingGenerator(Type objectType)
		{
			_objectType = objectType;
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Generates an object using the current collection of mappings.
		/// </summary>
		/// <param name="map">The collection of mappings.</param>
		/// <returns>The generated object.</returns>
		public object Generate(IncrementMappings map)
		{
			object obj = Activator.CreateInstance(_objectType);
			IncrementMappingCollection mappings = map.GetMappings();

			foreach (IncrementMapping mapping in mappings)
			{
				PropertyInfo property = _objectType.GetProperty(mapping.Field);
				if (property != null && property.CanWrite)
					property.SetValue(obj, mapping.GetValue(), null);
			}

			return obj;
		}

		#endregion
	}
}
