using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.DataServices.Modules
{
	[TestClass]
	public class ModuleIdentifierTest
	{
		#region " Tests "

		public void CreatingIdentifierWorksOK()
		{
			//Arrange
			var id = default(ModuleIdentifier);

			//Act
			id = new ModuleIdentifier("Test");

			//Assert
			Assert.AreEqual("Test", id.Name);
		}

		[TestMethod]
		public void TestingEqualityReturnsFalse()
		{
			//Arrange
			var id1 = Isolate.Fake.Instance<ModuleIdentifier>(Members.CallOriginal);
			var id2 = Isolate.Fake.Instance<ModuleIdentifier>(Members.CallOriginal);

			Isolate.WhenCalled(() => id1.Name).WillReturn("Test");
			Isolate.WhenCalled(() => id2.Name).WillReturn("Test2");

			//Act
			var equals = (id1 == id2);

			//Assert
			Assert.IsFalse(equals, "Objects equal each other, but shouldn't");
		}

		[TestMethod]
		public void TestingEqualityReturnsTrue()
		{
			//Arrange
			var id1 = Isolate.Fake.Instance<ModuleIdentifier>(Members.CallOriginal);
			var id2 = Isolate.Fake.Instance<ModuleIdentifier>(Members.CallOriginal);

			Isolate.WhenCalled(() => id1.Name).WillReturn("Test");
			Isolate.WhenCalled(() => id2.Name).WillReturn("Test");

			//Act
			var equals = (id1 == id2);

			//Assert
			Assert.IsTrue(equals, "Object's don't equal, but they should");
		}

		#endregion
	}
}

