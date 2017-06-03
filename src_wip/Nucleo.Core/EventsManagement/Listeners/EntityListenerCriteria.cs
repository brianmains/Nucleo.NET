using System;


namespace Nucleo.EventsManagement.Listeners
{
	/// <summary>
	/// Represents listener criteria for a specific entity.
	/// </summary>
	public class EntityListenerCriteria : IListenerCriteria
	{
		private object _entity = null;



		#region " Properties "

		/// <summary>
		/// Gets the type of entity to listen for.
		/// </summary>
		public object Entity
		{
			get { return _entity; }
		}

		#endregion



		#region " Constructors "

		/// <summary>
		/// Creates the listener criteria with the entity.
		/// </summary>
		/// <param name="entity">The entity to listen for.</param>
		public EntityListenerCriteria(object entity)
		{
			if (entity == null)
				throw new ArgumentNullException("entity");

			_entity = entity;
		}

		#endregion



		#region " Methods "
		
		/// <summary>
		/// Gets whether the current listener is a match with another criteria listener.
		/// </summary>
		/// <param name="criteria">The criteria to evaluate.</param>
		/// <returns>Whether a match occurs.</returns>
		public virtual bool IsMatch(IListenerCriteria criteria)
		{
			if (criteria == null)
				throw new ArgumentNullException("criteria");

			if (criteria is EntityListenerCriteria)
			{
				EntityListenerCriteria entity = (EntityListenerCriteria)criteria;
				return Object.Equals(entity.Entity, _entity);
			}
			else if (criteria is EntityTypeListenerCriteria)
			{
				EntityTypeListenerCriteria entityType = (EntityTypeListenerCriteria)criteria;
				return _entity.GetType().IsAssignableFrom(entityType.EntityType);
			}
			else if (criteria is AnyListenerCriteria)
				return true;
			else
				return false;
		}

		public override string ToString()
		{
			return "Entity of type " + ((_entity != null) ? _entity.GetType().Name : "Unknown");
		}

		#endregion
	}
}
