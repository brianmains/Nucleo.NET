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
		public void CreatingArgsWorksOK()
		{
			//Arrange
			var presenter = Isolate.Fake.Instance<IPresenter>();
			var view = Isolate.Fake.Instance<IView>();

			//Act
			var args = new PresenterEventArgs(presenter, view);

			//Assert
			Assert.AreEqual(presenter, args.Presenter);
			Assert.AreEqual(view, args.View);
		}
	}
}
