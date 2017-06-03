using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.Validation
{
	[TestClass]
	public class ValidationRuleCollectionTest
	{
		[TestMethod]
		public void AddingARangeOfRulesAddsOK()
		{
			var rule1 = Isolate.Fake.Instance<IValidationRule>();
			var rule2 = Isolate.Fake.Instance<IValidationRule>();

			var coll = new ValidationRuleCollection();
			coll.AddRange(new[] { rule1, rule2 });

			Assert.AreEqual(2, coll.Count);
			Assert.AreEqual(rule1, coll[0]);
			Assert.AreEqual(rule2, coll[1]);
		}
	}
}
