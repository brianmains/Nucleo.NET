using System;


namespace Nucleo.EventsManagement.Listeners
{
	public class EntityTypeListenerCriteria : IListenerCriteria
	{
		private Type _entityType = null;



		#region " Properties "

		public Type EntityType
		{
			get { return _entityType; }
		}

		#endregion



		#region " Constructors "

		public EntityTypeListenerCriteria(Type entityType)
		{
			if (entityType == null)
				throw new ArgumentNullException("entityType");

			_entityType = entityType;
		}

		#endregion



		#region " Methods "

		public bool IsMatch(IListenerCriteria criteria)
		{
			if (criteria is EntityListenerCriteria)
			{
				EntityListenerCriteria entityCriteria = (EntityListenerCriteria)criteria;
				return this.EntityType.IsAssignableFrom(entityCriteria.Entity.GetType());
			}
			else if (criteria is EntityTypeListenerCriteria)
			{
				EntityTypeListenerCriteria entityTypeCriteria = (EntityTypeListenerCriteria)criteria;
				return this.EntityType.IsAssignableFrom(entityTypeCriteria.EntityType);
			}
			else if (criteria is EventListenerCriteria)
			{
				return this.EntityType.IsAssignableFrom(((EventListenerCriteria)criteria).Event.GetType());
			}
			else if (criteria is AnyListenerCriteria)
				return true;
			else
				return false;
		}

		public override string ToString()
		{
			return "Entity Type " + ((_entityType != null) ? _entityType.Name : "Unknown");
		}

		#endregion
	}
}
