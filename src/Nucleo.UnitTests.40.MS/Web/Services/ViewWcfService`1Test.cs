using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Presentation;


namespace Nucleo.Web.Services
{
	[TestClass]
	public class ViewWcfService_1Test
	{
		protected class TestModel { }
		[PresenterBinding(typeof(TestPresenter))]
		protected class TestView : ViewWcfService<object> 
		{
			public TestView() { }
		}

		protected class TestPresenter : BasePresenter<TestView>
		{
			public TestPresenter(TestView view) : base(view) { }
		}

		[TestMethod]
		public void GettingAndSettingModelWorksOK()
		{
			var model = new TestModel();
			var view = new TestView { Model = model };

			Assert.AreEqual(model, view.Model);
		}
	}
}
