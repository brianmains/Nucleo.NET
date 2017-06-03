using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.Validation.Configuration;


namespace Nucleo.Validation.Settings
{
	[TestClass]
	public class ConfigurationValidationSettingsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingBaseSettingsWorksOK()
		{
			//Arrange
			var sectionFake = Isolate.Fake.Instance<ValidationSettingsSection>(Members.CallOriginal);
			sectionFake.ThrowOnInvalid = true;
			sectionFake.UseFirstFoundProviderOnly = true;

			Isolate.Fake.StaticMethods(typeof(ValidationSettingsSection));
			Isolate.WhenCalled(() => ValidationSettingsSection.Instance).WillReturn(sectionFake);

			//Act
			var settings = ConfigurationValidationSettings.Create();

			//Assert
			Assert.AreEqual(true, settings.ThrowOnInvalid);
			Assert.AreEqual(true, settings.UseFirstFoundProviderOnly);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingProvidersWorksOK()
		{
			//Arrange
			var sectionFake = new ValidationSettingsSection();
			sectionFake.Providers.Add(new ProviderSettings("Fake1", TypeNameGenerator.GetLocalTypeName<FakeValidationProvider>()));
			sectionFake.Providers.Add(new ProviderSettings("Fake2", TypeNameGenerator.GetLocalTypeName<FakeValidationProvider>()));
			sectionFake.Providers.Add(new ProviderSettings("Fake3", TypeNameGenerator.GetLocalTypeName<FakeValidationProvider>()));

			Isolate.Fake.StaticMethods(typeof(ValidationSettingsSection));
			Isolate.WhenCalled(() => ValidationSettingsSection.Instance).WillReturn(sectionFake);

			var settingsFake = Isolate.Fake.Instance<ConfigurationValidationSettings>(Members.CallOriginal);

			//Act
			var providers = settingsFake.GetProviders();

			//Assert
			Assert.IsNotNull(providers);
			Assert.IsTrue(providers.IsNotNull(), "A provider was null");

			Isolate.CleanUp();
		}

		#endregion
	}
}
