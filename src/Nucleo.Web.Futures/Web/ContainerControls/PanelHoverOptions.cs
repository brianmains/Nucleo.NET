using System;
using System.ComponentModel;
using System.Collections.Generic;


namespace Nucleo.Web.ContainerControls
{
	/// <summary>
	/// Represents the options for the panel when the mouse mouses over another control.
	/// </summary>
	public class PanelHoverOptions : JsonSerializableObject
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets the timeout for the close operation.
		/// </summary>
		public int CloseTimeout
		{
			get { return base.GetValue<int>("closeTimeout"); }
			set { base.AddOrUpdateValue("closeTimeout", value); }
		}

		/// <summary>
		/// Gets or sets ID of the control that the panel will appear.
		/// </summary>
		public string ControlID
		{
			get { return base.GetValue<string>("controlID"); }
			set { base.AddOrUpdateValue("controlID", value); }
		}

		/// <summary>
		/// Gets or sets whether the panel will relocate to around the control.
		/// </summary>
		public bool RelocatePanel
		{
			get { return base.GetValue<bool>("relocatePanel", false); }
			set { base.AddOrUpdateValue("relocatePanel", value); }
		}

		/// <summary>
		/// Gets or sets the value to place the panel when <see cref="RelocatePanel">RelocatePanel equals true</see>.
		/// </summary>
		public PanelPosition RelocatePosition
		{
			get { return base.GetValue<PanelPosition>("relocatePosition"); }
			set { base.AddOrUpdateValue("relocatePosition", value); }
		}

		#endregion
	}
}
