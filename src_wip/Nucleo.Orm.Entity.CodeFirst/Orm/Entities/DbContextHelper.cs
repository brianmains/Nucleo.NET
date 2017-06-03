using System;
using System.Configuration;
using System.Data.Entity;


namespace Nucleo.Orm.Entities
{
	/// <summary>
	/// Helper class for the object context; helps control the instantiation of the class.
	/// </summary>
	public static class DbContextHelper
	{
		#region " Methods "

		/// <summary>
		/// Creates a new context using the connection string.
		/// </summary>
		/// <typeparam name="TContext">The context.</typeparam>
		/// <param name="connectionString">The connection string value or the name.</param>
		/// <param name="isConnectionStringName">Whether the connection string is a name.</param>
		/// <returns>The instantiated <see cref="ObjectContext"/> instance.</returns>
		public static TContext Create<TContext>(string connectionString, bool isConnectionStringName)
			where TContext : DbContext
		{
			return (TContext)Activator.CreateInstance(typeof(TContext),
				new object[] { isConnectionStringName 
					? ConfigurationManager.ConnectionStrings[connectionString].ConnectionString
					: connectionString });
		}

		#endregion
	}
}
