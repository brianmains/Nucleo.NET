using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Objects;

using Nucleo.Orm.Generic;


namespace Nucleo.Orm.Entities.Generic
{
	/// <summary>
	/// Represents the generic unit of work that uses an object context.
	/// </summary>
	public class ContextGenericUnitOfWork : IGenericUnitOfWork
	{
		private ObjectContext _context = null;



		#region " Constructors "

		/// <summary>
		/// Creates the unit of work with the given context.
		/// </summary>
		/// <param name="context">The object context instance.</param>
		/// <exception cref="ArgumentNullException">Thrown when the context is null.</exception>
		public ContextGenericUnitOfWork(ObjectContext context)
		{
			if (context == null)
				throw new ArgumentNullException("set");

			_context = context;
		}

		#endregion



		#region " Methods "

		public virtual object CreateNew(EntityKeyInformation info)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			return Activator.CreateInstance(info.EntityType);
		}

		private EntityKey CreateEntityKey(EntityKeyInformation info)
		{
			return new EntityKey(info.EntityName, new EntityKeyMember[]
			{
				new EntityKeyMember(info.KeyName, info.KeyValue)
			});
		}

		public virtual object Get(EntityKeyInformation info)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			object value = null;

			if (_context.TryGetObjectByKey(this.CreateEntityKey(info), out value))
				return value;
			else
				return null;
		}

		public IQueryable<TArg> Query<TArg>(Func<ObjectSet<TArg>, IQueryable<TArg>> action)
			where TArg : class
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var os = _context.CreateObjectSet<TArg>();
			return action(os);
		}

		public IQueryable<TOut> Query<TArg, TOut>(Func<ObjectSet<TArg>, IQueryable<TOut>> action)
			where TArg : class
			where TOut : class
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var os = _context.CreateObjectSet<TArg>();
			return action(os);
		}

		public IQueryable<TOut> Query<TArg1, TArg2, TOut>(Func<ObjectSet<TArg1>, ObjectSet<TArg2>, IQueryable<TOut>> action)
			where TArg1 : class
			where TArg2 : class
			where TOut : class
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var os1 = _context.CreateObjectSet<TArg1>();
			var os2 = _context.CreateObjectSet<TArg2>();
			return action(os1, os2);
		}

		public IQueryable<TOut> Query<TArg1, TArg2, TArg3, TOut>(Func<ObjectSet<TArg1>, ObjectSet<TArg2>, ObjectSet<TArg3>, IQueryable<TOut>> action)
			where TArg1 : class
			where TArg2 : class
			where TArg3 : class
			where TOut : class
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var os1 = _context.CreateObjectSet<TArg1>();
			var os2 = _context.CreateObjectSet<TArg2>();
			var os3 = _context.CreateObjectSet<TArg3>();
			return action(os1, os2, os3);
		}

		public IQueryable Query<TUnitOfWork>(Func<TUnitOfWork, IQueryable> action)
			where TUnitOfWork : IUnitOfWork
		{
			if (action == null)
				throw new ArgumentNullException("action");
			if (!(_context is TUnitOfWork))
				throw new InvalidOperationException("The object context does not implement the type '" + typeof(TUnitOfWork).Name + "'.");

			return action((TUnitOfWork)((object)_context));
		}

		public IQueryable<TEntity> Query<TUnitOfWork, TEntity>(Func<TUnitOfWork, IQueryable<TEntity>> action)
			where TUnitOfWork : IUnitOfWork
			where TEntity: class
		{
			if (action == null)
				throw new ArgumentNullException("action");
			if (!(_context is TUnitOfWork))
				throw new InvalidOperationException("The object context does not implement the type '" + typeof(TUnitOfWork).Name + "'.");

			return action((TUnitOfWork)((object)_context));
		}

		public virtual void QueueDelete(EntityKeyInformation info, object entity)
		{
			if (info == null)
				throw new ArgumentNullException("info");
			if (entity == null)
				throw new ArgumentNullException("entity");

			_context.DeleteObject(entity);
		}

		public virtual void QueueInsert(EntityKeyInformation info, object entity)
		{
			if (info == null)
				throw new ArgumentNullException("info");
			if (entity == null)
				throw new ArgumentNullException("entity");

			_context.AddObject(info.EntityName, entity);
		}

		public virtual void QueueUpdate(EntityKeyInformation info, object entity)
		{
			if (info == null)
				throw new ArgumentNullException("info");
			if (entity == null)
				throw new ArgumentNullException("entity");
		}

		public virtual void SaveChanges()
		{
			_context.SaveChanges();
		}

		#endregion
	}
}
