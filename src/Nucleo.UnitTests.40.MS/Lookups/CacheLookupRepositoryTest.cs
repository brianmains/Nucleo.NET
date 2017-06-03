using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Lookups
{
	[TestClass]
	public class CacheLookupRepositoryTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingRepositoryWorksOK()
		{
			//Arrange
			var cache = Isolate.Fake.Instance<ILookupCache>();
			var repos = Isolate.Fake.Instance<ILookupRepository>();

			//Act
			var output = new CacheLookupRepository(cache, repos);

			//Assert
			Assert.IsNotNull(output);
		}

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var repos = Isolate.Fake.Instance<CacheLookupRepository>(Members.CallOriginal, ConstructorWillBe.Ignored);

			//Act
			repos.Name = "X";

			//Assert
			Assert.AreEqual("X", repos.Name);
		}

		[TestMethod]
		public void GettingValuesReturnsCache()
		{
			//Arrange
			var cache = Isolate.Fake.Instance<ILookupCache>();
			var repos = Isolate.Fake.Instance<ILookupRepository>();

			Isolate.WhenCalled(() => cache.LoadFromCache("Test", null)).WillReturn(new LookupCollection
				{
					new Lookup { Name = "A", Value = "1" }
				});

			var lookup = new CacheLookupRepository(cache, repos);

			//Act
			var results = lookup.GetAllValues(new LookupCriteria());

			//Assert
			Assert.IsNotNull(results);
			Assert.AreEqual(1, results.Count);
		}

		[TestMethod]
		public void GettingValuesWithoutCacheReturnsCache()
		{
			//Arrange
			var cache = Isolate.Fake.Instance<ILookupCache>();
			var repos = Isolate.Fake.Instance<ILookupRepository>();

			Isolate.WhenCalled(() => cache.LoadFromCache("Test", null)).WillReturn(null);
			Isolate.WhenCalled(() => repos.GetAllValues(null)).WillReturn(new LookupCollection
				{
					new Lookup { Name = "A", Value = "1" },
					new Lookup { Name = "B", Value = "2" }
				});

			var lookup = new CacheLookupRepository(cache, repos);

			//Act
			var results = lookup.GetAllValues(new LookupCriteria());

			//Assert
			Assert.IsNotNull(results);
			Assert.AreEqual(2, results.Count);
		}

		#endregion
	}
}
