using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Rss
{
	[TestClass]
	public class RssChannelTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingObjectWorksOK()
		{
			//Arrange
			var obj = default(RssChannel);

			//Act
			obj = new RssChannel("Test", "Test Link", "Test Desc");

			//Assert
			Assert.AreEqual("Test", obj.Title);
			Assert.AreEqual("Test Link", obj.Link);
			Assert.AreEqual("Test Desc", obj.Description);
		}

		#endregion
	}
}
