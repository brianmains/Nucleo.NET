using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class BaseClientDescriptorTest
	{
		#region " Classes "

		public class TestDescriptor : BaseClientDescriptor
		{
			public TestDescriptor(string clientName, string serverName)
				: base(clientName, serverName) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingObectsAssignsOK()
		{
			//Arrange
			var descriptor = default(TestDescriptor);

			//Act
			descriptor = new TestDescriptor("content", "Content");

			//Assert
			Assert.AreEqual("content", descriptor.ClientName);
			Assert.AreEqual("Content", descriptor.ServerName);
		}

		#endregion
	}
}
