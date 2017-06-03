using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Logs
{
	[TestClass]
	public class LogMessageTypeTest : LogMessageType
	{
		#region " Constructors 

		public LogMessageTypeTest() 
			: base("Test", 1000) { }

		public LogMessageTypeTest(string name, int value)
			: base(name, value) { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingMessageReturnsObjectWithCorrectValues()
		{
			LogMessageTypeTest test = new LogMessageTypeTest("Information", 1);
			Assert.AreEqual("Information", test.Name);
			Assert.AreEqual(1, test.Value);
		}

		[TestMethod]
		public void ObjectsWithDifferentValuesReturnsFalse()
		{
			var typeFake1 = Isolate.Fake.Instance<LogMessageType>();
			Isolate.WhenCalled(() => typeFake1.Value).WillReturn(1);

			var typeFake2 = Isolate.Fake.Instance<LogMessageType>();
			Isolate.WhenCalled(() => typeFake2.Value).WillReturn(2);

			Isolate.WhenCalled(() => typeFake1.Equals(typeFake2)).CallOriginal();

			bool val = typeFake1.Equals(typeFake2);

			Assert.IsFalse(val, "Message types should not equal each other");
		}

		[TestMethod]
		public void ObjectsWithSameValuesReturnsTrue()
		{
			var typeFake1 = Isolate.Fake.Instance<LogMessageType>();
			Isolate.WhenCalled(() => typeFake1.Value).WillReturn(1);

			var typeFake2 = Isolate.Fake.Instance<LogMessageType>();
			Isolate.WhenCalled(() => typeFake2.Value).WillReturn(1);

			Isolate.WhenCalled(() => typeFake1.Equals(typeFake2)).CallOriginal();

			bool val = typeFake1.Equals(typeFake2);

			Assert.IsTrue(val, "Message types should equal each other");
		}

		#endregion
	}
}
