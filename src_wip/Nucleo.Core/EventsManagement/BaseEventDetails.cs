using System;
using System.Collections.Generic;

using Nucleo.EventsManagement.Listeners;


namespace Nucleo.EventsManagement
{
	public abstract class BaseEventDetails
	{
		
		private IListenerCriteria _criteria = null;



		#region " Properties "

		/// <summary>
		/// Gets the listener criteria.
		/// </summary>
		public IListenerCriteria Criteria
		{
			get { return _criteria; }
		}

		#endregion



		#region " Constructors "

		public BaseEventDetails(IListenerCriteria criteria)
		{
			if (criteria == null)
				throw new ArgumentNullException("criteria");

			_criteria = criteria;
		}

		#endregion
	}
}
