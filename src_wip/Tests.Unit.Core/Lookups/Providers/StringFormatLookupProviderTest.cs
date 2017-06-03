using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Lookups.Identification;
using Nucleo.Lookups.Repositories;


namespace Nucleo.Lookups.Providers
{
	[TestClass]
	public class StringFormatLookupProviderTest
	{
		protected class TestLookupRepository : ILookupRepository
		{
			public string Name
			{
				get;
				set;
			}

			public LookupCollection GetAllValues(LookupCriteria criteria)
			{
				throw new NotImplementedException();
			}
		}


		[TestMethod]
		public void CreatesOKWhenValidValue()
		{
			new StringFormatLookupProvider("{0}");
		}

		[TestMethod]
		public void GettingRepositoryAssignsOK()
		{
			var provider = new StringFormatLookupProvider("Nucleo.Lookups.Providers.StringFormatLookupProviderTest+{0}," + typeof(TestLookupRepository).Assembly.GetName().Name);
			var repos = provider.GetRepository(new NameLookupIdentifier { Name = "TestLookupRepository" });

			Assert.IsInstanceOfType(repos, typeof(TestLookupRepository));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void ThrowsWhenFormatIsEmpty()
		{
			new StringFormatLookupProvider(string.Empty);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void ThrowsWhenFormatIsNull()
		{
			new StringFormatLookupProvider(null);
		}
	}
}
