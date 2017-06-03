using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Orm.Validation
{
	[TestClass]
	public class ValidationResultsTest
	{
		[TestMethod]
		public void AddingErrorResultSetsIsErrorFlag()
		{
			var results = Isolate.Fake.Instance<ValidationResults>(Members.CallOriginal, ConstructorWillBe.Ignored);

			results.AddMessage(new ValidationMessage("Test", true));

			Assert.IsFalse(results.IsValid);

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddNullResultThrowsException()
		{
			var results = Isolate.Fake.Instance<ValidationResults>(Members.CallOriginal, ConstructorWillBe.Ignored);

			results.AddMessage(null);
		}

		[TestMethod]
		public void AddingResultAddsToList()
		{
			var results = Isolate.Fake.Instance<ValidationResults>(Members.CallOriginal, ConstructorWillBe.Ignored);

			results.AddMessage(new ValidationMessage("Test", false));

			Assert.AreEqual(1, results.GetMessages().Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingAssignsIsValidToTrue()
		{
			var results = new ValidationResults(new object(), ValidationRuleType.Create);

			Assert.IsTrue(results.IsValid);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingAssignsToLocalParameters()
		{
			var results = new ValidationResults(new object(), ValidationRuleType.Delete);

			Assert.IsNotNull(results.Entity);
			Assert.AreEqual(ValidationRuleType.Delete, results.RuleType);

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullEntityThrowsException()
		{
			new ValidationResults(null, ValidationRuleType.Delete);
		}
	}
}
