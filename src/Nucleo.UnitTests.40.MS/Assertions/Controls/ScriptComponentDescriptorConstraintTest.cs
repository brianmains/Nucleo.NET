using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web;


namespace Nucleo.Assertions.Controls
{
	[TestClass]
	public class ScriptComponentDescriptorConstraintTest
	{
		#region " Test Classes "

		protected class TestControl : BaseAjaxControl
		{
			protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar)
			{
				registrar.AddDescriptor(new ScriptDescriptionRequestDetails(this, typeof(TestControl), this.ID));
			}
		}

		protected class TestExtender : BaseAjaxExtender
		{
			protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar, System.Web.UI.Control targetControl)
			{
				registrar.AddDescriptor(new ScriptDescriptionRequestDetails(this, typeof(TestControl), targetControl.ID));
			}
		}

		#endregion



		#region " Tests "

		[Test]
		public void MatchingControlsOnTypeWorksOK()
		{
			//Arrange
			var control = new TestControl();
			control.ID = "TestControl";
			var constraint = new ScriptComponentDescriptorConstraint(control);

			//Act
			var registry = new ContentRegistrar();
			((IAjaxScriptableComponent)control).GetAjaxScriptDescriptors(registry, control);
			
			//Assert
			Assert.IsTrue(constraint.Matches(registry), "Values in registry didn't match");
		}

		[Test]
		public void MatchingExtendersOnTypeWorksOK()
		{
			//Arrange
			var control = new System.Web.UI.WebControls.TextBox();
			control.ID = "test";
			var extender = new TestExtender();

			extender.ID = "TestControl";
			var constraint = new ScriptComponentDescriptorConstraint(extender);

			//Act
			var registry = new ContentRegistrar();
			((IAjaxScriptableComponent)extender).GetAjaxScriptDescriptors(registry, control);

			//Assert
			Assert.IsTrue(constraint.Matches(registry), "Values in registry didn't match");
		}

		[Test]
		public void SettingUpControlsTypeViaTypeClassWorksOK()
		{
			//Arrange
			var control = new TestControl();

			//Act
			var constraint = new ScriptComponentDescriptorConstraint(control);

			//Assert
			Assert.AreEqual(control, constraint.Expected);
			Assert.AreEqual(typeof(ScriptComponentDescriptorConstraintTest).FullName + "+TestControl", constraint.ExpectedTypeName);
		}

		[Test]
		public void SettingUpControlsTypeViaTypeNameWorksOK()
		{
			//Arrange
			var control = new TestControl();

			//Act
			var constraint = new ScriptComponentDescriptorConstraint(control, "Nucleo.Test");

			//Assert
			Assert.AreEqual(control, constraint.Expected);
			Assert.AreEqual("Nucleo.Test", constraint.ExpectedTypeName);
		}

		[Test]
		public void SettingUpExtendersTypeViaTypeClassWorksOK()
		{
			//Arrange
			var extender = new TestExtender();

			//Act
			var constraint = new ScriptComponentDescriptorConstraint(extender);

			//Assert
			Assert.AreEqual(extender, constraint.Expected);
			Assert.AreEqual(typeof(ScriptComponentDescriptorConstraintTest).FullName + "+TestExtender", constraint.ExpectedTypeName);
		}

		[Test]
		public void SettingUpExtendersTypeViaTypeNameWorksOK()
		{
			//Arrange
			var extender = new TestExtender();

			//Act
			var constraint = new ScriptComponentDescriptorConstraint(extender, "Nucleo.Test");

			//Assert
			Assert.AreEqual(extender, constraint.Expected);
			Assert.AreEqual("Nucleo.Test", constraint.ExpectedTypeName);
		}

		#endregion
	}
}
