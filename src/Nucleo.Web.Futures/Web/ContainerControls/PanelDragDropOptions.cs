using System;
using System.ComponentModel;
using System.Web.UI;

using Nucleo.Web.ContainerControls.ClientSettings;


namespace Nucleo.Web.ContainerControls
{
	public class PanelDragDropOptions : JsonSerializableObject
	{
		#region " Properties "

		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public PanelDraggingClientEvents ClientEvents
		{
			get { return base.GetValue<PanelDraggingClientEvents>("clientEvents"); }
			set { base.AddOrUpdateValue("clientEvents", value); }
		}

		[
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		PersistenceMode(PersistenceMode.InnerProperty),
		MergableProperty(false)
		]
		public DragDropPanelOperation Operation
		{
			get { return base.GetValue<DragDropPanelOperation>("operation"); }
			set { base.AddOrUpdateValue("operation", value); }
		}

		#endregion
	}
}
