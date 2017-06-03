using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;

using Nucleo.Orm.DataClasses.Queries;


namespace Nucleo.Orm.DataClasses
{
	public interface ITableUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>
		where TEntity: class
	{
		/// <summary>
		/// Gets the reference to the data context.
		/// </summary>
		DataContext Context { get; }
	}
}
