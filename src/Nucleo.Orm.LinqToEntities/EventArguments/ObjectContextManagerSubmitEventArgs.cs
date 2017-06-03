using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nucleo.EventArguments
{
	public class ObjectContextManagerSubmitEventArgs : EventArgs
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

		public ObjectContextManagerSubmitEventArgs(bool succeeded)
		{
			_succeeded = succeeded;
		}

		public ObjectContextManagerSubmitEventArgs(Exception ex)
		{
			_succeeded = false;
			_exception = ex;
		}

		#endregion
	}


	public delegate void ObjectContextManagerSubmitEventHandler(object sender, ObjectContextManagerSubmitEventArgs e);
}
