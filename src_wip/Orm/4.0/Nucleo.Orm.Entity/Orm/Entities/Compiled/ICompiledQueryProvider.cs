using System;
using System.Linq;
using System.Data.Objects;


namespace Nucleo.Orm.Entities.Compiled
{
	public interface ICompiledQueryProvider
	{
		void Add<TContext, TResult>(Func<TContext, TResult> action, string key = null)
			where TContext : ObjectContext;

		void Add<TContext, TArg1, TResult>(Func<TContext, TArg1, TResult> action, string key = null)
			where TContext : ObjectContext;

		void Add<TContext, TArg1, TArg2, TResult>(Func<TContext, TArg1, TArg2, TResult> action, string key = null)
			where TContext : ObjectContext;

		void Add<TContext, TArg1, TArg2, TArg3, TResult>(Func<TContext, TArg1, TArg2, TArg3, TResult> action, string key = null)
			where TContext : ObjectContext;

		void Add<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> action, string key = null)
			where TContext : ObjectContext;

		void Add<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> action, string key = null)
			where TContext : ObjectContext;

		Func<TContext, TResult> Get<TContext, TResult>(string key = null)
			where TContext : ObjectContext;

		Func<TContext, TArg1, TResult> Get<TContext, TArg1, TResult>(string key = null)
			where TContext : ObjectContext;

		Func<TContext, TArg1, TArg2, TResult> Get<TContext, TArg1, TArg2, TResult>(string key = null)
			where TContext : ObjectContext;

		Func<TContext, TArg1, TArg2, TArg3, TResult> Get<TContext, TArg1, TArg2, TArg3, TResult>(string key = null)
			where TContext : ObjectContext;

		Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> Get<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(string key = null)
			where TContext : ObjectContext;

		Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Get<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(string key = null)
			where TContext : ObjectContext;
	}
}