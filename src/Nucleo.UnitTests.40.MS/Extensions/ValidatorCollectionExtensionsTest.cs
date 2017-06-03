using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Extensions
{
	[TestClass]
	public class ValidatorCollectionExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void FindingByValidationGroupWorksOK()
		{
			//Arrange
			var vals = new ValidatorCollection();
			vals.Add(new RequiredFieldValidator { IsValid = false, ValidationGroup = "A" });
			vals.Add(new RequiredFieldValidator { IsValid = false, ValidationGroup = "A" });
			vals.Add(new RequiredFieldValidator { IsValid = false, ValidationGroup = "B" });
			vals.Add(new RequiredFieldValidator { IsValid = true, ValidationGroup = "C" });

			//Act
			var results = vals.FindByValidationGroup("A");

			//Assert
			Assert.AreEqual(2, results.Count());
		}

		[TestMethod]
		public void FindingErrorsWorksOK()
		{
			//Arrange
			var vals = new ValidatorCollection();
			vals.Add(new RequiredFieldValidator { IsValid = false });
			vals.Add(new RequiredFieldValidator { IsValid = false });
			vals.Add(new RequiredFieldValidator { IsValid = false });
			vals.Add(new RequiredFieldValidator { IsValid = true });

			//Act
			var results = vals.FindInError();

			//Assert
			Assert.AreEqual(3, results.Count());
		}

		[TestMethod]
		public void FindingNonErrorsWorksOK()
		{
			//Arrange
			var vals = new ValidatorCollection();
			vals.Add(new RequiredFieldValidator { IsValid = false });
			vals.Add(new RequiredFieldValidator { IsValid = false });
			vals.Add(new RequiredFieldValidator { IsValid = false });
			vals.Add(new RequiredFieldValidator { IsValid = true });

			//Act
			var results = vals.FindNotInError();

			//Assert
			Assert.AreEqual(1, results.Count());
		}

		#endregion
	}
}
