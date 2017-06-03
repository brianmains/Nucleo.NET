using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


using Nucleo.Presentation;
using Nucleo.Web.Presentation;


namespace Nucleo.Web.Views
{
	[TestClass]
	public class BaseViewPageTest
	{
		#region " Test Classes "

		public class FailedView : BaseViewUserControl
		{
			public IPresenter GetPresenter()
			{
				return this.CreatePresenter();
			}
		}

		public class FailedPresenter : BaseWebPresenter
		{
			public FailedPresenter(FailedView view)
				: base(view) { }
		}

		[PresenterBinding(typeof(SamplePresenter))]
		public class SampleView : BaseViewUserControl
		{
			public IPresenter GetPresenter()
			{
				return this.CreatePresenter();
			}
		}

		public class SamplePresenter : BaseWebPresenter
		{
			public SamplePresenter(SampleView view)
				: base(view) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void PresenterBindingAttributeFails()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(PresentationManager));
			Isolate.WhenCalled(() => PresentationManager.Create()).WillReturn(null);

			var sampleView = new FailedView();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (s) => { sampleView.GetPresenter(); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PresenterBindingAttributeWorksOK()
		{
			//Arrange
			var sampleView = new SampleView();

			var mgr = Isolate.Fake.Instance<PresentationManager>();
			Isolate.WhenCalled(() => mgr.Load(null)).WillReturn(new SamplePresenter(sampleView));
			Isolate.Fake.StaticMethods(typeof(PresentationManager));
			Isolate.WhenCalled(() => PresentationManager.Create()).WillReturn(mgr);


			//Act
			var presenter = sampleView.GetPresenter();

			//Assert
			Assert.IsInstanceOfType(presenter, typeof(SamplePresenter));

			Isolate.CleanUp();
		}

		#endregion
	}
}
