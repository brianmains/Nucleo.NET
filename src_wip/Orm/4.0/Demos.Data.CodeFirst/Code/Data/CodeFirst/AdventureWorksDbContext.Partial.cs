using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Orm;


namespace Nucleo.Code.Data.CodeFirst
{
	public partial class AdventureWorksDbContext : IUnitOfWork
	{
		public AdventureWorksDbContext(string nameOrConnectionString)
			: base(nameOrConnectionString) { }



		void IUnitOfWork.SaveChanges()
		{
			this.SaveChanges();
		}
	}
}