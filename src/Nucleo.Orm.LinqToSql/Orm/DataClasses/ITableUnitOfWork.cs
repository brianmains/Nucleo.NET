using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;


namespace Nucleo.Orm.DataClasses
{
	public interface ITableUnitOfWork<TEntity> : IEntityUnitOfWork<TEntity>
		where TEntity: class
	{

	}
}
