using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.ButtonControls
{
	[TestClass]
	public class ButtonListTest
	{
		#region " Tests "

		[TestMethod]
		public void ChangingButtonGroupVisibilityWorksOK()
		{
			//Arrange
			var list = Isolate.Fake.Instance<ButtonList>();

			//Act
			

			//Assert

		}

		#endregion
	}
}
