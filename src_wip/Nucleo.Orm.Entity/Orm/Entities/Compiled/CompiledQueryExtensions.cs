using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;


namespace Nucleo.Orm.Entities.Compiled
{
	public static class CompiledQueryExtensions
	{
		#region " Methods "

		public static Func<TContext, IQueryable<TEntity>> CompiledQuery<TContext, TEntity>(this IObjectSetUnitOfWork<TEntity> set, 
			Func<TContext, IQueryable<TEntity>> source, string key = null)
			where TContext : ObjectContext
			where TEntity: class
		{
			return CompiledQueries.Get<TContext, IQueryable<TEntity>>(key);
		}

		public static Func<TContext, TArg1, IQueryable<TEntity>> CompiledQuery<TContext, TArg1, TEntity>(this IObjectSetUnitOfWork<TEntity> set,
			Func<TContext, IQueryable<TEntity>> source, string key = null)
			where TContext : ObjectContext
			where TEntity : class
		{
			return CompiledQueries.Get<TContext, TArg1, IQueryable<TEntity>>(key);
		}

		public static Func<TContext, TArg1, TArg2, IQueryable<TEntity>> CompiledQuery<TContext, TArg1, TArg2, TEntity>(this IObjectSetUnitOfWork<TEntity> set,
			Func<TContext, IQueryable<TEntity>> source, string key = null)
			where TContext : ObjectContext
			where TEntity : class
		{
			return CompiledQueries.Get<TContext, TArg1, TArg2, IQueryable<TEntity>>(key);
		}

		public static Func<TContext, TArg1, TArg2, TArg3, IQueryable<TEntity>> CompiledQuery<TContext, TArg1, TArg2, TArg3, TEntity>(this IObjectSetUnitOfWork<TEntity> set,
			Func<TContext, IQueryable<TEntity>> source, string key = null)
			where TContext : ObjectContext
			where TEntity : class
		{
			return CompiledQueries.Get<TContext, TArg1, TArg2, TArg3, IQueryable<TEntity>>(key);
		}

		public static Func<TContext, TArg1, TArg2, TArg3, TArg4, IQueryable<TEntity>> CompiledQuery<TContext, TArg1, TArg2, TArg3, TArg4, TEntity>(this IObjectSetUnitOfWork<TEntity> set,
			Func<TContext, IQueryable<TEntity>> source, string key = null)
			where TContext : ObjectContext
			where TEntity : class
		{
			return CompiledQueries.Get<TContext, TArg1, TArg2, TArg3, TArg4, IQueryable<TEntity>>(key);
		}

		public static Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, IQueryable<TEntity>> CompiledQuery<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TEntity>(this IObjectSetUnitOfWork<TEntity> set,
			Func<TContext, IQueryable<TEntity>> source, string key = null)
			where TContext : ObjectContext
			where TEntity : class
		{
			return CompiledQueries.Get<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, IQueryable<TEntity>>(key);
		}

		#endregion
	}
}
