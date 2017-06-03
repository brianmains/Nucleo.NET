using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Views
{
	[TestClass]
	public class FakeViewPageTest
	{
		[TestMethod]
		public void FiringInitializingFiresOK()
		{
			var control = new FakeViewPage();
			bool fired = false;

			control.Initializing += delegate(object sender, EventArgs e)
			{
				fired = true;
			};

			control.FireInitializingEvent();

			Assert.IsTrue(fired);
		}

		[TestMethod]
		public void FiringLoadedFiresOK()
		{
			var control = new FakeViewPage();
			bool fired = false;

			control.Loaded += delegate(object sender, EventArgs e)
			{
				fired = true;
			};

			control.FireLoadedEvent();

			Assert.IsTrue(fired);
		}

		[TestMethod]
		public void FiringLoadingFiresOK()
		{
			var control = new FakeViewPage();
			bool fired = false;

			control.Loading += delegate(object sender, EventArgs e)
			{
				fired = true;
			};

			control.FireLoadingEvent();

			Assert.IsTrue(fired);
		}

		[TestMethod]
		public void FiringStartingFiresOK()
		{
			var control = new FakeViewPage();
			bool fired = false;

			control.Starting += delegate(object sender, EventArgs e)
			{
				fired = true;
			};

			control.FireStartingEvent();

			Assert.IsTrue(fired);
		}

		[TestMethod]
		public void FiringUnloadingFiresOK()
		{
			var control = new FakeViewPage();
			bool fired = false;

			control.Unloading += delegate(object sender, EventArgs e)
			{
				fired = true;
			};

			control.FireUnloadingEvent();

			Assert.IsTrue(fired);
		}
	}
}
