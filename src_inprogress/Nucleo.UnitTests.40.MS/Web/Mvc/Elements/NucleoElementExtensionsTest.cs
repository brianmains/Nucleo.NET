using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Mvc.Elements
{
	[TestClass]
	public class NucleoElementExtensionsTest
	{
		[TestMethod]
		public void GettingExistingDefinitionInItemsCollectionWorksOK()
		{
			//Arrange
			var helper = Isolate.Fake.Instance<HtmlHelper>();
			var factory = new NucleoElementFactory(helper);

			Isolate.WhenCalled(() => helper.ViewContext.HttpContext.Items[typeof(NucleoElementExtensions)]).WillReturn(factory);

			//Act
			var output = NucleoElementExtensions.NucleoElements(helper);

			//Assert
			Assert.AreEqual(factory, output);
			Isolate.Verify.WasNotCalled(() => helper.ViewContext.HttpContext.Items.Add(null, null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingNewDefinitionWorksOK()
		{
			//Arrange
			var helper = Isolate.Fake.Instance<HtmlHelper>();

			Isolate.WhenCalled(() => helper.ViewContext.HttpContext.Items[typeof(NucleoElementExtensions)]).WillReturn(null);

			//Act
			var output = NucleoElementExtensions.NucleoElements(helper);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => helper.ViewContext.HttpContext.Items.Add(null, null));

			Isolate.CleanUp();
		}
	}
}
