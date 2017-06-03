using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Validation
{
	[TestClass]
	public class EmptyValidationTypeTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingEmptyValidatorReturnsEmptyProperties()
		{
			EmptyValidationType empty = new EmptyValidationType();
			Assert.AreEqual(true, empty.IsEmpty);
			Assert.IsNull(empty.Name);
			Assert.AreEqual(0, empty.Level);
		}

		[TestMethod]
		public void EmptyStaticPropertyMatchesEmptyValidationType()
		{
			Assert.IsTrue(ValidationType.Empty.IsEmpty);
			Assert.IsInstanceOfType(ValidationType.Empty, typeof(EmptyValidationType));
		}

		#endregion
	}
}
