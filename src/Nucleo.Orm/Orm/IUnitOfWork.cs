using System;
using System.Linq;


namespace Nucleo.Orm
{
	/// <summary>
	/// Represents a unit of work.
	/// </summary>
	public interface IUnitOfWork
	{
		#region " Methods "

		/// <summary>
		/// Saves the changes to the unit of work.
		/// </summary>
		void SaveChanges();

		#endregion
	}
}
