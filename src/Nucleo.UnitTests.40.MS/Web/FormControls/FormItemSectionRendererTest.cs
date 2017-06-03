using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Templates;


namespace Nucleo.Web.FormControls
{
	[TestClass]
	public class FormItemSectionRendererTest
	{
		[TestMethod]
		public void RenderingTemplateWorksOK()
		{
			//Arrange
			var render = new FormItemSectionRenderer();
			var template = Isolate.Fake.Instance<ControlElementTemplate>();
			Isolate.WhenCalled(() => template.ReturnsContent).WillReturn(true);
			Isolate.WhenCalled(() => template.GetTemplate()).WillReturn("Test");

			var ctl = new FormItemSection
			{
				Content = template,
				Page = new Page()
			};

			render.Initialize(ctl, ctl.Page);
			
			//Act
			var writer = new StringControlWriter();
			render.Render(writer);

			//Assert
			Assert.AreEqual("Test", writer.ToString());
		}
	}
}
