using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;


namespace Nucleo.Orm.DataClasses
{
	/// <summary>
	/// Represents the base class for the nucleo data context, a wrapper around the data context that implements <see cref="IDataContext"/> and <see cref="IUnitOfWork"/>.
	/// </summary>
	public class NucleoDataContext : DataContext, IDataContext, IUnitOfWork
	{
		#region " Constructors "

		/// <summary>
		/// Creates the data context with the established DB connection.
		/// </summary>
		/// <param name="connection">The database connection.</param>
		public NucleoDataContext(IDbConnection connection)
			: base(connection) { }
		//
		// Summary:
		//     Initializes a new instance of the System.Data.Linq.DataContext class by referencing
		//     a file source.
		//
		// Parameters:
		//   fileOrServerOrConnection:
		//     This argument can be any one of the following:The name of a file where a
		//     SQL Server Express database resides.The name of a server where a database
		//     is present. In this case the provider uses the default database for a user.A
		//     complete connection string. LINQ to SQL just passes the string to the provider
		//     without modification.
		public NucleoDataContext(string fileOrServerOrConnection)
			: base(fileOrServerOrConnection) { }
		//
		// Summary:
		//     Initializes a new instance of the System.Data.Linq.DataContext class by referencing
		//     a connection and a mapping source.
		//
		// Parameters:
		//   connection:
		//     The connection used by the .NET Framework.
		//
		//   mapping:
		//     The System.Data.Linq.Mapping.MappingSource.
		public NucleoDataContext(IDbConnection connection, MappingSource mapping)
			: base(connection, mapping) { }
		//
		// Summary:
		//     Initializes a new instance of the System.Data.Linq.DataContext class by referencing
		//     a file source and a mapping source.
		//
		// Parameters:
		//   fileOrServerOrConnection:
		//     This argument can be any one of the following:The name of a file where a
		//     SQL Server Express database resides.The name of a server where a database
		//     is present. In this case the provider uses the default database for a user.A
		//     complete connection string. LINQ to SQL just passes the string to the provider
		//     without modification.
		//
		//   mapping:
		//     The System.Data.Linq.Mapping.MappingSource.
		public NucleoDataContext(string fileOrServerOrConnection, MappingSource mapping)
			: base(fileOrServerOrConnection, mapping) { }

		#endregion




		#region " Methods "

		void IUnitOfWork.SaveChanges()
		{
			base.SubmitChanges();
		}

		#endregion
	}
}
