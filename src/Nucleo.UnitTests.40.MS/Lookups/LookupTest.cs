using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Lookups
{
	[TestClass]
	public class LookupTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingLookupWorksAsExpected()
		{
			//Arrange

			//Act
			var lookup = new Lookup("X", "Y", 1);

			//Assert
			Assert.AreEqual("X", lookup.Name);
			Assert.AreEqual("Y", lookup.Value);
			Assert.AreEqual(1, lookup.RepresentationCode);
		}

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var lookup = new Lookup();

			//Act
			lookup.Name = "X";
			lookup.Value = "12";
			lookup.RepresentationCode = "R";

			//Assert
			Assert.AreEqual("X", lookup.Name);
			Assert.AreEqual("12", lookup.Value);
			Assert.AreEqual("R", lookup.RepresentationCode);
		}

		#endregion
	}
}
