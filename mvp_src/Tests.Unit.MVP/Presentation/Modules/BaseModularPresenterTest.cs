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
	public class BaseModularPresenterTest
	{
		[TestMethod]
		public void CreatingWithViewAssignsOK()
		{
			var view = Isolate.Fake.Instance<IView>();

			new BaseModularPresenter(view);
		}
	}
}
