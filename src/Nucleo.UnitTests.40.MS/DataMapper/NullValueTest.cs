using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.DataMapper
{
	[TestClass]
	public class NullValueTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingValueIsNull()
		{
			//Arrange
			var field = new NullValue();

			//Act
			var value = field.GetValue();

			//Assert
			Assert.IsNull(value);
		}

		#endregion
	}
}
