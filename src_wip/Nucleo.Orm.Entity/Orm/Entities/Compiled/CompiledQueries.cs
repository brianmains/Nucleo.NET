using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;


namespace Nucleo.Orm.Entities.Compiled
{
	public static class CompiledQueries
	{
		public static ICompiledQueryProvider _provider = null;


		#region " Properties "

		public static ICompiledQueryProvider Provider
		{
			get { return _provider; }
			set
			{
				if (_provider != null)
					return;

				lock (typeof(ICompiledQueryProvider))
				{
					if (_provider != null)
						return;

					_provider = value;
				}
			}
		}

		#endregion



		#region " Methods "

		public static void Add<TContext, TResult>(Func<TContext, TResult> action, string key = null)
			where TContext: ObjectContext
		{
			_provider.Add<TContext, TResult>(action, key);
		}

		public static void Add<TContext, TArg1, TResult>(Func<TContext, TArg1, TResult> action, string key = null)
			where TContext: ObjectContext
		{
			_provider.Add<TContext, TArg1, TResult>(action, key);
		}

		public static void Add<TContext, TArg1, TArg2, TResult>(Func<TContext, TArg1, TArg2, TResult> action, string key = null)
			where TContext: ObjectContext
		{
			_provider.Add<TContext, TArg1, TArg2, TResult>(action, key);
		}

		public static void Add<TContext, TArg1, TArg2, TArg3, TResult>(Func<TContext, TArg1, TArg2, TArg3, TResult> action, string key = null)
			where TContext : ObjectContext
		{
			_provider.Add<TContext, TArg1, TArg2, TArg3, TResult>(action, key);
		}

		public static void Add<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> action, string key = null)
			where TContext : ObjectContext
		{
			_provider.Add<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(action, key);
		}

		public static void Add<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> action, string key = null)
			where TContext : ObjectContext
		{
			_provider.Add<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(action, key);
		}

		public static Func<TContext, TResult> Get<TContext, TResult>(string key = null)
			where TContext : ObjectContext
		{
			return _provider.Get<TContext, TResult>(key);
		}

		public static Func<TContext, TArg1, TResult> Get<TContext, TArg1, TResult>(string key = null)
			where TContext : ObjectContext
		{
			return _provider.Get<TContext, TArg1, TResult>(key);
		}

		public static Func<TContext, TArg1, TArg2, TResult> Get<TContext, TArg1, TArg2, TResult>(string key = null)
			where TContext : ObjectContext
		{
			return _provider.Get<TContext, TArg1, TArg2, TResult>(key);
		}

		public static Func<TContext, TArg1, TArg2, TArg3, TResult> Get<TContext, TArg1, TArg2, TArg3, TResult>(string key = null)
			where TContext : ObjectContext
		{
			return _provider.Get<TContext, TArg1, TArg2, TArg3, TResult>(key);
		}

		public static Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> Get<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(string key = null)
			where TContext : ObjectContext
		{
			return _provider.Get<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(key);
		}

		public static Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Get<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(string key = null)
			where TContext : ObjectContext
		{
			return _provider.Get<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(key);
		}

		#endregion
	}
}
