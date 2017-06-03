using System;
using System.Reflection;

using Nucleo.Exceptions;


namespace Nucleo.Reflection
{
	public class ReflectProperty : BaseReflectMember
	{
		#region " Constructors "

		/// <summary>
		/// Creates the reflected property object.
		/// </summary>
		/// <param name="propertyName">The name of the property.</param>
		/// <param name="target">The target that has the property.</param>
		/// <param name="isPrivate">Whether the property is public (false) or private (true).</param>
		public ReflectProperty(string propertyName, object target, bool isPrivate)
			: base(propertyName, target, isPrivate) { }

		#endregion



		#region " Methods "
		
		/// <summary>
		/// Uses an action to supply bulk operational processing.
		/// </summary>
		/// <param name="action">The action to process.</param>
		public void Action(Action<ReflectProperty> action)
		{
			action(this);
		}

		/// <summary>
		/// Gets the underlying member reference in the reflection API.
		/// </summary>
		/// <returns>The member reference.</returns>
		public override MemberInfo GetMember()
		{
			return this.GetProperty();
		}

		private PropertyInfo GetProperty()
		{
			PropertyInfo property = base.Target.GetType().GetProperty(base.Name, base.GetFlags());
			if (property == null)
				throw new NotFoundException("The property " + base.Name + " could not be found.");

			return property;
		}

		/// <summary>
		/// Gets the value from the underlying property.
		/// </summary>
		/// <returns>The value for the property.</returns>
		public object GetValue()
		{
			return this.GetProperty().GetValue(base.Target, null);
		}
		
		/// <summary>
		/// Gets the value from the underlying property in strongly-typed form.
		/// </summary>
		/// <typeparam name="T">The type to convert the value to; must be the correct type or an exception may result.</typeparam>
		/// <returns>The strongly-typed value or the default of that value.</returns>
		public T GetValue<T>()
		{
			return (T)(GetValue() ?? default(T));
		}

		/// <summary>
		/// Sets the value for the property using a convertible value.
		/// </summary>
		/// <param name="value">The value to set.</param>
		public void SetValue(object value)
		{
			PropertyInfo property = this.GetProperty();
			Type propertyType = property.PropertyType;

			property.SetValue(base.Target, value, null);
		}

		/// <summary>
		/// Sets the value for the property, using the generic strongly-typed form.
		/// </summary>
		/// <typeparam name="T">The type of value being set.</typeparam>
		/// <param name="value">The value to set.</param>
		public void SetValue<T>(T value)
		{
			this.GetProperty().SetValue(base.Target, value, null);
		}

		/// <summary>
		/// Gets the property name in the form &lt;target type>.&lt;prop name>.
		/// </summary>
		/// <returns>The formatted name.</returns>
		public override string ToString()
		{
			return this.Target.GetType().Name + "." + base.Name;
		}

		#endregion
	}
}
