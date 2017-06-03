using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo;


namespace Tests.Unit.Core
{
	[TestClass]
	public class TypeLoaderTest
	{
		protected class TestClass
		{
			public TestClass() { }

			
		}

		protected class TestClass2
		{
			public TestClass2(int? key, string text) 
			{
				Guard.NotNull(key);
				Guard.NotNullOrEmpty(text);

			}
		}




		[
		TestMethod,
		ExpectedException(typeof(System.MissingMethodException))
		]
		public void CreatingTargetParameteredConstructorUsingGenericsFailsDueToMismatchedParameters()
		{
			TypeLoader.Create<TestClass2>(1, null, "ABC");
		}

		[
		TestMethod,
		ExpectedException(typeof(System.Reflection.TargetInvocationException))
		]
		public void CreatingTargetParameteredConstructorUsingGenericsFailsDueToObjectConstraints()
		{
			TypeLoader.Create<TestClass2>(1, null);
		}
		
		[TestMethod]
		public void CreatingTargetParameteredConstructorUsingGenericsWorksOK()
		{
			var test = TypeLoader.Create<TestClass2>(1, "ABC");

			Assert.IsNotNull(test);
		}

		[TestMethod]
		public void CreatingTargetingParameterlessConstructorUsingGenericsWorksOK()
		{
			var test = TypeLoader.Create<TestClass>();

			Assert.IsNotNull(test);
		}
	}
}
