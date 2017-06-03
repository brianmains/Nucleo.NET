using System;
using System.Collections.Generic;
using System.Linq;


namespace Nucleo.EventArguments
{
	public class DataContextManagerSubmitEventArgs : EventArgs
	{
		private Exception _exception = null;
		private bool _succeeded = false;



		#region " Properties "

		public Exception Exception
		{
			get { return _exception; }
		}

		public bool Succeeded
		{
			get { return _succeeded; }
		}

		#endregion



		#region " Constructors "

		public DataContextManagerSubmitEventArgs(bool succeeded)
		{
			_succeeded = succeeded;
		}

		public DataContextManagerSubmitEventArgs(Exception ex)
		{
			_succeeded = false;
			_exception = ex;
		}

		#endregion
	}


	public delegate void DataContextManagerSubmitEventHandler(object sender, DataContextManagerSubmitEventArgs e);
}
