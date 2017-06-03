using System;
using System.Collections.Generic;

using Nucleo.DataServices.Modules;


namespace Nucleo.DataServices.Results
{
	public class FakeDataServiceResult : IDataServiceResult
	{
		private IDataServiceModule _module = null;
		private string _status = null;



		#region " Properties "

		public IDataServiceModule Module
		{
			get { return _module; }
			set { _module = value; }
		}

		public string Status
		{
			get { return _status; }
			set { _status = value; }
		}

		#endregion



		#region " Constructors "

		public FakeDataServiceResult() { }

		#endregion



		#region " Methods "

		public string GetStatus()
		{
			return _status;
		}

		#endregion
	}
}
