using System;
using System.Linq;
using System.Data.Linq;

using Nucleo.Orm.DataClasses;
using Nucleo.Orm.DataClasses.Queries;


namespace Nucleo.Orm.DataClasses.Legacy
{
	/// <summary>
	/// Represents the unit of work for data context tables.
	/// </summary>
	/// <typeparam name="TEntity">The entity type that the table represents.</typeparam>
	public class TableUnitOfWork<TEntity> : TableEntityUnitOfWork<TEntity>, ITableUnitOfWork<TEntity>
		where TEntity : class
	{
		/// <summary>
		/// Gets the reference to the data context.
		/// </summary>
		public DataContext Context
		{
			get { return base.Table.Context; }
		}



		#region " Constructors "

		public TableUnitOfWork(Table<TEntity> table)
			: base(table) { }

		#endregion



		#region " Methods "

		/// <summary>
		/// Queries the object set and returns an anonymous result.
		/// </summary>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		public IQueryable Query(Func<Table<TEntity>, IQueryable> source)
		{
			return source(this.Table);
		}

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		public IQueryable<TEntity> Query(Func<Table<TEntity>, IQueryable<TEntity>> source)
		{
			return source(this.Table);
		}

		/// <summary>
		/// Queries the object set and returns an anonymous result.
		/// </summary>
		/// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		public IQueryable Query<TUnitOfWork>(Func<Table<TEntity>, TUnitOfWork, IQueryable> source)
			where TUnitOfWork : IUnitOfWork
		{
			TUnitOfWork uow = default(TUnitOfWork);
			if (this.Table is TUnitOfWork)
				uow = (TUnitOfWork)((object)this.Table);
			else if (this.Table.Context is TUnitOfWork)
				uow = (TUnitOfWork)((object)this.Table.Context);

			return source(this.Table, uow);
		}

		/// <summary>
		/// Queries the object set.
		/// </summary>
		/// <typeparam name="TUnitOfWork">The type of unit of work.</typeparam>
		/// <param name="source">The source lambda.</param>
		/// <returns>The query.</returns>
		public IQueryable<TEntity> Query<TUnitOfWork>(Func<Table<TEntity>, TUnitOfWork, IQueryable<TEntity>> source)
			where TUnitOfWork : IUnitOfWork
		{
			TUnitOfWork uow = default(TUnitOfWork);
			if (this.Table is TUnitOfWork)
				uow = (TUnitOfWork)((object)this.Table);
			else if (this.Table.Context is TUnitOfWork)
				uow = (TUnitOfWork)((object)this.Table.Context);

			return source(this.Table, uow);
		}

		#endregion
	}
}
