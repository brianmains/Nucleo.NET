using System;


namespace Nucleo
{
	/// <summary>
	/// Represents a lazy value, an easy way to lazily create an object of a given type.
	/// </summary>
	/// <typeparam name="TEntity">The entity type to lazily create.</typeparam>
	public class LazyValue<TEntity>
	{
		public Func<TEntity> _creator = null;
		private bool _isValueCreated = false;
		private TEntity _value = default(TEntity);



		#region " Properties "

		/// <summary>
		/// Gets whether the value was created yet.
		/// </summary>
		public bool IsValueCreated
		{
			get { return _isValueCreated; }
		}

		/// <summary>
		/// Gets the value, creating it using the lambda if it has not yet been created.
		/// </summary>
		public TEntity Value
		{
			get 
			{
				if (_isValueCreated)
					return _value;

				_value = _creator();
				_isValueCreated = true;
				return _value; 
			}
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the lazy value with the entity.
		/// </summary>
		/// <param name="value">The value used to create the lazy.</param>
		public LazyValue(TEntity value)
		{
			_value = value;
			_isValueCreated = true;
		}

		/// <summary>
		/// Creates the lazy value, using the lambda.
		/// </summary>
		/// <param name="creator">The creator used to create the instance.</param>
		public LazyValue(Func<TEntity> creator)
		{
			_creator = creator;
		}

		#endregion
	}
}
