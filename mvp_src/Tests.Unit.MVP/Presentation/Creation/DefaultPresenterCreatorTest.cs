using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Core;
using Nucleo.Dependencies;
using Nucleo.Presentation;
using Nucleo.Views;


namespace Nucleo.Presentation.Creation
{
	[TestClass]
	public class DefaultPresenterCreatorTest
	{
		protected class TestService : IServiceProvider
		{
			public object GetService(Type serviceType)
			{
				return null;
			}
		}

		protected class TestPresenter : BasePresenter<TestView>
		{
			public TestPresenter(TestView view)
				: base(view) { }
		}

		protected class TestPresenter2 : BasePresenter<TestView>
		{
			public IServiceProvider Service;

			public TestPresenter2(TestView view, IServiceProvider service)
				: base(view)
			{
				Service = service;
			}
		}

		protected class TestView : View
		{

		}



		[TestMethod]
		public void CreatingByTypeAndViewCreatesPresenterOK()
		{
			var creator = new DefaultPresenterCreator();
			var presenter = creator.Create(typeof(TestPresenter), new TestView());

			Assert.IsNotNull(presenter);
			Assert.IsInstanceOfType(presenter, typeof(TestPresenter));
		}

		[TestMethod]
		public void CreatingByTypeAndViewWorksSetsViewOK()
		{
			var creator = new DefaultPresenterCreator();
			var presenter = creator.Create(typeof(TestPresenter), new TestView());

			Assert.IsNotNull(presenter.View);
			Assert.IsInstanceOfType(presenter.View, typeof(TestView));
		}

		[TestMethod]
		public void CreatingUsingDependencyResolverWorksOK()
		{
			var resolver = Isolate.Fake.Instance<IDependencyResolver>();
			Isolate.WhenCalled(() => resolver.GetDependency(null)).WillReturn(new TestService());

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.Resolver).WillReturn(resolver);

			var creator = new DefaultPresenterCreator();
			var presenter = creator.Create(typeof(TestPresenter2), new TestView()) as TestPresenter2;

			Assert.IsNotNull(presenter.Service);
			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullPresenterThrowsException()
		{
			var creator = new DefaultPresenterCreator();
			creator.Create(null, new TestView());

		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void NullViewThrowsException()
		{
			var creator = new DefaultPresenterCreator();
			creator.Create(typeof(TestPresenter), null);
		}
	}
}
