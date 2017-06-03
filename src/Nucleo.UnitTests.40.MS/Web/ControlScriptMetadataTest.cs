using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.ButtonControls;
using Nucleo.Web.Controls;
using Nucleo.Web.Controls.Configuration;
using Nucleo.Web.Pages;
using Nucleo.Web.Tags;


namespace Nucleo.Web
{
	[TestClass]
	public class ControlScriptMetadataTest
	{
		#region " Supporting Classes "

		[
		WebScriptMetadata(typeof(FakeScriptMetadata)),
		WebRenderer(typeof(FakeWebRenderer)),
		WebLegacyRenderer(typeof(FakeWebLegacyRenderer))
		]
		protected class FakeAjaxControl : BaseAjaxControl
		{
			protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar) { }

			protected override void GetAjaxScriptReferences(IContentRegistrar registrar) { }
		}

		protected class FakeScriptMetadata : WebScriptMetadata
		{
			public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
			{
				return new ScriptReferencingRequestDetailsCollection
				{
					new ScriptReferencingRequestDetails("fake.js", ScriptMode.Release)
				};
			}
		}

		protected class FakeWebRenderer : WebRenderer
		{
			public override TagElement Render() { return new TagElement("SPAN"); }
		}

		protected class FakeWebLegacyRenderer : WebLegacyRenderer
		{
			public override void Render(BaseControlWriter writer) { }
		}

		protected class NewScriptMetadata : WebScriptMetadata
		{
			public override ScriptReferencingRequestDetailsCollection GetPrimaryScripts()
			{
				return new ScriptReferencingRequestDetailsCollection
				{
					new ScriptReferencingRequestDetails("new.js", ScriptMode.Release)
				};
			}
		}

		protected class NewWebRenderer : WebRenderer
		{
			public override TagElement Render() { return new TagElement("DIV"); }
		}

		protected class NewWebLegacyRenderer : WebLegacyRenderer
		{
			public override void Render(BaseControlWriter writer) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingScriptMetadataReturnsCorrectObjects()
		{
			//Arrange
			FakeAjaxControl control = new FakeAjaxControl();
			control.Page = new Page();

			//Act
			var results = ControlScriptMetadata.GetWebScriptMetadata(control);

			//Assert
			Assert.AreEqual(2, results.Length);
			Assert.IsInstanceOfType(results[1], typeof(FakeScriptMetadata));
			Assert.AreEqual(1, results[1].GetPrimaryScripts().Count);
			Assert.AreEqual("fake.js", results[1].GetPrimaryScripts()[0].Path);
		}

		#endregion
	}
}
