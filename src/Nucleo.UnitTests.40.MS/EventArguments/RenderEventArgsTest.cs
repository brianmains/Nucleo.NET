using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class RenderEventArgsTest
	{
		[TestMethod]
		public void CreatingWithWriterAssignsOK()
		{
			//Arrange
			var writer = Isolate.Fake.Instance<BaseControlWriter>();

			//Act
			var args = new RenderEventArgs(writer);

			//Assert
			Assert.AreEqual(writer, args.Writer);
		}
	}
}
