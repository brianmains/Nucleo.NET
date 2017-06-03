using System;


namespace Nucleo.EventsManagement.Listeners
{
	/// <summary>
	/// Represents listener criteria to filter listeners by.
	/// </summary>
	public static class ListenerCriterion
	{
		#region " Methods "

		/// <summary>
		/// Gets any criteria to listen to.
		/// </summary>
		/// <returns>The listener criteria.</returns>
		public static AnyListenerCriteria Any()
		{
			return new AnyListenerCriteria();
		}

		/// <summary>
		/// Gets the entity type to listen to.
		/// </summary>
		/// <param name="entity">The entity to listen to.</param>
		/// <returns>The listener criteria.</returns>
		public static EntityListenerCriteria Entity(object instance)
		{
			return new EntityListenerCriteria(instance);
		}

		/// <summary>
		/// Gets the entity type to listen to.
		/// </summary>
		/// <param name="entityType">The type of entity.</param>
		/// <returns>The listener criteria.</returns>
		public static EntityTypeListenerCriteria EntityType(Type entityType)
		{
			return new EntityTypeListenerCriteria(entityType);
		}

		/// <summary>
		/// Gets the entity type to listen to.
		/// </summary>
		/// <typeparam name="T">The type to listen to.</typeparam>
		/// <returns>The listener criteria.</returns>
		public static EntityTypeListenerCriteria EntityType<T>()
		{
			return new EntityTypeListenerCriteria(typeof(T));
		}

		/// <summary>
		/// Gets a listener criteria for a specific event.
		/// </summary>
		/// <param name="eventInfo">The event information.</param>
		/// <returns>The listener criteria.</returns>
		public static EventListenerCriteria Event(IEvent eventInfo)
		{
			return new EventListenerCriteria(eventInfo);
		}

		public static EventListenerCriteria Event(IEvent eventInfo, object source)
		{
			return new EventListenerCriteria(eventInfo, source);
		}

		/// <summary>
		/// Gets the identifier to listen to.
		/// </summary>
		/// <param name="identifier">The identifier to listen to.</param>
		/// <returns>The listener criteria.</returns>
		public static NameIdentifierListenerCriteria Identifier(string identifier)
		{
			return new NameIdentifierListenerCriteria(identifier);
		}

		#endregion
	}
}
