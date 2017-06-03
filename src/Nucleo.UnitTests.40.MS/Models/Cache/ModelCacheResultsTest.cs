using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Models.Cache
{
	[TestClass]
	public class ModelCacheResultsTest
	{
		[TestMethod]
		public void CreatingWOrksOK()
		{
			//Arrange

			//Act
			var results = new ModelCacheResults(true, 123);

			//Assert
			Assert.AreEqual(true, results.HasValue);
			Assert.AreEqual(123, results.Value);
		}
	}
}
