using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.ValidationControls.Categories
{
	[TestClass]
	public class InformationValidatorCategoryTest
	{
		[TestMethod]
		public void GettingValuesWorksOK()
		{
			var cat = new InformationValidatorCategory();

			Assert.AreEqual("Information", InformationValidatorCategory.CategoryName);
			Assert.AreEqual("Information", cat.Name);
			Assert.AreEqual(false, cat.IsFailingCategory);
		}
	}
}
