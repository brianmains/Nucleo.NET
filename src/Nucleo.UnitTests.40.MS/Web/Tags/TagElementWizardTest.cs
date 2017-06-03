using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class TagElementWizardTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingWizardUsesTag()
		{
			//Arrange
			var tag = new TagElement("SPAN");
			var wizard = new TagElementWizard(tag);

			//Act
			var result = wizard.Create();

			//Assert
			Assert.AreEqual(tag, result);
		}

		#endregion
	}
}
