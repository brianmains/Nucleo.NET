using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Validation
{
	[TestClass]
	public class ValidationTypeTest :ValidationType
	{
		private byte _level = 0;
		private string _name = null;



		#region " Constructors "

		public ValidationTypeTest() 
			: base("Error", 255) { }

		public ValidationTypeTest(string name, byte level)
			: base(name, level) { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingValidationTypeWorksCorrectly()
		{
			ValidationTypeTest test = new ValidationTypeTest("Warning", 128);
			Assert.AreEqual(128, test.Level);
			Assert.AreEqual("Warning", test.Name);
			Assert.IsFalse(test.IsEmpty);
		}

		#endregion
	}
}
