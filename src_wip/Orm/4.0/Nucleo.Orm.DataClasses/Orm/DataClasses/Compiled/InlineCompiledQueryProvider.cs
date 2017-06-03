using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;


namespace Nucleo.Orm.DataClasses.Compiled
{
	public class InlineCompiledQueryProvider : ICompiledQueryProvider
	{
		private IDictionary<string, object> _dictionary = null;



		#region " Constructors "

		public InlineCompiledQueryProvider()
		{
			_dictionary = new Dictionary<string, object>();
		}

		public InlineCompiledQueryProvider(IDictionary<string, object> dict)
		{
			if (dict == null)
				throw new ArgumentNullException("dict");

			_dictionary = dict;
		}

		#endregion



		#region " Methods "

		public void Add<TContext, TResult>(Expression<Func<TContext, TResult>> action, string key = null) where TContext : System.Data.Linq.DataContext
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var id = GetID(new Type[] { typeof(TContext), typeof(TResult) }, key);
			_dictionary.Add(id, CompiledQuery.Compile<TContext, TResult>(action));
		}

		public void Add<TContext, TArg1, TResult>(Expression<Func<TContext, TArg1, TResult>> action, string key = null) where TContext : System.Data.Linq.DataContext
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TResult) }, key);
			_dictionary.Add(id, CompiledQuery.Compile<TContext, TArg1, TResult>(action));
		}

		public void Add<TContext, TArg1, TArg2, TResult>(Expression<Func<TContext, TArg1, TArg2, TResult>> action, string key = null) where TContext : System.Data.Linq.DataContext
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TResult) }, key);
			_dictionary.Add(id, CompiledQuery.Compile<TContext, TArg1, TArg2, TResult>(action));
		}

		public void Add<TContext, TArg1, TArg2, TArg3, TResult>(Expression<Func<TContext, TArg1, TArg2, TArg3, TResult>> action, string key = null) where TContext : System.Data.Linq.DataContext
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TResult) }, key);
			_dictionary.Add(id, CompiledQuery.Compile<TContext, TArg1, TArg2, TArg3, TResult>(action));
		}

		public void Add<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(Expression<Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult>> action, string key = null) where TContext : System.Data.Linq.DataContext
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TResult) }, key);
			_dictionary.Add(id, CompiledQuery.Compile<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(action));
		}

		public void Add<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Expression<Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>> action, string key = null) where TContext : System.Data.Linq.DataContext
		{
			if (action == null)
				throw new ArgumentNullException("action");

			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TResult) }, key);
			_dictionary.Add(id, CompiledQuery.Compile<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(action));
		}

		public bool Contains<TContext, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TResult) }, key);
			return _dictionary.ContainsKey(id);
		}

		public bool Contains<TContext, TArg1, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TResult) }, key);
			return _dictionary.ContainsKey(id);
		}

		public bool Contains<TContext, TArg1, TArg2, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TResult) }, key);
			return _dictionary.ContainsKey(id);
		}

		public bool Contains<TContext, TArg1, TArg2, TArg3, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TResult) }, key);
			return _dictionary.ContainsKey(id);
		}

		public bool Contains<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TResult) }, key);
			return _dictionary.ContainsKey(id);
		}

		public bool Contains<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TResult) }, key);
			return _dictionary.ContainsKey(id);
		}

		public Func<TContext, TResult> Get<TContext, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TResult) }, key);

			if (_dictionary.ContainsKey(id))
				return (Func<TContext, TResult>)_dictionary[id];
			else
				return null;
		}

		public Func<TContext, TArg1, TResult> Get<TContext, TArg1, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TResult) }, key);
			
			if (_dictionary.ContainsKey(id))
				return (Func<TContext, TArg1, TResult>)_dictionary[id];
			else
				return null;
		}

		public Func<TContext, TArg1, TArg2, TResult> Get<TContext, TArg1, TArg2, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TResult) }, key);
			
			if (_dictionary.ContainsKey(id))
				return (Func<TContext, TArg1, TArg2, TResult>)_dictionary[id];
			else
				return null;
		}

		public Func<TContext, TArg1, TArg2, TArg3, TResult> Get<TContext, TArg1, TArg2, TArg3, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TResult) }, key);
			
			if (_dictionary.ContainsKey(id))
				return (Func<TContext, TArg1, TArg2, TArg3, TResult>)_dictionary[id];
			else
				return null;
		}

		public Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult> Get<TContext, TArg1, TArg2, TArg3, TArg4, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TResult) }, key);

			if (_dictionary.ContainsKey(id))
				return (Func<TContext, TArg1, TArg2, TArg3, TArg4, TResult>)_dictionary[id];
			else
				return null;
		}

		public Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Get<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(string key = null) where TContext : System.Data.Linq.DataContext
		{
			var id = GetID(new Type[] { typeof(TContext), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5), typeof(TResult) }, key);

			if (_dictionary.ContainsKey(id))
				return (Func<TContext, TArg1, TArg2, TArg3, TArg4, TArg5, TResult>)_dictionary[id];
			else
				return null;
		}

		private string GetID(Type[] types, string key)
		{
			string output = "";

			foreach (var type in types)
			{
				output += "_" + type.Name;
			}

			return (output += "_" + ((key != null) ? key : ""));
		}

		#endregion
	}
}
