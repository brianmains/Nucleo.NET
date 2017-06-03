using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;

using Nucleo.Orm.Queries;
using Nucleo.Orm.DataClasses.Queries;


namespace Nucleo.Orm.DataClasses
{
	/// <summary>
	/// Represents the unit of work that manages a table entity.
	/// </summary>
	/// <typeparam name="TEntity">The entity type.</typeparam>
	public class TableEntityUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>, ISupportsQueries<TEntity>
		where TEntity: class
	{
		private Table<TEntity> _table = null;



		#region " Properties "

		protected internal Table<TEntity> Table
		{
			get { return _table; }
		}

		#endregion



		#region " Constructors "

		public TableEntityUnitOfWork(Table<TEntity> table)
		{
			_table = table;
		}

		#endregion



		#region " Methods "

		public virtual TEntity CreateNew()
		{
			return Activator.CreateInstance<TEntity>();
		}

		public virtual TEntity Get(object identifier)
		{
			var itemParameter = Expression.Parameter(typeof(TEntity), "item");
			var pkName = this.GetPrimaryKeyName<TEntity>();
			if (pkName == null)
				return null;

			var whereExpression = Expression.Lambda<Func<TEntity, bool>>
				(
				Expression.Equal(
					Expression.Property(itemParameter, pkName),
					Expression.Constant(identifier)
					),
				new[] { itemParameter }
				);

			return _table.Where(whereExpression).FirstOrDefault();
		}

		private string GetPrimaryKeyName<T>()
		{
			var type = _table.Context.Mapping.GetMetaType(typeof(T));

			var PK = (from m in type.DataMembers
					  where m.IsPrimaryKey
					  select m).FirstOrDefault();
			return (PK != null) ? PK.Name : null;
		}

		public QueryProvider<TEntity> Queries()
		{
			return new QueryProvider<TEntity>(new TableQuerySource<TEntity>(_table));
		}

		public virtual void QueueDelete(TEntity entity)
		{
			_table.DeleteOnSubmit(entity);
		}

		public virtual void QueueInsert(TEntity entity)
		{
			_table.InsertOnSubmit(entity);
		}

		public virtual void QueueUpdate(TEntity entity)
		{
			var original = _table.GetOriginalEntityState(entity);
			//If not attached to the table, attach it
			if (original == null)
				_table.Attach(entity);
		}

		public virtual void SaveChanges()
		{
			_table.Context.SubmitChanges();
		}

		#endregion
	}
}
