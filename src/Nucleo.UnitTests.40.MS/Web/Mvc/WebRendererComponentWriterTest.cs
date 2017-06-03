using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.Web.Mvc
{
	[TestClass]
	public class WebRendererComponentWriterTest
	{
		#region " Test Classes "

		public class TestInvalidComponent : BaseMvcComponent { }

		[WebRenderer(typeof(TestComponentRenderer))]
		public class TestComponent : BaseMvcComponent { }

		public class TestComponentRenderer : WebRenderer
		{
			public override Tags.TagElement Render()
			{
				return new Tags.TagElement("DIV");
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void RenderingComponentWorksOK()
		{
			//Arrange
			var component = new TestComponent();
			var writer = new WebRendererComponentWriter<TestComponent>();

			//Act
			var tag = writer.Render(component);

			//Assert
			Assert.AreEqual("DIV", tag.TagName);
		}

		[TestMethod]
		public void RenderingInvalidComponentWorksOK()
		{
			//Arrange
			var component = new TestInvalidComponent();
			var writer = new WebRendererComponentWriter<TestInvalidComponent>();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { writer.Render(component); });
		}

		#endregion
	}
}
