using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Presentation;
using Nucleo.Views;


namespace Nucleo.EventArguments
{
	[TestClass]
	public class PresenterEventArgsTest
	{
		[TestMethod]
		public void CreatingAssignsOK()
		{
			var presenter = Isolate.Fake.Instance<IPresenter>();
			var view = Isolate.Fake.Instance<IView>();

			var args = new PresenterEventArgs(presenter, view);

			Assert.AreEqual(presenter, args.Presenter);
			Assert.AreEqual(view, args.View);
		}
	}
}
