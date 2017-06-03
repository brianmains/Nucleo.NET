using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web
{
	[TestClass]
	public class ElementIdentifierTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingIdentifierWorksOK()
		{
			//Arrange
			var ids = default(ElementIdentifier);

			//Act
			ids = new ElementIdentifier("Test");

			//Assert
			Assert.AreEqual("Test", ids.ID);
		}

		#endregion
	}
}
