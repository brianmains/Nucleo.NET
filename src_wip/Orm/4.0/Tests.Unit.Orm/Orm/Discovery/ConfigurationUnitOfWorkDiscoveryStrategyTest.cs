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
        protected class TestUOW : IUnitOfWork
        {
            public void SaveChanges() { }
        }

		[TestMethod]
		public void CreatingWithInvalidRegistrationTypeReturnsNull()
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
            Assert.IsNotNull(uow);
            Assert.IsNull(uow.UnitOfWorkType);
		}

		[TestMethod]
		public void CreatingWithValidButMissingRegistrationReturnsNull()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(UnitOfWorkSection));
			Isolate.WhenCalled(() => UnitOfWorkSection.Instance).WillReturn(new UnitOfWorkSection
				{
					Registrations = new UnitOfWorkRegistrationElementCollection
					{
						new UnitOfWorkRegistrationElement  { Name = "X", TypeName = typeof(TestUOW).AssemblyQualifiedName }
					}
				});

			var strategy = new ConfigurationUnitOfWorkDiscoveryStrategy();

			//Act
			var uow = strategy.LocateUnitOfWork(new UnitOfWorkDiscoveryOptions { Name = "Z" });

			//Assert
			Assert.IsNull(uow);
		}

        [TestMethod]
        public void CreatingWithValidRegistrationReturnsUnitOfWork()
        {
            //Arrange
            Isolate.Fake.StaticMethods(typeof(UnitOfWorkSection));
            Isolate.WhenCalled(() => UnitOfWorkSection.Instance).WillReturn(new UnitOfWorkSection
            {
                Registrations = new UnitOfWorkRegistrationElementCollection
					{
						new UnitOfWorkRegistrationElement  { Name = "X", TypeName = typeof(TestUOW).AssemblyQualifiedName }
					}
            });

            var strategy = new ConfigurationUnitOfWorkDiscoveryStrategy();

            //Act
            var uow = strategy.LocateUnitOfWork(new UnitOfWorkDiscoveryOptions { Name = "X" });

            //Assert
            Assert.IsNotNull(uow);
            Assert.AreEqual(uow.UnitOfWorkType, typeof(TestUOW));
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
			var strategy = new ConfigurationUnitOfWorkDiscoveryStrategy().LocateUnitOfWork(null);
		}
	}
}
