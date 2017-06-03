using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Presentation;
using Nucleo.Web.Presentation;
using Nucleo.Views;
using Nucleo.Web.Views;
using Nucleo.Web.Ajax;
using Nucleo.TestingTools;


namespace Nucleo.Web.Ajax
{
	[TestClass]
	public class PresenterProxyGeneratorTest
	{
		#region " Test Classes "

		public class SampleView : View
		{

		}

		[PresenterAjax]
		public class SamplePresenter : BasePresenter
		{
			public SamplePresenter(SampleView view)
				: base(view) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingDefaultOperationsThrowsException()
		{
			//Arrange


			//Assert
			ExceptionTester.CheckException(true, (s) => { PresenterProxyGenerator.Create(null); });
		}

		[TestMethod]
		public void GettingDefaultOperationsWorksOK()
		{
			//Arrange
			var gen = PresenterProxyGenerator.Create(typeof(SamplePresenter));

			//Act
			string output = gen.Generate();

			//Assert
			
		}

		#endregion
	}
}
