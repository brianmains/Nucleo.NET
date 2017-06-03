using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Dependencies
{
	[TestClass]
	public class DictionaryBasedDependencyResolverTest
	{
		protected interface ITestInterface { }

		protected class TestClass : ITestInterface { }

		protected interface INotFoundInterface { }


		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullDictionaryThrowsException()
		{
			new DictionaryBasedDependencyResolver(null);
		}

		[TestMethod]
		public void ServingByGenericNotInDictionaryReturnsNull()
		{
			var resolver = new DictionaryBasedDependencyResolver(new Dictionary<Type, object>
			{
				{ typeof(ITestInterface), new TestClass() }
			});

			var dep = resolver.GetDependency<INotFoundInterface>();

			Assert.IsNull(dep);
		}

		[TestMethod]
		public void ServingByGenericWorksOK()
		{
			var resolver = new DictionaryBasedDependencyResolver(new Dictionary<Type, object>
			{
				{ typeof(ITestInterface), new TestClass() }
			});

			var dep = resolver.GetDependency<ITestInterface>();

			Assert.IsNotNull(dep);
			Assert.IsInstanceOfType(dep, typeof(TestClass));
		}

		[TestMethod]
		public void ServingByTypeNotInDictionaryReturnsNull()
		{
			var resolver = new DictionaryBasedDependencyResolver(new Dictionary<Type, object>
			{
				{ typeof(ITestInterface), new TestClass() }
			});

			var dep = resolver.GetDependency(typeof(INotFoundInterface));

			Assert.IsNull(dep);
		}

		[TestMethod]
		public void ServingByTypeWorksOK()
		{
			var resolver = new DictionaryBasedDependencyResolver(new Dictionary<Type, object>
			{
				{ typeof(ITestInterface), new TestClass() }
			});

			var dep = resolver.GetDependency(typeof(ITestInterface));

			Assert.IsNotNull(dep);
			Assert.IsInstanceOfType(dep, typeof(TestClass));
		}
	}
}
