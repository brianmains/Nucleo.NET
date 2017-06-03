using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Core;
using Nucleo.Dependencies;


namespace Nucleo.Views.Initialization
{
	[TestClass]
	public class DefaultViewInitializerTest
	{
		#region " Test Classes "

		protected interface IService1 { }

		protected class Service1 : IService1 { }

		protected interface IService2 { }

		protected class Service2 : IService2 { }

		protected class TestView : View
		{
			[Dependency]
			public IService1 Service1 { get; set; }

			[Dependency]
			public IService2 Service2 { get; set; }
		}

		#endregion



		[TestMethod]
		public void InitializingViewInjectsReferencesIntoView()
		{
			var resolver = Isolate.Fake.Instance<IDependencyResolver>();
			Isolate.WhenCalled(() => resolver.GetDependency(typeof(IService1))).WithExactArguments().WillReturn(new Service1());
			Isolate.WhenCalled(() => resolver.GetDependency(typeof(IService2))).WithExactArguments().WillReturn(new Service2());

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.Resolver).WillReturn(resolver);

			var view = new TestView();
			var initializer = new DefaultViewInitializer();

			initializer.Initialize(view);

			Assert.IsInstanceOfType(view.Service1, typeof(Service1));
			Assert.IsInstanceOfType(view.Service2, typeof(Service2));

			Isolate.CleanUp();
		}
	}
}
