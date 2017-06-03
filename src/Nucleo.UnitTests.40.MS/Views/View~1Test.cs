using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Views
{
	[TestClass]
	public class View1Test
	{
		#region " Test Classes "

		protected class TestModel { }

		protected class TestView : View<TestModel> { }

		#endregion



		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var view = new TestView();
			var model = new TestModel();

			//Act
			view.Model = model;

			//Assert
			Assert.AreEqual(model, view.Model);
		}
	}
}
