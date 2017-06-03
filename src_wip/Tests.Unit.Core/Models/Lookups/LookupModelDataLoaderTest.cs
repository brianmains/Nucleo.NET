using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Lookups;
using Nucleo.Lookups.Repositories;



namespace Nucleo.Models.Lookups
{
	[TestClass]
	public class LookupModelDataLoaderTest
	{
		#region " Test Classes "

		public class FakeLookupRepository : ILookupRepository
		{
			#region ILookupRepository Members

			public string Name
			{
				get { return "Test"; }
				set { }
			}

			public LookupCollection GetAllValues(LookupCriteria criteria)
			{
				return new LookupCollection
				{
					new Lookup("PA", "Pennsylvania", "PA"),
					new Lookup("MD", "Maryland", "MD"),
					new Lookup("DC", "Washington DC", "DC")
				};
			}

			#endregion
		}


		#endregion



		#region " Tests "

		[TestMethod]
		public void LoadingLookupDataWorksOK()
		{
			//Arrange
			var repos = new FakeLookupRepository();

			var mgr = Isolate.Fake.Instance<LookupManager>();
			Isolate.WhenCalled(() => mgr.GetLookupRepository(null)).WillReturn(repos);

			var lookupBinding = Isolate.Fake.Instance<ILookupInjection>();
			Isolate.WhenCalled(() => lookupBinding.LookupName).WillReturn("Test");

			//Act
			var loader = new LookupModelDataLoader(mgr);
			var result = loader.GetModelData(new ModelMemberMetadata(null, null, lookupBinding));

			//Assert
			Assert.IsNotNull(result, "Result is null");
			Assert.IsInstanceOfType(result, typeof(LookupCollection), "Not a lookup collection");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PassingInNullMetadataThrowsException()
		{
			//Arrange
			var mgr = Isolate.Fake.Instance<LookupManager>();

			var loader = new LookupModelDataLoader(mgr);
			var metadata = Isolate.Fake.Instance<ModelMemberMetadata>();
			Isolate.WhenCalled(() => metadata.Model).WillReturn(new object());
			Isolate.WhenCalled(() => metadata.InjectionDefinition).WillReturn(Isolate.Fake.Instance<IModelInjection>());

			//Act
		
			//Assert
			ExceptionTester.CheckException(true, (s) => { loader.GetModelData(metadata); });
		}

		[TestMethod]
		public void PassingInvalidReferenceThrowsException()
		{
			//Arrange
			var mgr = Isolate.Fake.Instance<LookupManager>();

			var loader = new LookupModelDataLoader(mgr);
			var metadata = Isolate.Fake.Instance<ModelMemberMetadata>();
			Isolate.WhenCalled(() => metadata.Model).WillReturn(new object());
			Isolate.WhenCalled(() => metadata.InjectionDefinition).WillReturn(Isolate.Fake.Instance<IModelInjection>());

			//Act

			//Assert
			ExceptionTester.CheckException(true, (s) => { loader.GetModelData(metadata); });
		}

		#endregion
	}
}
