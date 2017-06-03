using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.DataServices.Modules;
using Nucleo.DataServices.Results;


namespace Nucleo.DataServices
{
	[TestClass]
	public class DataServiceExecutorResultsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingResultsAssignsOK()
		{
			//Arrange
			List<IDataServiceResult> results = new List<IDataServiceResult>();
			results.Add(new FakeDataServiceResult { Module = null, Status = "Fake Status 1" });
			results.Add(new FakeDataServiceResult { Module = null, Status = "Fake Status 2" });
			results.Add(new FakeDataServiceResult { Module = null, Status = "Fake Status 3" });

			//Act
			var obj = new DataServiceExecutorResults(results);

			//Assert
			var finalResults = obj.GetResults();
			Assert.AreEqual(results, finalResults);
			Assert.AreEqual(3, finalResults.Count);
		}

		#endregion
	}
}
