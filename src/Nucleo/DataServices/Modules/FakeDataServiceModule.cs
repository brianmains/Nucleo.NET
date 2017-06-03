using System;
using System.Collections.Generic;

using Nucleo.DataServices;
 using Nucleo.DataServices.Results;


namespace Nucleo.DataServices.Modules
{
	public class FakeDataServiceModule : BaseDataServiceModule
	{
		private IDataServiceResult _result = null;



		#region " Properties "

		public override string DisplayName
		{
			get { return "Fake"; }
		}

		public IDataServiceResult Result
		{
			get { return _result; }
			set { _result = value; }
		}

		#endregion



		#region " Constructors "

		public FakeDataServiceModule() { }

		public FakeDataServiceModule(IDataServiceResult result)
		{
			_result = result;
		}

		#endregion



		#region " Methods "

		public static FakeDataServiceModule Create(string status)
		{
			FakeDataServiceModule module = new FakeDataServiceModule();
			module.Result = new FakeDataServiceResult { Module = module, Status = status };

			return module;
		}

		public override IDataServiceResult Execute()
		{
			return _result;
		}

		#endregion
	}
}
