using System;
using System.Collections.Generic;
using System.Linq;

using Nucleo.Web.ClientState;
using Nucleo.Web.Styles;


namespace Nucleo.Web.Mvc
{
	public abstract class BaseMvcComponent
	{
		private ClientStateDictionary _clientState = null;
		private string _name = null;



		#region " Properties "

		/// <summary>
		/// Gets the client state for the control.
		/// </summary>
		protected internal ClientStateDictionary ClientState
		{
			get
			{
				if (_clientState == null)
					_clientState = new ClientStateDictionary();
				return _clientState;
			}
			internal set
			{
				_clientState = value;
			}
		}

		/// <summary>
		/// Gets whether the component has any client state set.
		/// </summary>
		protected internal bool HasClientState
		{
			get { return (_clientState != null); }
		}

		/// <summary>
		/// Gets or sets the name of the component; this is used for the rendering process.
		/// </summary>
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		#endregion



		#region " Methods "

		/// <summary>
		/// Initializes the component.
		/// </summary>
		protected internal virtual void Initialize() { }

		#endregion
	}
}
