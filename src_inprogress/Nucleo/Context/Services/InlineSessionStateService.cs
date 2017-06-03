using System;
using System.Collections.Generic;


namespace Nucleo.Context.Services
{
	public class InlineSessionStateService : BaseInlineServiceDictionary, ISessionStateService
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
