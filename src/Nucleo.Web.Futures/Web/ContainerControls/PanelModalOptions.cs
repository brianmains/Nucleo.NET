using System;
using System.Collections.Generic;


namespace Nucleo.Web.ContainerControls
{
	public class PanelModalOptions : JsonSerializableObject
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets whether the panel is open; this will open the panel on initial load.
		/// </summary>
		public bool IsOpen
		{
			get { return base.GetValue<bool>("isOpen"); }
			set { base.AddOrUpdateValue("isOpen", value); }
		}

		/// <summary>
		/// Gets or sets an ID of the OK button.
		/// </summary>
		public string OKButtonID
		{
			get { return base.GetValue<string>("okButtonID"); }
			set { base.AddOrUpdateValue("okButtonID", value); }
		}

		#endregion
	}
}
