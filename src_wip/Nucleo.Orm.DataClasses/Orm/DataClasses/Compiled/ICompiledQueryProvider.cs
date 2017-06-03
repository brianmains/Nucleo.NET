using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;


namespace Nucleo.Orm.DataClasses.Compiled
{
	public interface ICompiledQueryProvider
	{
		void Add<TContext, TResult>(Expression<Func<TContext, TResult>> action, string key = null)
			where TContext : DataContext;

		void Add<TContext, TArg1, TResult>(Expression<Func<TContext, TArg1, TResult>> action, string key = null)
			where TContext : DataContext;

		void Add<TContext, TArg1, TArg2, TResult>(Expression<Func<TContext, TArg1, TArg2, TResult>> action, string key = null)
			where TContext : DataContext;

		void Add<TContext, TArg1, TArg2, TArg3, TResult>(Expression<Func<TContext, TArg1, TArg2, TArg3, TResult>> action, string key = null)
			where TContext : DataContext;

#if NET35
#else
		void Add<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(Expression<Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult>> action, string key = null)
			where TContext : DataContext;

		void Add<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Expression<Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> action, string key = null)
			where TContext : DataContext;
#endif

		bool Contains<TContext, TResult>(string key = null)
			where TContext : DataContext;

		bool Contains<TContext, TArg1, TResult>(string key = null)
			where TContext : DataContext;

		bool Contains<TContext, TArg1, TArg2, TResult>(string key = null)
			where TContext : DataContext;

		bool Contains<TContext, TArg1, TArg2, TArg3, TResult>(string key = null)
			where TContext : DataContext;

#if NET35
#else
		bool Contains<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(string key = null)
			where TContext : DataContext;

		bool Contains<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(string key = null)
			where TContext : DataContext;
#endif

		Func<TContext, TResult> Get<TContext, TResult>(string key = null)
			where TContext : DataContext;

		Func<TContext, TArg1, TResult> Get<TContext, TArg1, TResult>(string key = null)
			where TContext : DataContext;

		Func<TContext, TArg1, TArg2, TResult> Get<TContext, TArg1, TArg2, TResult>(string key = null)
			where TContext : DataContext;

		Func<TContext, TArg1, TArg2, TArg3, TResult> Get<TContext, TArg1, TArg2, TArg3, TResult>(string key = null)
			where TContext : DataContext;

#if NET35
#else
		Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> Get<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(string key = null)
			where TContext : DataContext;

		Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Get<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(string key = null)
			where TContext : DataContext;
#endif
	}
}