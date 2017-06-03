using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Mvc.ButtonControls
{
	public class ButtonViewOptions
	{
		#region " Properties "

		public Command Command
		{
			get;
			set;
		}

		public string OnClientClick
		{
			get;
			set;
		}

		public bool PostBackAlways
		{
			get;
			set;
		}

		public string PostBackUrl
		{
			get;
			set;
		}

		public string ValidationGroup
		{
			get;
			set;
		}

		public string VisibilityGroup
		{
			get;
			set;
		}

		#endregion
	}
}
