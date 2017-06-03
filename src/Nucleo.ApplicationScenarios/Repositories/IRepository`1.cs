using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Repositories
{
	public interface IRepository<TEntity> : IBaseRepository
		where TEntity: class
	{
		void CreateNew(TEntity entity);

		TEntity Get(object identifier);

		void Remove(TEntity entity);

		void Update(TEntity entity);
	}
}
