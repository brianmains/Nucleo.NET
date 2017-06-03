using System;


namespace Nucleo.Web.ContainerControls.ClientSettings
{
	public class PanelDraggingClientEvents : JsonSerializableObject, IScriptComponent
	{
		#region " Constants "

		public const string DragEndingEventName = "dragEnding";
		public const string DragStartingEventName = "dragStarting";
		public const string DroppedEventName = "dropped";

		#endregion



		#region " Properties "

		public string OnClientDragEnding
		{
			get { return base.GetValue<string>("onClientDragEnding"); }
			set { base.AddOrUpdateValue("onClientDragEnding", value); }
		}

		public string OnClientDragStarting
		{
			get { return base.GetValue<string>("onClientDragStarting"); }
			set { base.AddOrUpdateValue("onClientDragStarting", value); }
		}

		public string OnClientDropped
		{
			get { return base.GetValue<string>("onClientDropped"); }
			set { base.AddOrUpdateValue("onClientDropped", value); }
		}

		#endregion



		#region IScriptComponent Members

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddEventIfExists(DragEndingEventName, this.OnClientDragEnding);
			currentDescriptor.AddEventIfExists(DragStartingEventName, this.OnClientDragStarting);
			currentDescriptor.AddEventIfExists(DroppedEventName, this.OnClientDropped);
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}
