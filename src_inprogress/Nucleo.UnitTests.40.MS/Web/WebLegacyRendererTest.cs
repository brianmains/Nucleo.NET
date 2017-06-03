using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web
{
	[TestClass]
	public class WebLegacyRendererTest : WebLegacyRenderer
	{
		#region " Methods "

		public override void Render(BaseControlWriter writer)
		{
			
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void InitializeAssignsReferences()
		{
			//Arrange
			var renderer = new WebLegacyRendererTest();
			var component = Isolate.Fake.Instance<Control>();
			var page = Isolate.Fake.Instance<Page>();

			//Act
			renderer.Initialize(component, page);

			//Assert
			Assert.AreEqual(component, renderer.Component);
			Assert.AreEqual(page, renderer.Page);
		}

		#endregion
	}
}
