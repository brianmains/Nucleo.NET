

namespace Nucleo.Web.ClientSettings
{
	/// <summary>
	/// Represents the client-side events that can be fired for an AJAX component.
	/// </summary>
	public class ClientEvents : IScriptComponent
	{
		private string _onclientClicked = null;
		private string _onClientDoubleClicked = null;
		private string _onClientGotFocus = null;
		private string _onClientKeyAfterPress = null;
		private string _onClientKeyBeforePress = null;
		private string _onClientKeyPressed = null;
		private string _onClientLostFocus = null;
		private string _onClientMousedDown = null;
		private string _onClientMousedOut = null;
		private string _onClientMousedOver = null;
		private string _onClientMousedUp = null;
		private string _onClientMouseMove = null;



		#region " Constants "

		public const string ClickedEventName = "clicked";
		public const string DoubleClickedEventName = "doubleClicked";
		public const string GotFocusEventName = "gotFocus";
		public const string KeyAfterPressEventName = "keyAfterPress";
		public const string KeyBeforePressEventName = "keyBeforePress";
		public const string KeyPressedEventName = "keyPressed";
		public const string LostFocusEventName = "lostFocus";
		public const string MousedDownEventName = "mousedDown";
		public const string MousedOutEventName = "mousedOut";
		public const string MousedOverEventName = "mousedOver";
		public const string MousedUpEventName = "mousedUp";
		public const string MouseMoveEventName = "mouseMove";

		#endregion



		#region " Properties "

		/// <summary>
		/// Gets or sets the method to fire for the client-side click event.
		/// </summary>
		public string OnClientClicked
		{
			get { return _onclientClicked; }
			set { _onclientClicked = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side double click event.
		/// </summary>
		public string OnClientDoubleClicked
		{
			get { return _onClientDoubleClicked; }
			set { _onClientDoubleClicked = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side focus received event.
		/// </summary>
		public string OnClientGotFocus
		{
			get { return _onClientGotFocus; }
			set { _onClientGotFocus = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side key after press event.
		/// </summary>
		public string OnClientKeyAfterPress
		{
			get { return _onClientKeyAfterPress; }
			set { _onClientKeyAfterPress = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side key before press event.
		/// </summary>
		public string OnClientKeyBeforePress
		{
			get { return _onClientKeyBeforePress; }
			set { _onClientKeyBeforePress = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side key press event.
		/// </summary>
		public string OnClientKeyPressed
		{
			get { return _onClientKeyPressed; }
			set { _onClientKeyPressed = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side lost focus event.
		/// </summary>
		public string OnClientLostFocus
		{
			get { return _onClientLostFocus; }
			set { _onClientLostFocus = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side mouse down event.
		/// </summary>
		public string OnClientMousedDown
		{
			get { return _onClientMousedDown; }
			set { _onClientMousedDown = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side mouse out event.
		/// </summary>
		public string OnClientMousedOut
		{
			get { return _onClientMousedOut; }
			set { _onClientMousedOut = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side mouse over event.
		/// </summary>
		public string OnClientMousedOver
		{
			get { return _onClientMousedOver; }
			set { _onClientMousedOver = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side mouse up event.
		/// </summary>
		public string OnClientMousedUp
		{
			get { return _onClientMousedUp; }
			set { _onClientMousedUp = value; }
		}

		/// <summary>
		/// Gets or sets the method to fire for the client-side mouse move event.
		/// </summary>
		public string OnClientMouseMove
		{
			get { return _onClientMouseMove; }
			set { _onClientMouseMove = value; }
		}

		#endregion



		#region " Methods "

		void IScriptComponent.RegisterAjaxDescriptors(IContentRegistrar registrar, IDescriptor currentDescriptor)
		{
			currentDescriptor.AddEventIfExists(ClickedEventName, this.OnClientClicked);
			currentDescriptor.AddEventIfExists(DoubleClickedEventName, this.OnClientDoubleClicked);
			currentDescriptor.AddEventIfExists(GotFocusEventName, this.OnClientGotFocus);
			currentDescriptor.AddEventIfExists(KeyAfterPressEventName, this.OnClientKeyAfterPress);
			currentDescriptor.AddEventIfExists(KeyBeforePressEventName, this.OnClientKeyBeforePress);
			currentDescriptor.AddEventIfExists(KeyPressedEventName, this.OnClientKeyPressed);
			currentDescriptor.AddEventIfExists(LostFocusEventName, this.OnClientLostFocus);
			currentDescriptor.AddEventIfExists(MousedDownEventName, this.OnClientMousedDown);
			currentDescriptor.AddEventIfExists(MousedOutEventName, this.OnClientMousedOut);
			currentDescriptor.AddEventIfExists(MousedOverEventName, this.OnClientMousedOver);
			currentDescriptor.AddEventIfExists(MousedUpEventName, this.OnClientMousedUp);
			currentDescriptor.AddEventIfExists(MouseMoveEventName, this.OnClientMouseMove);
		}

		void IScriptComponent.RegisterAjaxReferences(IContentRegistrar registrar)
		{

		}

		#endregion
	}
}
