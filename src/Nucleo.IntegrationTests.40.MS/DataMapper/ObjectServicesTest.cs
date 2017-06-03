using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Collections;
using Nucleo.TestData.Entities;


using Nucleo.DataMapper.Incrementing;


namespace Nucleo.DataMapper
{
	[TestClass]
	public class ObjectServicesTest
	{
		#region " Test Classes "

		public class SimpleTestClass
		{
			public string Key { get; set; }
			public object Value { get; set; }
			public int Hierarchy { get; set; }
			public string Category { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingDuplicatedObjectsSimplisticallyWorksOK()
		{
			//Arrange
			var gen = new ObjectMappingGenerator(typeof(SimpleTestClass));
			var service = new ObjectServices();

			//Act
			var objs = service.GenerateNewObjects<SimpleTestClass>(gen,
				new FieldMapping("Key", Values.AsIs("1")),
				new FieldMapping("Value", Values.List<string>(new string[] { "A", "B" })),
				new FieldMapping("Hierarchy", Values.AsIs(2)),
				new FieldMapping("Category", Values.List<string>(new string[] { "Main", "Sub" }))).ToList();

			//Assert
			Assert.AreEqual(4, objs.Count);
			Assert.AreEqual("A", objs[0].Value);
			Assert.AreEqual("Main", objs[0].Category);
			Assert.AreEqual("Sub", objs[1].Category);
			Assert.AreEqual("B", objs[2].Value);

			Assert.IsTrue(objs.IsAllTrue(i => i.Key == "1"), "Key wasn't one");
			Assert.IsTrue(objs.IsAllTrue(i => i.Hierarchy == 2), "Hierarchy wasn't two");
		}

		#endregion
	}
}
