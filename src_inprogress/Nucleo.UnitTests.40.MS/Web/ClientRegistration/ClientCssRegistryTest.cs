using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web;


namespace Nucleo.Web.ClientRegistration
{
	[TestClass]
	public class ClientCssRegistryTest
	{
		#region " Test Classes "

		public class CssMetadata : WebCssMetadata
		{
			public override CssReferenceRequestDetailsCollection GetPrimaryCss()
			{
				return new CssReferenceRequestDetailsCollection(
					new CssReferenceRequestDetails("metadata.css"));
			}
		}

		[
		ClientCss("styles.css"),
		ClientCss("framework.css")
		]
		protected class TestCssControl : Control { }

		[WebCssMetadata(typeof(CssMetadata))]
		protected class TestCssMetadataControl : Control { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void LoadingClientCssMetadataReferencesReturnsCorrectReferences()
		{
			//Arrange
			var control = new TestCssMetadataControl();
			control.Page = new Page();

			//Act
			var registry = ClientCssRegistry.CreateFor(control);

			//Assert
			Assert.AreEqual(1, registry.Css.Count);
			Assert.AreEqual("metadata.css", registry.Css[0].Path);
		}

		[TestMethod]
		public void LoadingClientCssReferencesReturnsCorrectReferences()
		{
			//Arrange
			var clientScript = Isolate.Fake.Instance<ClientScriptManager>();
			var page = Isolate.Fake.Instance<Page>();
			Isolate.WhenCalled(() => page.ClientScript).WillReturn(clientScript);
			Isolate.WhenCalled(() => clientScript.GetWebResourceUrl(typeof(TestCssControl), "styles.css"))
				.WithExactArguments().WillReturn("test.axd?page=styles.css");
			Isolate.WhenCalled(() => clientScript.GetWebResourceUrl(typeof(TestCssControl), "framework.css"))
				.WithExactArguments().WillReturn("test.axd?page=framework.css");

			var control = new TestCssControl();
			control.Page = page;

			//Act
			var registry = ClientCssRegistry.CreateFor(control);

			//Assert
			Assert.AreEqual(2, registry.Css.Count);
			var scripts = registry.Css.Select(i => i.Path);
			Assert.IsTrue(scripts.Contains("test.axd?page=styles.css"));
			Assert.IsTrue(scripts.Contains("test.axd?page=framework.css"));
		}

		#endregion
	}
}
