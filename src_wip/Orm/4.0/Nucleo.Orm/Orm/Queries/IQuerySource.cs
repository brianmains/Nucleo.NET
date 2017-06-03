using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Orm.Queries
{
	public interface IQuerySource<TEntity> : IQueryable<TEntity>
		where TEntity: class
	{
		IUnitOfWork Container { get; }
	}
}
