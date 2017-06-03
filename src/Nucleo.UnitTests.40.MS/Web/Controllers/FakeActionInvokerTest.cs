using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Controllers
{
	[TestClass]
	public class FakeActionInvokerTest
	{
		[TestMethod]
		public void SettingProcessResultsToFalseIgnoresResultsCheck()
		{
			//Arrange
			var invoker = new FakeActionInvoker { ProcessResults = false };

			//Act
			

			//Assert

		}
	}
}
