using System;
using System.Collections.Generic;


namespace Nucleo.Services
{
	public class InMemorySessionStateService : BaseCollectionService, ISessionStateService
	{
		#region " Properties "

		public string UniqueKey
		{
			get { return ""; }
		}

		#endregion



		#region " Methods "

		public void Clear()
		{
			this.Items.Clear();
		}

		#endregion
	}
}
