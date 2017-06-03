using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web
{
	[TestClass]
	public class ExtenderControlCollectionTest
	{
		#region " Methods "

		[TestMethod]
		public void CreatingCollectionWithArrayWorksOK()
		{
			//Arrange
			var extender1 = Isolate.Fake.Instance<IExtenderControl>();
			var extender2 = Isolate.Fake.Instance<IExtenderControl>();

			//Act
			var ctls = new ExtenderControlCollection(new IExtenderControl[] { extender1, extender2 });

			//Assert
			Assert.AreEqual(2, ctls.Count);

			Isolate.CleanUp();
		}

		#endregion
	}
}
