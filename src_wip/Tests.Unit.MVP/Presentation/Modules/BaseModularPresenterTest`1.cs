using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Views;


namespace Nucleo.Presentation.Modules
{
	[TestClass]
	public class BaseModularPresenterTest1
	{
		public interface ITestView : IView<TestModel> { }

		public class TestModel { }


		[TestMethod]
		public void CreatingWithViewAssignsOK()
		{
			var view = Isolate.Fake.Instance<ITestView>();

			new BaseModularPresenter<ITestView, TestModel>(view);
		}
	}
}
