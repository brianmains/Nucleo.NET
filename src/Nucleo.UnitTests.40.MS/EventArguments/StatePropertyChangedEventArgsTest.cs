using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.State;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class StatePropertyChangedEventArgsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingArgsWorksOK()
		{
			//Arrange
			var propFake = Isolate.Fake.Instance<StateProperty>();
			Isolate.WhenCalled(() => propFake.Name).WillReturn("Test");

			//Act
			var args = new StatePropertyChangedEventArgs(propFake, 123);

			//Assert
			Assert.AreEqual(propFake, args.Property);
			Assert.AreEqual(123, args.Value);

			Isolate.CleanUp();
		}

		#endregion
	}
}
