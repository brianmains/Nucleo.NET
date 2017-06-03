using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Commands
{
	[TestClass]
	public class CommandRegistrarTest
	{
		[TestMethod]
		public void CreatingHasNoCommands()
		{
			var registrar = new CommandRegistrar();

			Assert.AreEqual(0, registrar.Count);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullCommandsThrowsException()
		{
			new CommandRegistrar(null);
		}

		[TestMethod]
		public void CreatingWithValidCommandsAddsOK()
		{
			var registrar = new CommandRegistrar(new[]
				{
					Isolate.Fake.Instance<ICommand>(),
					Isolate.Fake.Instance<ICommand>()
				});

			Assert.AreEqual(2, registrar.Count);
		}

		[TestMethod]
		public void GettingAllCommandsOnNewRegistrarReturnsEmptyCollection()
		{
			var registrar = new CommandRegistrar();

			var cmds = registrar.GetAll();

			Assert.AreEqual(0, registrar.Count);
		}

		[TestMethod]
		public void GettingAllCommandsReturnsAll()
		{
			var registrar = new CommandRegistrar(new[]
				{
					Isolate.Fake.Instance<ICommand>(),
					Isolate.Fake.Instance<ICommand>()
				});

			var cmds = registrar.GetAll();

			Assert.AreEqual(2, registrar.Count);
		}

		[TestMethod]
		public void GettingByNameReturnsNothingOnMismatch()
		{
			var cmd = Isolate.Fake.Instance<ICommand>();
			Isolate.WhenCalled(() => cmd.Name).WillReturn("Test");

			var registrar = new CommandRegistrar(new[] { cmd });

			var output = registrar.Get("DontFind");

			Assert.IsNull(output);
		}

		[TestMethod]
		public void GettingByNameReturnsValueOnMatch()
		{
			var cmd = Isolate.Fake.Instance<ICommand>();
			Isolate.WhenCalled(() => cmd.Name).WillReturn("Test");

			var registrar = new CommandRegistrar(new[] { cmd });

			var output = registrar.Get("Test");

			Assert.IsNotNull(output);
		}

		[TestMethod]
		public void RegisteringCommandAddsToList()
		{
			var cmd = Isolate.Fake.Instance<ICommand>();
			var registrar = new CommandRegistrar();

			registrar.Register(cmd);

			Assert.AreEqual(1, registrar.Count);
		}
	}
}
