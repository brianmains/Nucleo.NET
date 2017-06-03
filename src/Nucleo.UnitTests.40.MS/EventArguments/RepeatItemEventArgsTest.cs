using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Repeating;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class RepeatItemEventArgsTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingRepeatControlWorksOK()
		{
			//Arrange
			var args = default(RepeatItemEventArgs);
			var list = Isolate.Fake.Instance<IRepeatableList>();

			//Act
			args = new RepeatItemEventArgs(list, 3);

			//Assert
			Assert.AreEqual(list, args.RepeatControl);
			Assert.AreEqual(3, args.RepeatIndex);
		}

		#endregion
	}
}
