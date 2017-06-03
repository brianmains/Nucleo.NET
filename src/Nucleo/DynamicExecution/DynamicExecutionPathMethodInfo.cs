using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleo.DynamicExecution
{
	public class DynamicExecutionPathMethodInfo
	{
		private string _methodFriendlyName = null;
		private string _methodName = null;
		private string _objectTypeName = null;
		private Exception _thrownException = null;



		#region " Properties "

		public string MethodFriendlyName
		{
			get { return _methodFriendlyName; }
		}

		public string MethodName
		{
			get { return _methodName; }
		}

		public string ObjectTypeName
		{
			get { return _objectTypeName; }
		}

		public Exception ThrownException
		{
			get { return _thrownException; }
			set { _thrownException = value; }
		}

		#endregion



		#region " Constructors "

		public DynamicExecutionPathMethodInfo(string methodFriendlyName, string objectTypeName, string methodName)
		{
			_methodFriendlyName = methodFriendlyName;
			_objectTypeName = objectTypeName;
			_methodName = methodName;
		}

		#endregion
	}
}
