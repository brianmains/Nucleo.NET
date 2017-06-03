using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Unit.Core.Extensions
{
	[TestClass]
	public class MemberInfoExtensionsTest
	{
		protected class PracticeAttribute : Attribute { }

		protected class TestClass 
		{
			[Practice]
			public string Name { get; set; }

			public string NotFound { get; set; }
		}



		[TestMethod]
		public void GettingCustomAttributeForAMemberDoesntFindOne()
		{
			var obj = new TestClass();

			var attrib = obj.GetType().GetProperty("NotFound").GetCustomAttribute<PracticeAttribute>(false);

			Assert.IsNull(attrib);
		}

		[TestMethod]
		public void GettingCustomAttributeForAMemberWorksOK()
		{
			var obj = new TestClass();

			var attrib = obj.GetType().GetProperty("Name").GetCustomAttribute<PracticeAttribute>(false);

			Assert.IsNotNull(attrib);
		}

		[TestMethod]
		public void GettingCustomAttributesForAMemberDoesntFindOne()
		{
			var obj = new TestClass();

			var attrib = obj.GetType().GetProperty("NotFound").GetCustomAttributes<PracticeAttribute>(false);

			Assert.AreEqual(0, attrib.Length);
		}

		[TestMethod]
		public void GettingCustomAttributesForAMemberWorksOK()
		{
			var obj = new TestClass();

			var attrib = obj.GetType().GetProperty("Name").GetCustomAttributes<PracticeAttribute>(false);

			Assert.IsNotNull(attrib);
			Assert.AreEqual(1, attrib.Length);
		}
	}
}
