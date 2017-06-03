using System;
using System.Collections.Generic;
using System.Linq;
using TypeMock.ArrangeActAssert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Configuration;
using Nucleo.Lookups.Configuration;
using Nucleo.Lookups.Identification;
using Nucleo.Lookups.Repositories;


namespace Nucleo.Lookups.Providers
{
	[TestClass]
	public class ConfigurationLookupProviderTest
	{
		protected class LookupRepository : ILookupRepository
		{

			public string Name
			{
				get;
				set;
			}

			public LookupCollection GetAllValues(LookupCriteria criteria)
			{
				return new LookupCollection();
			}
		}

		[TestMethod]
		public void MatchingLookupNameReturnsValidRepository()
		{
			//Arrange
			var section = new LookupRepositoriesSection();
			section.Mappings.Add(new NameTypeElement { Name = "Default", Type = typeof(LookupRepository).AssemblyQualifiedName });

			Isolate.Fake.StaticMethods(typeof(LookupRepositoriesSection));
			Isolate.WhenCalled(() => LookupRepositoriesSection.Instance).WillReturn(section);

			//Act
			var provider = new ConfigurationLookupProvider();
			var result = provider.GetRepository(new NameLookupIdentifier { Name = "Default" });

			//Assert
			Assert.IsNotNull(result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void MissingLookupNameReturnsNull()
		{
			//Arrange
			var section = new LookupRepositoriesSection();
			section.Mappings.Add(new NameTypeElement { Name = "Default", Type = typeof(LookupRepository).AssemblyQualifiedName });

			Isolate.Fake.StaticMethods(typeof(LookupRepositoriesSection));
			Isolate.WhenCalled(() => LookupRepositoriesSection.Instance).WillReturn(section);

			//Act
			var provider = new ConfigurationLookupProvider();
			var repos = provider.GetRepository(new NameLookupIdentifier { Name = "Other" });

			//Assert
			Assert.IsNull(repos);

			Isolate.CleanUp();
		}
	}
}
