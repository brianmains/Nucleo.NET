using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Nucleo.Models;


namespace Nucleo.Models.NucleoActions
{
	public class ThirdPartialViewModel : BaseModel
	{
		#region " Properties "

		public string Name
		{
			get { return base.GetValue<string>("Name"); }
			set { base.AddOrUpdateValue("Name", value); }
		}

		#endregion
	}
}
