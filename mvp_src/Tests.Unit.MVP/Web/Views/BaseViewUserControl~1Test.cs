using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.Views
{
	[TestClass]
	public class BaseViewUserControl1Test
	{
		#region " Test Classes "

		protected class TestModel { }

		protected class TestView : BaseViewUserControl<TestModel>
		{

		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var viewPage = new TestView();
			var model = new TestModel();

			//Act
			viewPage.Model = model;

			//Assert
			Assert.AreEqual(model, viewPage.Model);
		}

		#endregion
	}
}
