using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nucleo.Web.Validation
{
	public partial class NeedValuesClientEvent : Nucleo.Framework.TestPage
	{
		#region " Properties "

		protected override string Description
		{
			get
			{
				return "The client-side needValues event can be used to provide values to the validator control.  This may be for a variety of reasons; the validator can't find the underlying value, the validator can't inspect its contents, or the validated control was not specified (it's optional).  In these cases, the client-side needValues event fires and lets the caller interpret the values.";
			}
		}

		#endregion
	}
}