using System;
using System.Collections.Generic;


namespace Nucleo.Services
{
	public class InMemoryApplicationStateService : BaseCollectionService, IApplicationStateService
	{
		#region " Methods "

		public void Clear()
		{
			this.Items.Clear();
		}

		#endregion
	}
}
