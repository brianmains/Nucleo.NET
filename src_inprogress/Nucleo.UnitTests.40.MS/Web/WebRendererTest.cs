using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Tags;


namespace Nucleo.Web
{
	[TestClass]
	public class WebRendererTest : WebRenderer
	{
		#region " Methods "

		public override TagElement Render()
		{
			return null;
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void InitializeAssignsComponent()
		{
			//Arrange
			var renderer = new WebRendererTest();
			var componentFake = Isolate.Fake.Instance<Control>();

			//Act
			renderer.Initialize(componentFake);

			//Assert
			Assert.AreEqual(componentFake, renderer.Component);
		}

		#endregion

	}
}
