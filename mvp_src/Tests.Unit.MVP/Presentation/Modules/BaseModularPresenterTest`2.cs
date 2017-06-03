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
	public class BaseModularPresenterTest2
	{
		public interface ITestView : IView { }

		[TestMethod]
		public void CreatingWithViewAssignsOK()
		{
			var view = Isolate.Fake.Instance<ITestView>();

			new BaseModularPresenter<ITestView>(view);
		}
	}
}
