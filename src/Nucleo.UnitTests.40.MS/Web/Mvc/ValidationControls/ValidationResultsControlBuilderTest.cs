using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Mvc.ValidationControls
{
	[TestClass]
	public class ValidationResultsControlBuilderTest
	{
		[TestMethod]
		public void CreatingBuilderWorksOK()
		{
			//Arrange
			var factory = Isolate.Fake.Instance<NucleoControlFactory>();

			//Act
			var output = new ValidationResultsControlBuilder(factory);

			//Assert
			Assert.IsNotNull(output);

			Isolate.CleanUp();
		}
	}
}
