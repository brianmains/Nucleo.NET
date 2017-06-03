using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Orm.Caching
{
	/// <summary>
	/// Responsible for caching the unit of work.
	/// </summary>
	public interface IUnitOfWorkCaching
	{
		/// <summary>
		/// Gets the unit of work out of the cache.
		/// </summary>
		/// <param name="name">The name of the unit of work.</param>
		/// <returns>The unit of work.</returns>
		IUnitOfWork GetUnitOfWork(string name);

		/// <summary>
		/// Saves the unit of work.
		/// </summary>
		/// <param name="name">The name of the unit of work.</param>
		/// <param name="uow">The unit of work.</param>
		void SaveUnitOfWork(string name, IUnitOfWork uow);
	}
}
