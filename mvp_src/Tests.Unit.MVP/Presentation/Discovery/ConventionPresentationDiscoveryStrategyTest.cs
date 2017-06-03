using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Presentation;
using Nucleo.Views;


#region " Test Classes "

namespace Nucleo.Tests.Presentation
{
	using Nucleo.Tests.Views;

	public class TestPresenter : BasePresenter<IView>
	{
		public TestPresenter(IView view)
			: base(view) { }
	}

	public class PresenterLevelTestPresenter : BasePresenter<IView>
	{
		public PresenterLevelTestPresenter(IView view)
			: base(view) { }
	}

	public interface IPresenterLevelTestView : IView { }

	public class PresenterLevelTestView : View, ITestView { }
}

namespace Nucleo.Tests.Views
{
	public interface ITestView : IView { }

	public class TestView : View, ITestView { }

	public interface INonTestView : IView { }

	public class NonTestView : View, ITestView { }
}

#endregion

namespace Nucleo.Presentation.Discovery
{
	using Nucleo.Tests.Presentation;
	using Nucleo.Tests.Views;

	[TestClass]
	public class ConventionPresentationDiscoveryStrategyTest
	{
		[TestMethod]
		public void CantFindingPresenterReturnsNull()
		{
			//Arrange
			var view = new NonTestView();
			var strategy = new ConventionPresentationDiscoveryStrategy();

			//Act
			var type = strategy.FindPresenterType(new PresenterDiscoveryOptions { View = view });

			//Assert
			Assert.IsNull(type);
		}

		[TestMethod]
		public void FindingPresenterInSameNamespaceWorksOK()
		{
			//Arrange
			var view = new PresenterLevelTestView();
			var strategy = new ConventionPresentationDiscoveryStrategy();

			//Act
			var type = strategy.FindPresenterType(new PresenterDiscoveryOptions { View = view });

			//Assert
			Assert.IsNotNull(type);
			Assert.IsTrue(type.FullName.Contains("TestPresenter"));
		}

		[TestMethod]
		public void FindingPresenterWithMatchingTypeWorksOK()
		{
			//Arrange
			var view = new TestView();
			var strategy = new ConventionPresentationDiscoveryStrategy();

			//Act
			var type = strategy.FindPresenterType(new PresenterDiscoveryOptions { View = view });

			//Assert
			Assert.IsNotNull(type);
			Assert.IsTrue(type.FullName.Contains("TestPresenter"));
		}
	}
}
