using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Collections;
using Nucleo.Validation;
using Nucleo.Validation.Settings;


namespace Nucleo.Validation
{
	[TestClass]
	public class ValidationManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void ValidatingBusinessTestClassToTriggerErrorsValidatesCorrectly()
		{
			ValidationManager manager = ValidationManager.Create(ConfigurationValidationSettings.Create());
			Assert.AreEqual(false, manager.ThrowOnInvalid);
			Assert.AreEqual(false, manager.UseFirstFoundProviderOnly);

			BusinessTestClass test1 = new BusinessTestClass();
			test1.Name = string.Empty;
			test1.City = string.Empty;
			test1.State = string.Empty;
			test1.ZipCode = 0;

			BusinessTestClass test2 = new BusinessTestClass();
			test2.Name = null;
			test2.City = null;
			test2.State = null;
			test2.ZipCode = 100000;

			var session1 = manager.Validate(test1);
			var session2 = manager.Validate(test2);

			Assert.AreEqual(4, session1.Items.Count);
			Assert.AreEqual(4, session2.Items.Count);

			Assert.IsTrue(session1.Items.IsInstanceOf<ValidationItem, ErrorValidationType>(j => j.ValidationResult), "A validation result isn't an error");
			Assert.IsTrue(session2.Items.IsInstanceOf<ValidationItem, ErrorValidationType>(j => j.ValidationResult), "A validation result isn't an error");
		}

		[TestMethod]
		public void ValidatingBusinessTestClassToTriggerInformationalMessagesValidatesCorrectly()
		{
			ValidationManager manager = ValidationManager.Create(ConfigurationValidationSettings.Create());
			Assert.AreEqual(false, manager.ThrowOnInvalid);
			Assert.AreEqual(false, manager.UseFirstFoundProviderOnly);

			BusinessTestClass test = new BusinessTestClass();
			test.Name = "Ted";
			test.City = "Pittsburgh";
			test.State = "NY";
			test.ZipCode = 90210;

			var session = manager.Validate(test);

			Assert.AreEqual(4, session.Items.Count);

			Assert.IsTrue(session.Items.IsInstanceOf<ValidationItem, InformationValidationType>(j => j.ValidationResult), "A validation result isn't an informational item");
		}

		[TestMethod]
		public void ValidatingBusinessTestClassToTriggerWarningMessagesValidatesCorrectly()
		{
			ValidationManager manager = ValidationManager.Create(ConfigurationValidationSettings.Create());
			Assert.AreEqual(false, manager.ThrowOnInvalid);
			Assert.AreEqual(false, manager.UseFirstFoundProviderOnly);

			BusinessTestClass test = new BusinessTestClass();
			test.Name = "T";
			test.City = "P";
			test.State = "NYC";
			test.ZipCode = 555;

			var session = manager.Validate(test);

			Assert.AreEqual(4, session.Items.Count);

			Assert.IsTrue(session.Items.IsInstanceOf<ValidationItem, WarningValidationType>(j => j.ValidationResult), "A validation result isn't a warning");
		}

		#endregion
	}
}
