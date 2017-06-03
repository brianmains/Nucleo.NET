using System;
using System.Web.UI;
using System.Diagnostics;


namespace Nucleo.Web
{
	[DebuggerDisplay("Client Type: {ClientType}, ID: {TargetID}")]
	public sealed class ScriptDescriptionRequestDetails
	{
		private string _clientType = null;
		private Control _controlReference = null;
		private Type _requestObjectType = null;
		private string _targetID = null;



		#region " Properties "

		public string ClientType
		{
			get
			{
				if (!string.IsNullOrEmpty(_clientType))
					return _clientType;
				else
					return this.ControlReference.GetType().FullName;
			}
		}

		public Control ControlReference
		{
			get { return _controlReference; }
		}

		public Type RequestObjectType
		{
			get { return _requestObjectType; }
		}

		public string TargetID
		{
			get { return _targetID; }
		}

		#endregion



		#region " Constructors "

		public ScriptDescriptionRequestDetails(Control controlReference, string clientType, Type requestObjectType, string targetID)
			: this(controlReference, requestObjectType, targetID)
		{
			_clientType = clientType;
		}

		public ScriptDescriptionRequestDetails(Control controlReference, Type requestObjectType, string targetID)
		{
			_controlReference = controlReference;
			_requestObjectType = requestObjectType;
			_targetID = targetID;
		}

		#endregion
	}
}
