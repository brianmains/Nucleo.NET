using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


using Nucleo.EventArguments;
using Nucleo.Reflection;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.Presentation.Creation;


namespace Nucleo.Presentation
{
	[TestClass]
	public class PresentationManagerTest
	{
		#region " Test Classes "

		public class FakePresenter : BasePresenter
		{
			public FakePresenter(IView view) : base(view) { }
		}

		public class FakePresenter2 : BasePresenter<IFakeView>
		{
			public FakePresenter2(IFakeView view) : base(view) { }
		}

		public interface IFakeView : IView
		{

		}

		public class FailedView : Nucleo.Web.Views.BaseViewUserControl
		{
			public IPresenter GetPresenter()
			{
				return this.CreatePresenter();
			}
		}

		public class FailedPresenter : BaseWebPresenter
		{
			public FailedPresenter(IView view)
				: base(view) { }
		}

		[PresenterBinding(typeof(SamplePresenter))]
		public class SampleView : Nucleo.Web.Views.BaseViewUserControl
		{
			public IPresenter GetPresenter()
			{
				return this.CreatePresenter();
			}
		}

		public class SamplePresenter : BaseWebPresenter
		{
			public SamplePresenter(IView view)
				: base(view) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingGenericPresenterWorksOK()
		{
			//Arrange
			var mgr = PresentationManager.Create();
			var view = Isolate.Fake.Instance<IFakeView>();
			
			//Act
			var presenter = mgr.Load<FakePresenter2, IFakeView>(view);

			//Assert
			Assert.IsNotNull(presenter);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingPresenterFiresEvents()
		{
			//Arrange
			var mgr = Isolate.Fake.Instance<PresentationManager>(Members.CallOriginal);
			var view = Isolate.Fake.Instance<IView>();
			var outputPresenter = default(IPresenter);

			PresentationManager.PresenterFound += delegate(object sender, PresenterEventArgs e)
			{
				outputPresenter = e.Presenter;
			};

			//Act
			
			var presenter = mgr.Load<FakePresenter>(view);

			//Assert
			Assert.AreEqual(presenter, outputPresenter);
		}

		[TestMethod]
		public void CreatingPresenterWorksOK()
		{
			//Arrange
			var mgr = PresentationManager.Create();
			var view = Isolate.Fake.Instance<IView>();

			//Act
			var presenter = mgr.Load<FakePresenter>(view);
			
			//Assert
			Assert.IsNotNull(presenter);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingPresenterWithIPresenterCreatorReturnsThatType()
		{
			//Arrange
			var contract = Isolate.Fake.Instance<IPresenter>();
			var builder = Isolate.Fake.Instance<IPresenterCreator>();
			Isolate.WhenCalled(() => builder.Create(null, null)).WillReturn(contract);

			//Act
			var mgr = PresentationManager.Create(new PresenterOptions { Creator = builder });
			var result = mgr.Load(typeof(IPresenter), null);

			//Assert
			Assert.AreEqual(contract, result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingPresenterWithNullOptionsThrowsException()
		{
			//Assert
			ExceptionTester.CheckException(true, (s) => { PresentationManager.Create(null); });
		}

		[TestMethod]
		public void GetNullPresenterWhenMissingPresenterBinding()
		{
			//Arrange
			var view = Isolate.Fake.Instance<IView>();

			//Act
			var mgr = PresentationManager.Create();
			var presenter = mgr.Load(view);

			//Assert
			Assert.IsNull(presenter);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GetNullPresenterWhenMissingPresenterInstance()
		{
			//Arrange
			var creator = Isolate.Fake.Instance<IPresenterCreator>();
			Isolate.WhenCalled(() => creator.Create(null, null)).WillReturn(null);

			var view = Isolate.Fake.Instance<IView>();
			Isolate.WhenCalled(() => view.GetType().GetCustomAttribute<PresenterBindingAttribute>(true)).WillReturn(null);

			//Act
			var mgr = PresentationManager.Create(new PresenterOptions { Creator = creator });
			var presenter = mgr.Load(view);

			//Assert
			Assert.IsNull(presenter);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GetNullPresenterWhenMissingPresenterType()
		{
			//Arrange
			var view = Isolate.Fake.Instance<IView>();
			Isolate.WhenCalled(() => view.GetType().GetCustomAttribute<PresenterBindingAttribute>(true)).WillReturn(null);

			//Act
			var mgr = PresentationManager.Create();
			var presenter = mgr.Load(view);

			//Assert
			Assert.IsNull(presenter);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoadViewUsingPresenterBindingWorksOK()
		{
			//Arrange
			var view = new SampleView();
			var mgr = PresentationManager.Create();

			//Act
			var presenter = mgr.Load(view);

			//Assert
			Assert.IsTrue(presenter.IsInstanceOf<SamplePresenter>());
		}

		#endregion
	}
}
