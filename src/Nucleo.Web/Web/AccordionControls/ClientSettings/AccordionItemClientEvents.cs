using System;

using Nucleo.Web;


namespace Nucleo.Web.AccordionControls.ClientSettings
{
	public class AccordionItemClientEvents : IScriptComponent
	{
		private string _onClientClosed = null;
		private string _onClientOpened = null;
		private string _onClientSelected = null;



		#region " Constants "

		public const string ClosedEventName = "closed";
		public const string OpenedEventName = "opened";
		public const string SelectedEventName = "selected";

		#endregion



		#region " Properties "

		public string OnClientClosed
		{
			get { return _onClientClosed; }
			set { _onClientClosed = value; }
		}

		public string OnClientOpened
		{
			get { return _onClientOpened; }
			set { _onClientOpened = value; }
		}

		public string OnClientSelected
		{
			get { return _onClientSelected; }
			set { _onClientSelected = value; }
		}

		#endregion



		#region " Methods "

		public void RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddEventIfExists("closed", _onClientClosed);
			currentDescriptor.AddEventIfExists("opened", _onClientOpened);
			currentDescriptor.AddEventIfExists("selected", _onClientSelected);
		}

		public void RegisterAjaxReferences(IContentRegistrar registrar)
		{
			
		}

		#endregion
	}
}
