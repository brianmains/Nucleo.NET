using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.DataMapper
{
	[TestClass]
	public class DirectValueTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingValueWorksOK()
		{
			//Arrange
			var field = new DirectValue("123");

			//Act
			var value = field.GetValue();

			//Assert
			Assert.AreEqual("123", value);
		}

		#endregion
	}
}
