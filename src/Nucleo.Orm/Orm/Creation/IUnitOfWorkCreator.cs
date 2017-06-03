using System;
using System.Collections;


namespace Nucleo.Orm.Creation
{
	/// <summary>
	/// Represents the object that creates an individual unit of work.
	/// </summary>
	public interface IUnitOfWorkCreator
	{
		#region " Methods "

		/// <summary>
		/// Creates a unit of work based upon the given unit of work type, in addition to any additional parameters passed in.
		/// </summary>
		/// <param name="unitOfWorkType">The type of unit of work.</param>
		/// <param name="attributes">The collection of attributed passed along.</param>
		/// <returns>The created unit of work.</returns>
		IUnitOfWork Create(Type unitOfWorkType, IDictionary attributes);

		#endregion
	}
}
