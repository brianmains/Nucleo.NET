using System;
using System.Data.Objects;
using System.Data.EntityClient;
using System.Configuration;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// A custom object context that implements the unit of work interface. Typically, this would be good for the object context generators.
	/// </summary>
	public class NucleoObjectContext : ObjectContext, IObjectContext, IUnitOfWork
	{
		#region " Constructors "

		public NucleoObjectContext(string connectionString)
			: base(connectionString) { }

		public NucleoObjectContext(string connectionString, string defaultContainerName)
			: base(connectionString, defaultContainerName) { }

		public NucleoObjectContext(EntityConnection connection)
			: base(connection) { }

		public NucleoObjectContext(EntityConnection connection, string defaultContainerName)
			: base(connection, defaultContainerName) { }

		#endregion



		#region " Methods "

		void IUnitOfWork.SaveChanges()
		{
			this.SaveChanges();
		}

		#endregion
	}
}
