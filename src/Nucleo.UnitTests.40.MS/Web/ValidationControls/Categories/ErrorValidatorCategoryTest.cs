using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.ValidationControls.Categories
{
	[TestClass]
	public class ErrorValidatorCategoryTest
	{
		[TestMethod]
		public void GettingValuesWorksOK()
		{
			var cat = new ErrorValidatorCategory();

			Assert.AreEqual("Error", ErrorValidatorCategory.CategoryName);
			Assert.AreEqual("Error", cat.Name);
			Assert.AreEqual(true, cat.IsFailingCategory);
		}
	}
}
