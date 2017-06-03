using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;


namespace Nucleo.Orm.DataClasses.Compiled
{
	public static class CompiledQueryExtensions
	{
		#region " Methods "

		public static IQueryable<TEntity> CompiledQuery<TContext, TEntity>(this ITableUnitOfWork<TEntity> set, 
			Expression<Func<TContext, IQueryable<TEntity>>> source, string key = null)
			where TContext : DataContext
			where TEntity: class
		{
			if (!CompiledQueries.Contains<TContext, IQueryable<TEntity>>(key))
				CompiledQueries.Add<TContext, IQueryable<TEntity>>(source, key);

			return CompiledQueries.Get<TContext, IQueryable<TEntity>>(key)((TContext)set.Context);
		}

		public static IQueryable<TEntity> CompiledQuery<TContext, TArg1, TEntity>(this ITableUnitOfWork<TEntity> set,
			Expression<Func<TContext, TArg1, IQueryable<TEntity>>> source, TArg1 arg1, string key = null)
			where TContext : DataContext
			where TEntity : class
		{
			if (!CompiledQueries.Contains<TContext, TArg1, IQueryable<TEntity>>(key))
				CompiledQueries.Add<TContext, TArg1, IQueryable<TEntity>>(source, key);

			return CompiledQueries.Get<TContext, TArg1, IQueryable<TEntity>>(key)((TContext)set.Context, arg1);
		}

		public static IQueryable<TEntity> CompiledQuery<TContext, TArg1, TArg2, TEntity>(this ITableUnitOfWork<TEntity> set,
			Expression<Func<TContext, TArg1, TArg2, IQueryable<TEntity>>> source, TArg1 arg1, TArg2 arg2, string key = null)
			where TContext : DataContext
			where TEntity : class
		{
			if (!CompiledQueries.Contains<TContext, TArg1, TArg2, IQueryable<TEntity>>(key))
				CompiledQueries.Add<TContext, TArg1, TArg2, IQueryable<TEntity>>(source, key);

			return CompiledQueries.Get<TContext, TArg1, TArg2, IQueryable<TEntity>>(key)((TContext)set.Context, arg1, arg2);
		}

		public static IQueryable<TEntity> CompiledQuery<TContext, TArg1, TArg2, TArg3, TEntity>(this ITableUnitOfWork<TEntity> set,
			Expression<Func<TContext, TArg1, TArg2, TArg3, IQueryable<TEntity>>> source, TArg1 arg1, TArg2 arg2, TArg3 arg3, string key = null)
			where TContext : DataContext
			where TEntity : class
		{
			if (!CompiledQueries.Contains<TContext, TArg1, TArg2, TArg3, IQueryable<TEntity>>(key))
				CompiledQueries.Add<TContext, TArg1, TArg2, TArg3, IQueryable<TEntity>>(source, key);

			return CompiledQueries.Get<TContext, TArg1, TArg2, TArg3, IQueryable<TEntity>>(key)((TContext)set.Context, arg1, arg2, arg3);
		}

#if NET35
#else
		public static IQueryable<TEntity> CompiledQuery<TContext, TArg1, TArg2, TArg3, TArg4, TEntity>(this ITableUnitOfWork<TEntity> set,
			Expression<Func<TContext, TArg1, TArg2, TArg3, TArg4, IQueryable<TEntity>>> source, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, string key = null)
			where TContext : DataContext
			where TEntity : class
		{
			if (!CompiledQueries.Contains<TContext, TArg1, TArg2, TArg3, TArg4, IQueryable<TEntity>>(key))
				CompiledQueries.Add<TContext, TArg1, TArg2, TArg3, TArg4, IQueryable<TEntity>>(source, key);

			return CompiledQueries.Get<TContext, TArg1, TArg2, TArg3, TArg4, IQueryable<TEntity>>(key)((TContext)set.Context, arg1, arg2, arg3, arg4);
		}

		public static IQueryable<TEntity> CompiledQuery<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TEntity>(this ITableUnitOfWork<TEntity> set,
			Expression<Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, IQueryable<TEntity>>> source, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, string key = null)
			where TContext : DataContext
			where TEntity : class
		{
			if (!CompiledQueries.Contains<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, IQueryable<TEntity>>(key))
				CompiledQueries.Add<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, IQueryable<TEntity>>(source, key);

			return CompiledQueries.Get<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, IQueryable<TEntity>>(key)((TContext)set.Context, arg1, arg2, arg3, arg4, arg5);
		}
#endif

		#endregion
	}
}
