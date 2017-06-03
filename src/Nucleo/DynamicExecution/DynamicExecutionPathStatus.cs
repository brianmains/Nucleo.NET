using System;
using System.Collections.Generic;


namespace Nucleo.DynamicExecution
{
	public class DynamicExecutionPathStatus
	{
		private DynamicExecutionPathMethodInfoCollection _methodsExecuted = null;
		private DynamicExecutionPathMethodInfoCollection _methodsFailed = null;
		private DynamicExecutionPathMethodInfoCollection _methodsIgnored = null;



		#region " Properties "

		/// <summary>
		/// Gets the methods that were executed in the system.
		/// </summary>
		public DynamicExecutionPathMethodInfoCollection MethodsExecuted
		{
			get
			{
				if (_methodsExecuted == null)
					_methodsExecuted = new DynamicExecutionPathMethodInfoCollection();
				return _methodsExecuted;
			}
		}

		/// <summary>
		/// Gets the methods that executed, but were considered a failure when they ran, either because an exception was thrown, or because it was marked as a failure.
		/// </summary>
		public DynamicExecutionPathMethodInfoCollection MethodsFailed
		{
			get
			{
				if (_methodsFailed == null)
					_methodsFailed = new DynamicExecutionPathMethodInfoCollection();
				return _methodsFailed;
			}
		}

		/// <summary>
		/// Gets the methods that were ignored because method execution is cancelled.
		/// </summary>
		public DynamicExecutionPathMethodInfoCollection MethodsIgnored
		{
			get
			{
				if (_methodsIgnored == null)
					_methodsIgnored = new DynamicExecutionPathMethodInfoCollection();
				return _methodsIgnored;
			}
		}

		#endregion



		#region " Constructors "

		public DynamicExecutionPathStatus() { }

		#endregion
	}
}
