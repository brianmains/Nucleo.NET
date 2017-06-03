using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Orm;
using Nucleo.Orm.Entities;


namespace Nucleo.Code.Data.Entities
{
	public partial class AdventureWorksObjectContext : IObjectContext, IUnitOfWork
	{
		void IUnitOfWork.SaveChanges()
		{
			this.SaveChanges();
		}
	}
}