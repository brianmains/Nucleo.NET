using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.ValidationControls.Categories
{
	[TestClass]
	public class WarningValidatorCategoryTest
	{
		[TestMethod]
		public void GettingValuesWorksOK()
		{
			var cat = new WarningValidatorCategory();

			Assert.AreEqual("Warning", WarningValidatorCategory.CategoryName);
			Assert.AreEqual("Warning", cat.Name);
			Assert.AreEqual(false, cat.IsFailingCategory);
		}
	}
}
