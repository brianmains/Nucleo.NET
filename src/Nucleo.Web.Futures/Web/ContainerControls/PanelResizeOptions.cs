using System;
using System.Collections.Generic;


namespace Nucleo.Web.ContainerControls
{
	/// <summary>
	/// Represents the resizing options for the panel.
	/// </summary>
	public class PanelResizeOptions : JsonSerializableObject
	{
		#region " Properties "

		/// <summary>
		/// Gets or sets whether to cap the height of the panel to a specific size.  Only if the panel grows beyond the size will it cap it.
		/// </summary>
		public bool AutoCapHeight
		{
			get { return base.GetValue<bool>("autoCapHeight", false); }
			set { base.AddOrUpdateValue("autoCapHeight", value); }
		}

		/// <summary>
		/// Gets or sets the maximum number of pixels in height to cap.
		/// </summary>
		public int MaxHeight
		{
			get { return base.GetValue<int>("maxHeight", 0); }
			set { base.AddOrUpdateValue("maxHeight", value); }
		}

		public int MaxWidth
		{
			get { return base.GetValue<int>("maxWidth", 0); }
			set { base.AddOrUpdateValue("maxWidth", value); }
		}

		public int MinHeight
		{
			get { return base.GetValue<int>("minHeight", 0); }
			set { base.AddOrUpdateValue("minHeight", value); }
		}

		public int MinWidth
		{
			get { return base.GetValue<int>("minWidth", 0); }
			set { base.AddOrUpdateValue("minWidth", value); }
		}

		#endregion
	}
}
