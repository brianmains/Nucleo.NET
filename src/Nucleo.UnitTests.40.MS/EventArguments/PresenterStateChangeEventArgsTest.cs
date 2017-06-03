using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.EventArguments
{
	[TestClass]
	public class PresenterStateChangeEventArgsTest
	{
		[TestMethod]
		public void CreatingEventArgWorksOK()
		{
			//Arrange
			
			//Act
			var arg = new PresenterStateChangeEventArgs("X", 123);
			
			//Assert
			Assert.AreEqual("X", arg.Name);
			Assert.AreEqual(123, arg.Value);
		}
	}
}
