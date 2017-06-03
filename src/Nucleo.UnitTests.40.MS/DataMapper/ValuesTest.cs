using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.DataMapper
{
	[TestClass]
	public class ValuesTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAutoGenerateFieldWorksOK()
		{
			//Act
			var field = Values.AutoGenerate(2, 1);

			//Assert
			Assert.IsInstanceOfType(field, typeof(AutoGenerateValue));
			Assert.AreEqual(2, ((AutoGenerateValue)field).Start);
			Assert.AreEqual(1, ((AutoGenerateValue)field).Step);
		}

		[TestMethod]
		public void GettingEnumerableFieldWorksOK()
		{
			//Arrange
			var vals = Isolate.Fake.Instance<IEnumerable>();

			//Act
			var field = Values.List(vals);

			//Assert
			Assert.IsInstanceOfType(field, typeof(ListValue));
			Assert.IsInstanceOfType(((ListValue)field).List, typeof(IEnumerable));
		}

		[TestMethod]
		public void GettingEnumerableFieldWithGenericsWorksOK()
		{
			//Arrange
			var vals = new List<string>(new string[] { "A", "B", "C" });

			//Act
			var field = Values.List<string>(vals);

			//Assert
			Assert.IsInstanceOfType(field, typeof(ListValue));
			Assert.IsInstanceOfType(((ListValue)field).List, typeof(List<string>));
		}

		[TestMethod]
		public void GettingIngoreFieldWorksOK()
		{
			//Arrange

			//Act
			var field = Values.Ignore();

			//Assert
			Assert.IsInstanceOfType(field, typeof(IgnoreValue));
		}

		[TestMethod]
		public void GettingNumericFieldWorksOK()
		{
			//Arrange
			int text = 123;

			//Act
			var field = Values.AsIs(text);

			//Assert
			Assert.IsInstanceOfType(field, typeof(DirectValue));
			Assert.IsInstanceOfType(((DirectValue)field).Value, typeof(int));
			Assert.AreEqual(123, field.Value);
		}

		[TestMethod]
		public void GettingNullFieldWorksOK()
		{
			//Arrange

			//Act
			var field = Values.Null();

			//Assert
			Assert.IsInstanceOfType(field, typeof(NullValue));
		}

		[TestMethod]
		public void GettingObjectFieldWorksOK()
		{
			//Arrange
			var dt = new System.Data.DataTable();

			//Act
			var field = Values.AsIs(dt);

			//Assert
			Assert.IsInstanceOfType(field, typeof(DirectValue));
			Assert.IsInstanceOfType(((DirectValue)field).Value, typeof(System.Data.DataTable));
			Assert.AreEqual(dt, field.Value);
		}

		[TestMethod]
		public void GettingRangeFieldWithoutStepWorksOK()
		{
			//Arrange
			long min = 20;
			long max = 40;

			//Act
			var field = Values.Range(min, max);

			//Assert
			Assert.IsInstanceOfType(field, typeof(RangesValue));
			Assert.AreEqual(20, field.Minimum);
			Assert.AreEqual(40, field.Maximum);
			Assert.AreEqual(1, field.Step);
		}

		[TestMethod]
		public void GettingRangeFieldWithStepWorksOK()
		{
			//Arrange
			long min = 20;
			long max = 40;
			long step = 3;

			//Act
			var field = Values.Range(min, max, 3);

			//Assert
			Assert.IsInstanceOfType(field, typeof(RangesValue));
			Assert.AreEqual(20, field.Minimum);
			Assert.AreEqual(40, field.Maximum);
			Assert.AreEqual(3, field.Step);
		}

		[TestMethod]
		public void GettingTextWorksOK()
		{
			//Arrange
			var text = "ABC";

			//Act
			var field = Values.Text(text);

			//Assert
			Assert.IsInstanceOfType(field, typeof(DirectValue));
			Assert.IsInstanceOfType(((DirectValue)field).Value, typeof(string));
			Assert.AreEqual("ABC", field.Value);
		}

		#endregion
	}
}
