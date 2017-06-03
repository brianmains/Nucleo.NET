using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web
{
	[TestClass]
	public class CssReferenceTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingUsingPathEmbeddedAssignsOK()
		{
			//Arrange

			//Act
			var reference = new CssReference("styles.css");

			//Assert
			Assert.AreEqual("styles.css", reference.Path);
		}

		[TestMethod]
		public void CreatingUsingScriptDetailsAssignsOK()
		{
			//Arrange
			var detailsFake = Isolate.Fake.Instance<CssReferenceRequestDetails>();
			Isolate.WhenCalled(() => detailsFake.Path).WillReturn("styles.css");

			//Act
			var reference = new CssReference(detailsFake);

			//Assert
			Assert.AreEqual("styles.css", reference.Path);
		}

		#endregion
	}
}
