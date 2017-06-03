using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.State
{
	[TestClass]
	public class CurrentExecutionStateDisplayTest
	{
		[TestMethod]
		public void GettingAndSettingHeaderAssignsOK()
		{
			var display = new CurrentExecutionStateDisplay();
			display.HeaderText = "A";

			Assert.AreEqual("A", display.HeaderText);
		}
	}
}
