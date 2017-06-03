using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.DataMapper
{
	[TestClass]
	public class AutoGenerateValueTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAutoValueWorksOK()
		{
			//Arrange
			var field = new AutoGenerateValue(1, 1);

			//Act
			var value = field.GetValue();

			//Assert
			Assert.AreEqual(Convert.ToInt64(1), value);
		}

		[TestMethod]
		public void IncrementingAutoValueWorksOK()
		{
			//Arrange
			var field = new AutoGenerateValue(1, 1);
			field.Increment(null);
			field.Increment(null);

			//Act
			var value = field.GetValue();


			//Assert
			Assert.AreEqual(Convert.ToInt64(3), value);
		}

		#endregion
	}
}
