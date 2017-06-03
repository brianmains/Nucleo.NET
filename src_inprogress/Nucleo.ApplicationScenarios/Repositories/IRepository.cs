using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.Repositories
{
	public interface IRepository : IBaseRepository
	{
		void CreateNew(object entity);

		object Get(object identifier);

		void Remove(object entity);

		void Update(object entity);
	}
}
