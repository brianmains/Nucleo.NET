using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Logs
{
	[TestClass]
	public class LogVerbosityTypeTest : LogVerbosityType
	{
		#region " Constructors "

		public LogVerbosityTypeTest()
			: base("Test", 255) { }

		public LogVerbosityTypeTest(string name, byte level)
			: base(name, level) { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingVerbosityAssignsValuesCorrectly()
		{
			LogVerbosityTypeTest test = new LogVerbosityTypeTest("Verbose", 255);
			Assert.AreEqual("Verbose", test.Name);
			Assert.AreEqual(255, test.Level);
		}

		[TestMethod]
		public void ObjectsWithDifferentValuesReturnsFalse()
		{
			var typeFake1 = Isolate.Fake.Instance<LogVerbosityType>();
			Isolate.WhenCalled(() => typeFake1.Level).WillReturn(1);

			var typeFake2 = Isolate.Fake.Instance<LogVerbosityType>();
			Isolate.WhenCalled(() => typeFake2.Level).WillReturn(2);

			Isolate.WhenCalled(() => typeFake1.Equals(typeFake2)).CallOriginal();

			bool val = typeFake1.Equals(typeFake2);

			Assert.IsFalse(val, "Message types should not equal each other");
		}

		[TestMethod]
		public void ObjectsWithSameValuesReturnsTrue()
		{
			var typeFake1 = Isolate.Fake.Instance<LogVerbosityType>();
			Isolate.WhenCalled(() => typeFake1.Level).WillReturn(1);

			var typeFake2 = Isolate.Fake.Instance<LogVerbosityType>();
			Isolate.WhenCalled(() => typeFake2.Level).WillReturn(1);

			Isolate.WhenCalled(() => typeFake1.Equals(typeFake2)).CallOriginal();

			bool val = typeFake1.Equals(typeFake2);

			Assert.IsTrue(val, "Message types should equal each other");
		}

		#endregion
	}
}
