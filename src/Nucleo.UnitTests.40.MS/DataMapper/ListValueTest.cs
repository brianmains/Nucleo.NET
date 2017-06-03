using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.DataMapper
{
	[TestClass]
	public class ListValueTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingListValuesWorksOK()
		{
			//Arrange
			var field = new ListValue(new string[] { "A", "B", "C", "D" });

			//Act
			var values = field.GetValues();

			//Assert
			Assert.AreEqual(4, values.Length);
			Assert.AreEqual("A", values[0]);
			Assert.AreEqual("D", values[3]);
		}

		[TestMethod]
		public void GettingValueReturnsList()
		{
			//Arrange
			var field = new ListValue(new string[] { "A", "B", "C", "D" });

			//Act
			var value = field.GetValue();

			//Assert
			Assert.IsInstanceOfType(value, typeof(IEnumerable));
		}

		#endregion
	}
}
