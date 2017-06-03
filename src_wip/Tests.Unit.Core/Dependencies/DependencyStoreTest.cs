using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Dependencies
{
	[TestClass]
	public class DependencyStoreTest
	{
		[TestMethod]
		public void SettingResolverAssignsOK()
		{
			var resolver = Isolate.Fake.Instance<IDependencyResolver>();

			DependencyStore.Resolver = resolver;

			Assert.AreEqual(resolver, DependencyStore.Resolver);
		}
	}
}
