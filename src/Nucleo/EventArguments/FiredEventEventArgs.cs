using System;
using System.Collections.Generic;

using Nucleo.EventsManagement;


namespace Nucleo.EventArguments
{
	public class FiredEventEventArgs
	{
		private IEventSubscription _subscription = null;



		#region " Properties "

		public IEventSubscription Subscription
		{
			get { return _subscription; }
		}

		#endregion



		#region " Constructors "

		public FiredEventEventArgs(IEventSubscription subscription)
		{
			_subscription = subscription;
		}

		#endregion
	}


	public delegate void FiredEventEventHandler(object sender, FiredEventEventArgs e);
}
