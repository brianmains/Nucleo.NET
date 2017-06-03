using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Orm.Configuration;


namespace Nucleo.Orm.Discovery
{
	[
	TestClass,
	Isolated
	]
	public class ConfigurationUnitOfWorkDiscoveryStrategyTest
	{
		[
		TestMethod,
		ExpectedException(typeof(NullReferenceException))
		]
		public void CreatingWithInvalidRegistrationTypeThrowsException()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(UnitOfWorkSection));
			Isolate.WhenCalled(() => UnitOfWorkSection.Instance).WillReturn(new UnitOfWorkSection
			{
				Registrations = new UnitOfWorkRegistrationElementCollection
					{
						new UnitOfWorkRegistrationElement  { Name = "X", TypeName = "Y" }
					}
			});

			var strategy = new ConfigurationUnitOfWorkDiscoveryStrategy();

			//Act
			var uow = strategy.LocateUnitOfWork(new UnitOfWorkDiscoveryOptions { Name = "X" });

			//Assert
			
		}

		[TestMethod]
		public void CreatingWithNoRegistrationReturnsNull()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(UnitOfWorkSection));
			Isolate.WhenCalled(() => UnitOfWorkSection.Instance).WillReturn(new UnitOfWorkSection
				{
					Registrations = new UnitOfWorkRegistrationElementCollection
					{
						new UnitOfWorkRegistrationElement  { Name = "X", TypeName = "Y" }
					}
				});

			var strategy = new ConfigurationUnitOfWorkDiscoveryStrategy();

			//Act
			var uow = strategy.LocateUnitOfWork(new UnitOfWorkDiscoveryOptions { Name = "Z" });

			//Assert
			Assert.IsNull(uow);
		}

		[TestMethod]
		public void CreatingWithNullUnitOfWorkReturnsNull()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(UnitOfWorkSection));
			Isolate.WhenCalled(() => UnitOfWorkSection.Instance).WillReturn(null);

			var strategy = new ConfigurationUnitOfWorkDiscoveryStrategy();
			
			//Act
			var uow = strategy.LocateUnitOfWork(new UnitOfWorkDiscoveryOptions { Name = "X" });

			//Assert
			Assert.IsNull(uow);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void LocatingUnitOfWorkWithNullOptionsThrowsException()
		{
			//Arrange
			var strategy = new ConfigurationUnitOfWorkDiscoveryStrategy();

			//Act
			strategy.LocateUnitOfWork(null);

			//Assert

		}
	}
}
