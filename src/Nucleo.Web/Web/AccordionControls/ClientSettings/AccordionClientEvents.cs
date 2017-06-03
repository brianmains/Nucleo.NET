using System;
using Nucleo.Web;


namespace Nucleo.Web.AccordionControls.ClientSettings
{
	public class AccordionClientEvents : IScriptComponent
	{
		private string _onClientItemClosed = null;
		private string _onClientItemClosing = null;
		private string _onClientItemOpened = null;
		private string _onClientItemOpening = null;



		#region " Constants "

		public const string ItemClosedEventName = "itemClosed";
		public const string ItemClosingEventName = "itemClosing";
		public const string ItemOpenedEventName = "itemOpened";
		public const string ItemOpeningEventName = "itemOpening";

		#endregion



		#region " Properties "

		public string OnClientItemClosed
		{
			get { return _onClientItemClosed; }
			set { _onClientItemClosed = value; }
		}

		public string OnClientItemClosing
		{
			get { return _onClientItemClosing; }
			set { _onClientItemClosing = value; }
		}

		public string OnClientItemOpened
		{
			get { return _onClientItemOpened; }
			set { _onClientItemOpened = value; }
		}

		public string OnClientItemOpening
		{
			get { return _onClientItemOpening; }
			set { _onClientItemOpening = value; }
		}

		#endregion



		#region " Methods "

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddEventIfExists(ItemClosedEventName, _onClientItemClosed);
			currentDescriptor.AddEventIfExists(ItemClosingEventName, _onClientItemClosing);
			currentDescriptor.AddEventIfExists(ItemOpenedEventName, _onClientItemOpened);
			currentDescriptor.AddEventIfExists(ItemOpeningEventName, _onClientItemOpening);
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}
