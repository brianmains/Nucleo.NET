using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.EventArguments;


namespace Nucleo.Commands
{
	[TestClass]
	public class BaseCommandTest
	{
		protected class TestCommand : BaseCommand
		{
			public override string Name
			{
				get { return "Test"; }
			}
		}


		[TestMethod]
		public void FiringFiresEvent()
		{
			var cmd = new TestCommand();
			bool fired = false;

			cmd.Fired += delegate(object sender, CommandEventArgs e) { fired = true; };

			cmd.Fire(new object());

			Assert.IsTrue(fired);
		}

		[TestMethod]
		public void FiringPassesCommandAndArgs()
		{
			var cmd = new TestCommand();
			object command = null;
			object result = null;

			cmd.Fired += delegate(object sender, CommandEventArgs e) 
			{
				command = e.Command;
				result = e.Arguments; 
			};

			cmd.Fire(new object());

			Assert.AreEqual(cmd, command);
			Assert.IsNotNull(result);
		}
	}
}
