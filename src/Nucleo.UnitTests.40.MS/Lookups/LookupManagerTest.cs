using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Configuration;
using Nucleo.Lookups.Configuration;
using Nucleo.TestingTools;


namespace Nucleo.Lookups
{
	[TestClass]
	public class LookupManagerTest
	{
		#region " Test Classes "

		protected class Lookup : ILookup
		{
			public string Name
			{
				get;
				set;
			}

			public object RepresentationCode
			{
				get;
				set;
			}

			public string Value
			{
				get;
				set;
			}
		}

		public class LookupRepository : ILookupRepository
		{
			public string Name { get; set; }

			public LookupCollection GetAllValues(LookupCriteria criteria)
			{
				return new LookupCollection
				{
					new Lookup { Name = "First", Value = "1", RepresentationCode = "F" },
					new Lookup { Name = "Second", Value = "2", RepresentationCode = "S" }
				};
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingLookupWithNullNameThrowsException()
		{
			//Arrange
			var manager = LookupManager.Create();

			//Act


			//Assert
			ExceptionTester.CheckException(true, (src) => { manager.GetLookupRepository(string.Empty); });
			ExceptionTester.CheckException(true, (src) => { manager.GetLookupRepository(null); });
		}

		[TestMethod]
		public void MatchingLookupNameReturnsValidRepository()
		{
			//Arrange
			var section = new LookupRepositoriesSection();
			section.Mappings.Add(new NameTypeElement { Name = "Default", Type = TypeNameGenerator.GetLocalTypeName<LookupRepository>() });

			Isolate.Fake.StaticMethods(typeof(LookupRepositoriesSection));
			Isolate.WhenCalled(() => LookupRepositoriesSection.Instance).WillReturn(section);

			//Act
			var manager = LookupManager.Create();
			var repos = manager.GetLookupRepository("Default");

			//Assert
			Assert.IsNotNull(repos);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void MissingLookupNameReturnsNull()
		{
			//Arrange
			var section = new LookupRepositoriesSection();
			section.Mappings.Add(new NameTypeElement { Name = "Default", Type = "Nucleo.Web.Lookups.LookupManagerTest+LookupRepository,Nucleo.UnitTests" });

			Isolate.Fake.StaticMethods(typeof(LookupRepositoriesSection));
			Isolate.WhenCalled(() => LookupRepositoriesSection.Instance).WillReturn(section);

			//Act
			var manager = LookupManager.Create();
			var repos = manager.GetLookupRepository("Other");

			//Assert
			Assert.IsNull(repos);

			Isolate.CleanUp();
		}

		#endregion
	}
}
