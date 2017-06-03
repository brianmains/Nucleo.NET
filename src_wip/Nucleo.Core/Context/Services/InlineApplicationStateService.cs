using System;
using System.Collections.Generic;


namespace Nucleo.Context.Services
{
	public class InlineApplicationStateService : BaseInlineServiceDictionary, IApplicationStateService
	{
		#region " Methods "

		public void Clear()
		{
			this.Items.Clear();
		}

		#endregion
	}
}
