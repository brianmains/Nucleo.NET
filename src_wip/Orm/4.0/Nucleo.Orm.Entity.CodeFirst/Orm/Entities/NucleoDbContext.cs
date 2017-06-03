using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;

using System.Data.Objects;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;



namespace Nucleo.Orm.Entities
{
	public class NucleoDbContext : DbContext, IDbContext 
	{
		public NucleoDbContext()
			: base() { }

		public NucleoDbContext(string nameOrConnectionString)
			: base(nameOrConnectionString) { }

		public NucleoDbContext(DbCompiledModel model)
			: base(model) { }

		public NucleoDbContext(string nameOrConnectionString, DbCompiledModel model)
			: base(nameOrConnectionString, model) { }

		public NucleoDbContext(DbConnection connection, bool contextOwnsConnection)
			: base(connection, contextOwnsConnection) { }

		public NucleoDbContext(ObjectContext context, bool dbContextOwnsConnection)
			: base(context, dbContextOwnsConnection) { }

		public NucleoDbContext(DbConnection connection, DbCompiledModel model, bool dbContextOwnsConnection)
			: base(connection, model, dbContextOwnsConnection) { }
	}
}
