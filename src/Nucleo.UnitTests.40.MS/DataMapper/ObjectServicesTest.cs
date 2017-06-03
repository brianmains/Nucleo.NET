using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.DataMapper
{
	[TestClass]
	public class ObjectServicesTest
	{
		#region " Test Classes "

		public class TestLinqClass
		{
			public int TestClassKey { get; set; }
			public int PK1 { get; set; }
			public int PK2 { get; set; }
			public string CreatedByUserName { get; set; }
			public DateTime CreatedDate { get; set; }
			public string LastUpdatedByUserName { get; set; }
			public DateTime? LastUpdatedDate { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GeneratingBulkObjectsWithDirectValuesOnlyWorksOK()
		{
			//Arrange
			var services = new ObjectServices();

			//Act
			//var objs = services.GenerateBulk<TestLinqClass>(
			//    i => i.TestClassKey

			//Assert

		}

		#endregion
	}
}
