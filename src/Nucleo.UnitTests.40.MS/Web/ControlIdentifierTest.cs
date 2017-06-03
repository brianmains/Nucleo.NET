using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class ControlIdentifierTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingIdentifierWorksOK()
		{
			//Arrange
			var ids = default(ControlIdentifier);

			//Act
			ids = new ControlIdentifier("Test");

			//Assert
			Assert.AreEqual("Test", ids.ID);
		}

		#endregion
	}
}
