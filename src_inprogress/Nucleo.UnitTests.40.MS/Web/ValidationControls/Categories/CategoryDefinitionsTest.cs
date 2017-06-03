using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.ValidationControls.Categories
{
	[TestClass]
	public class CategoryDefinitionsTest
	{
		[TestMethod]
		public void GettingErrorCategoryReturnsCorrectType()
		{
			Assert.IsInstanceOfType(CategoryDefinitions.Error, typeof(ErrorValidatorCategory));
		}

		[TestMethod]
		public void GettingInformationCategoryReturnsCorrectType()
		{
			Assert.IsInstanceOfType(CategoryDefinitions.Information, typeof(InformationValidatorCategory));
		}

		[TestMethod]
		public void GettingWarningCategoryReturnsCorrectType()
		{
			Assert.IsInstanceOfType(CategoryDefinitions.Warning, typeof(WarningValidatorCategory));
		}
	}
}
