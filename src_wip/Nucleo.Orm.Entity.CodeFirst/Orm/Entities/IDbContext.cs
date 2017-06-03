using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.ComponentModel;
using System.Data.Entity.Validation;

namespace Nucleo.Orm.Entities
{
	public interface IDbContext : IDisposable
	{
		// Summary:
		//     Provides access to features of the context that deal with change tracking
		//     of entities.
		DbChangeTracker ChangeTracker { get; }
		//
		// Summary:
		//     Provides access to configuration options for the context.
		DbContextConfiguration Configuration { get; }
		//
		// Summary:
		//     Creates a Database instance for this context that allows for creation/deletion/existence
		//     checks for the underlying database.
		Database Database { get; }

		//
		// Summary:
		//     Gets a System.Data.Entity.Infrastructure.DbEntityEntry object for the given
		//     entity providing access to information about the entity and the ability to
		//     perform actions on the entity.
		//
		// Parameters:
		//   entity:
		//     The entity.
		//
		// Returns:
		//     An entry for the entity.
		DbEntityEntry Entry(object entity);

		//
		// Summary:
		//     Gets a System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> object for
		//     the given entity providing access to information about the entity and the
		//     ability to perform actions on the entity.
		//
		// Parameters:
		//   entity:
		//     The entity.
		//
		// Type parameters:
		//   TEntity:
		//     The type of the entity.
		//
		// Returns:
		//     An entry for the entity.
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

		//
		// Summary:
		//     Validates tracked entities and returns a Collection of System.Data.Entity.Validation.DbEntityValidationResult
		//     containing validation results.
		//
		// Returns:
		//     Collection of validation results for invalid entities. The collection is
		//     never null and must not contain null values or results for valid entities.
		//
		// Remarks:
		//     1. This method calls DetectChanges() to determine states of the tracked entities
		//     unless DbContextConfiguration.AutoDetectChangesEnabled is set to false. 
		//     2. By default only Added on Modified entities are validated. The user is
		//     able to change this behavior by overriding ShouldValidateEntity method.
		IEnumerable<DbEntityValidationResult> GetValidationErrors();

		//
		// Summary:
		//     Saves all changes made in this context to the underlying database.
		//
		// Returns:
		//     The number of objects written to the underlying database.
		//
		// Exceptions:
		//   System.InvalidOperationException:
		//     Thrown if the context has been disposed.
		int SaveChanges();

		//
		// Summary:
		//     Returns a DbSet instance for access to entities of the given type in the
		//     context, the ObjectStateManager, and the underlying store.
		//
		// Type parameters:
		//   TEntity:
		//     The type entity for which a set should be returned.
		//
		// Returns:
		//     A set for the given entity type.
		//
		// Remarks:
		//     See the DbSet class for more details.
		DbSet<TEntity> Set<TEntity>() where TEntity : class;

		//
		// Summary:
		//     Returns a non-generic DbSet instance for access to entities of the given
		//     type in the context, the ObjectStateManager, and the underlying store.
		//
		// Parameters:
		//   entityType:
		//     The type of entity for which a set should be returned.
		//
		// Returns:
		//     A set for the given entity type.
		//
		// Remarks:
		//     See the DbSet class for more details.
		DbSet Set(Type entityType);
	}
}
