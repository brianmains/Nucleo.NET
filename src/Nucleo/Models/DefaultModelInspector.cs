using System;


namespace Nucleo.Models
{
	/// <summary>
	/// Represents the default inspector that examines the metadata of a model's property.  By defualt, the attributes are inspected to see if the associated attribute has an <see cref="IModelInjection"/> definition.
	/// </summary>
	public class DefaultModelInspector : IModelInspector
	{
		#region " Methods "

		private IModelInjection FindAttribute(object[] collection)
		{
			if (collection == null)
				return null;

			foreach (object item in collection)
			{


				if (item is IModelInjection)
					return (IModelInjection)item;
			}

			return null;
		}

		/// <summary>
		/// Inspects the object's attributes to look for an attribute with the <see cref="IModelInjection"/> interface.
		/// </summary>
		/// <param name="options">The options to use for the location.</param>
		/// <returns>The injection definition, or null if not found.</returns>
		public virtual IModelInjection FindInjectionDefinition(ModelInspectorOptions options)
		{
			return FindAttribute(options.Property.GetCustomAttributes(true));
		}

		#endregion
	}
}
