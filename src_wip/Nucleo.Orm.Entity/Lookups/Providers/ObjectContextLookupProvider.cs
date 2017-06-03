using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;

using Nucleo.Lookups.Identification;
using Nucleo.Lookups.Repositories;


namespace Nucleo.Lookups.Providers
{
	/// <summary>
	/// Represents the lookup provider that wraps itself around entity framework.  Dynamically creates the object set using the given type provided.
	/// </summary>
	public class ObjectContextLookupProvider : ILookupProvider
	{
		private ObjectContext _context = null;



		/// <summary>
		/// Instantiates the provider and supplies the object context.
		/// </summary>
		/// <param name="ctx">The objectcontext.</param>
		public ObjectContextLookupProvider(ObjectContext ctx)
		{
			Guard.NotNull(ctx);

			_context = ctx;
		}



		/// <summary>
		/// Gets the reference to the repository mentioned by the ID.  Will return an ObjectSet matching that entity type.
		/// </summary>
		/// <param name="id">The identifier to use to find the entity.</param>
		/// <returns>The repository found.</returns>
		public virtual ILookupRepository GetRepository(ILookupIdentifier id)
		{
			return new ObjectSetLookupRepository(_context.CreateObjectSet(((EntityTypeLookupIdentifier)id).EntityType).ObjectSet);
		}

		/// <summary>
		/// Checks whether this provider can support the given type of ID; this makes sure its safe to instantiate a repository using the given identifier.
		/// </summary>
		/// <param name="id">The ID to check.</param>
		/// <returns>Whether the identifier is supported.</returns>
		public virtual bool SupportsIdentifier(ILookupIdentifier id)
		{
			return (id is EntityTypeLookupIdentifier);
		}
	}
}
