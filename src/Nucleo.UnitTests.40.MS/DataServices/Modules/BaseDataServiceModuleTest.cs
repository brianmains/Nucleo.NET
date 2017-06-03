using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.DataServices.Modules
{
	[TestClass]
	public class BaseDataServiceModuleTest : BaseDataServiceModule
	{
		#region " Properties "

		public override string DisplayName
		{
			get { return "Test"; }
		}

		#endregion



		#region " Methods "

		public override Nucleo.DataServices.Results.IDataServiceResult Execute()
		{
			throw new NotImplementedException();
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void LoadingParametersWorksOK()
		{
			//Arrange
			var module = new BaseDataServiceModuleTest();
			var parms = new Dictionary<string, object>();
			parms.Add("1", 1);
			parms.Add("2", 2);

			//Act
			module.Initialize(parms);

			//Assert
			Assert.IsNotNull(module.Parameters);
			Assert.AreEqual(2, module.Parameters.Count);
		}

		#endregion
	}
}
