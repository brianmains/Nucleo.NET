using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Commands
{
	[TestClass]
	public class CommandCollectionTest
	{
		[TestMethod]
		public void GettingByNameMismatches()
		{
			var cmd = Isolate.Fake.Instance<ICommand>();
			Isolate.WhenCalled(() => cmd.Name).WillReturn("Test");

			var collection = new CommandCollection();
			collection.Add(cmd);

			var output = collection.GetByName("DontFind");

			Assert.IsNull(output);
		}

		[TestMethod]
		public void GettingByNameWhenEmptyFindsNothing()
		{
			var collection = new CommandCollection();

			var output = collection.GetByName("DontFind");

			Assert.IsNull(output);
		}

		[TestMethod]
		public void GettingByNameWorksOK()
		{
			var cmd = Isolate.Fake.Instance<ICommand>();
			Isolate.WhenCalled(() => cmd.Name).WillReturn("Test");

			var collection = new CommandCollection();
			collection.Add(cmd);

			var output = collection.GetByName("Test");

			Assert.AreEqual(cmd, output);
		}
	}
}
