using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;

using Nucleo.Orm.Entities;


namespace Nucleo.Lookups.Repositories
{
	/// <summary>
	/// Represents the repository that serves data from an object set.
	/// </summary>
	/// <remarks>In most scenarios, this process will need to be customized.  To customize, create a subclass and override the <see cref="CreateLookupItem"/> method to create the individual record.</remarks>
	public class ObjectSetLookupRepository : ILookupRepository
	{
		private dynamic _objectSet = null;



		/// <summary>
		/// Creates the lookup repository with an object set, in dynamic form.  This will make it easier to work with the object set, since it's a generic class and requires the specific type.
		/// </summary>
		/// <param name="objectSet">The object set to work with.</param>
		public ObjectSetLookupRepository(dynamic objectSet)
		{
			_objectSet = objectSet;
		}




		/// <summary>
		/// Creates the lookup item.
		/// </summary>
		/// <param name="dataSourceItem">The item source, assuming it has the same fields as the type <see cref="ILookup"/>, which is Name, Value, and RepresentationCode.  Override this method to provide the individual specifics.</param>
		/// <returns></returns>
		protected virtual ILookup CreateLookupItem(dynamic dataSourceItem)
		{
			return new Lookup(dataSourceItem.Name, dataSourceItem.Value, dataSourceItem.RepresentationCode);
		}

		/// <summary>
		/// Gets the values, assuming the LINQ object passed in uses the same name.
		/// </summary>
		/// <param name="criteria">The criteria.</param>
		/// <returns>The collection.</returns>
		public virtual LookupCollection GetAllValues(LookupCriteria criteria)
		{
			var list = new LookupCollection();

			foreach (var result in _objectSet)
				list.Add(this.CreateLookupItem(result));

			return list;
		}
	}
}
