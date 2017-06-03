using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.Web.Mvc.ButtonControls
{
	public class ButtonSettings : SettingsDictionary
	{
		#region " Properties "

		public bool DisableOnFirstClick
		{
			get { return this.GetSetting<bool>("DisableOnFirstClick"); }
			set { this.AddSetting("DisableOnFirstClick", value); }
		}

		public int DisableOnFirstClickTimeout
		{
			get { return this.GetSetting<int>("DisableOnFirstClickTimeout"); }
			set { this.AddSetting("DisableOnFirstClickTimeout", value); }
		}

		public bool DisableUntilPageLoad
		{
			get { return this.GetSetting<bool>("DisableUntilPageLoad"); }
			set { this.AddSetting("DisableUntilPageLoad", value); }
		}

		#endregion
	}
}
