using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Tags
{
	[TestClass]
	public class AlternatingTagGroupRuleTest
	{
		#region " Tests "

		[TestMethod]
		public void SettingUpTagRuleForOddPatternAssignsValueCorrectly()
		{
			//Arrange
			var tagElementFake = Isolate.Fake.Instance<TagElement>();
			var alternatingPattern = new AlternatingTagGroupRule(true);
			

			//Act
			var evenMatch = alternatingPattern.IsForTag(tagElementFake, 0);
			var oddMatch = alternatingPattern.IsForTag(tagElementFake, 1);
			var evenMatch2 = alternatingPattern.IsForTag(tagElementFake, 2);

			//Assert
			Assert.AreEqual(true, evenMatch, "0 isn't event match");
			Assert.AreEqual(false, oddMatch, "1 isn't event match");
			Assert.AreEqual(true, evenMatch2, "2 isn't event match");
		}

		#endregion
	}
}
