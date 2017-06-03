using System;
using System.Collections.Generic;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.ButtonControls;
using Nucleo.Web.Pages;


namespace Nucleo.Web
{
	[TestClass]
	public class ScriptObjectHelperTest
	{
		#region " Supporting Classes "

		protected class TestExtenderControl : ExtenderControl
		{
			protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl)
			{
				return new ScriptDescriptorCollection();
			}

			protected override IEnumerable<ScriptReference> GetScriptReferences()
			{
				return new ScriptReferenceCollection();
			}
		}

		protected class TestScriptControl : ScriptControl
		{
			protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
			{
				return new ScriptDescriptorCollection();
			}

			protected override IEnumerable<ScriptReference> GetScriptReferences()
			{
				return new ScriptReferenceCollection();
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingControlDescriptorAssignsCorrectValues()
		{
			TestScriptControl control = new TestScriptControl();
			control.ID = "testcontrol";

			var descriptor = ScriptObjectHelper.GetDescriptor(control, control.ID);
			Assert.IsNotNull(descriptor);
			Assert.AreEqual(descriptor.ElementID, control.ID);
		}

		[TestMethod]
		public void GettingControlScriptReferenceReturnsCorrectValues()
		{
			Button button = new Button();
			FakePage test = new FakePage();
			test.Controls.Add(button);
			
			string script = ScriptObjectHelper.GetScriptReference(button, typeof(BaseAjaxControl), ScriptMode.Debug, false);
			Assert.AreEqual("Nucleo.Web.BaseAjaxControl.debug.js", script);
		}

		[TestMethod]
		public void GettingScriptReferenceObjectUsingEmbeddedResourceSetsOriginalPath()
		{
			Button button = new Button();
			NucleoScriptReference reference = null;

			reference = ScriptObjectHelper.GetScriptReferenceObject(button, ScriptMode.Debug, true);
			Assert.AreEqual("Nucleo.Web.ButtonControls.Button.debug.js", reference.OriginalPath);

			reference = ScriptObjectHelper.GetScriptReferenceObject(button, ScriptMode.Debug, false);
			Assert.IsTrue(string.IsNullOrEmpty(reference.OriginalPath));
		}

		#endregion
	}
}
