using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Providers;
using Nucleo.TestingTools;
using Nucleo.Validation.Configuration;
using Nucleo.Validation.Settings;


namespace Nucleo.Validation
{
	[TestClass]
	public class ValidationManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingValidationManagerPullsConfigurationInformation()
		{
			//Arrange
			var settings = new FakeValidationSettings
			{
				ThrowOnInvalid = true,
				UseFirstFoundProviderOnly = false,
				Providers = new ValidationProviderCollection
				{
					new FakeValidationProvider(true, new ValidationItemCollection())
				}
			};

			//Act
			var validationManager = ValidationManager.Create(settings);

			//Assert
			Assert.AreEqual(true, validationManager.ThrowOnInvalid);
			Assert.AreEqual(false, validationManager.UseFirstFoundProviderOnly);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ValidatingObjectsWhenUsingFirstProviderOnlyReturnsFirstProviderResults()
		{
			//Arrange
			var settings = new FakeValidationSettings
			{
				ThrowOnInvalid = false,
				UseFirstFoundProviderOnly = true,
				Providers = new ValidationProviderCollection
				{
					new FakeValidationProvider(true, new ValidationItemCollection
					{
						new ValidationItem("Test1", new InformationValidationType(), "Test"),
						new ValidationItem("Test2", new ErrorValidationType(), "Test")
					}),
					new FakeValidationProvider(true, new ValidationItemCollection
					{
						new ValidationItem("Test3", new InformationValidationType(), "Test"),
						new ValidationItem("Test4", new ErrorValidationType(), "Test")
					})
				}
			};

			var obj = new ValidationTypeTest();
			var manager = ValidationManager.Create(settings);

			//Act
			var session = manager.Validate(obj);

			//Assert
			Assert.AreEqual(1, session.Items.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void ValidatingObjectsWhenUsingThrowOnInvalidThrowsException()
		{
			//Arrange
			var settings = new FakeValidationSettings
			{
				ThrowOnInvalid = true,
				UseFirstFoundProviderOnly = false,
				Providers = new ValidationProviderCollection
				{
					new FakeValidationProvider(true, new ValidationItemCollection
					{
						new ValidationItem("Test1", new InformationValidationType(), "Test"),
						new ValidationItem("Test2", new ErrorValidationType(), "Test")
					}),
					new FakeValidationProvider(true, new ValidationItemCollection
					{
						new ValidationItem("Test3", new InformationValidationType(), "Test"),
						new ValidationItem("Test4", new ErrorValidationType(), "Test")
					})
				}
			};

			//Act
			var obj = new System.Data.DataTable();
			var manager = ValidationManager.Create(settings);

			//Assert
			ExceptionTester.CheckException(true, (src) => { manager.Validate(obj); });
		}

		#endregion
	}
}
