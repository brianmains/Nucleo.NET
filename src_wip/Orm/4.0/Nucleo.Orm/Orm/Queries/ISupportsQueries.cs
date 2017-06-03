using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Orm.Queries
{
	public interface ISupportsQueries<TEntity>
		where TEntity : class
	{
		QueryProvider<TEntity> Queries();			
	}
}
