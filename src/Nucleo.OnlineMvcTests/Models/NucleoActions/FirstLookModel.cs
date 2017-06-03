using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nucleo.Models;


namespace Nucleo.Models.NucleoActions
{
	public class FirstLookModel : BaseModel
	{
		#region " Properties "

		public FirstPartialModel FirstPartial
		{
			get { return base.GetValue<FirstPartialModel>("FirstPartial"); }
			set { base.AddOrUpdateValue("FirstPartial", value); }
		}

		public FirstPartialModel FirstPartialLookupTest
		{
			get { return base.GetValue<FirstPartialModel>("FirstPartialLookupTest"); }
			set { base.AddOrUpdateValue("FirstPartialLookupTest", value); }
		}

		public SecondPartial SecondPartial
		{
			get { return base.GetValue<SecondPartial>("SecondPartial"); }
			set { base.AddOrUpdateValue("SecondPartial", value); }
		}

		public ThirdPartialViewModel ThirdPartial
		{
			get { return base.GetValue<ThirdPartialViewModel>("ThirdPartial"); }
			set { base.AddOrUpdateValue("ThirdPartial", value); }
		}

		#endregion
	}
}
