using System;
using System.Collections.Generic;
using System.Linq;


namespace System.Data.Objects.DataClasses
{
	public static class EntityExtensions
	{
		#region " Methods "

		/// <summary>
		/// Loads and returns an EntityCollection collection object, which is a foreign key reference collection to a primary key table.
		/// </summary>
		/// <typeparam name="T">The core entity type in the collection.</typeparam>
		/// <param name="collection">The collection of entities.</param>
		/// <returns>The collection of entities now loaded.</returns>
		public static EntityCollection<TOut> Reference<TIn, TOut>(this TIn obj, Func<TIn, EntityCollection<TOut>> fn)
			where TIn : class, IEntityWithRelationships
			where TOut : class, IEntityWithRelationships
		{
			EntityCollection<TOut> collection = fn(obj);

			if (!collection.IsLoaded)
				collection.Load();

			return collection;
		}

		/// <summary>
		/// Loads and returns an EntityReference object, which is a primary key object.  Returns the value, not the reference, so the user can drill-down.
		/// </summary>
		/// <typeparam name="T">The core entity reference type.</typeparam>
		/// <param name="reference">The primary key reference.</param>
		/// <returns>The primary key object.</returns>
		public static TOut Reference<TIn, TOut>(this TIn obj, Func<TIn, EntityReference<TOut>> fn)
			where TIn : class, IEntityWithRelationships
			where TOut : class, IEntityWithRelationships
		{
			EntityReference<TOut> reference = fn(obj);

			if (!reference.IsLoaded)
				reference.Load();

			return reference.Value;
		}

		#endregion
	}
}
