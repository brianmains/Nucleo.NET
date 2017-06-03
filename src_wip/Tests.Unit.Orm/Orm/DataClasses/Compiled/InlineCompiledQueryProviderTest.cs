using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Orm.DataClasses.Compiled
{
	[TestClass]
	public class InlineCompiledQueryProviderTest
	{
		#region " Test Classes "

		protected class TestResult { }

		#endregion



		#region " Tests "

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullsWithContextResultThrowsException()
		{
			var provider = new InlineCompiledQueryProvider();

			provider.Add<DataContext, IQueryable<TestResult>>(null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullsWithContextArg1ResultThrowsException()
		{
			var provider = new InlineCompiledQueryProvider();

			provider.Add<DataContext, int, IQueryable<TestResult>>(null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullsWithContextArg1Arg2ResultThrowsException()
		{
			var provider = new InlineCompiledQueryProvider();

			provider.Add<DataContext, int, int, IQueryable<TestResult>>(null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullsWithContextArg1Arg2Arg3ResultThrowsException()
		{
			var provider = new InlineCompiledQueryProvider();

			provider.Add<DataContext, int, int, int, IQueryable<TestResult>>(null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullsWithContextArg1Arg2Arg3Arg4ResultThrowsException()
		{
			var provider = new InlineCompiledQueryProvider();

			provider.Add<DataContext, int, int, int, int, IQueryable<TestResult>>(null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void AddingNullsWithContextArg1Arg2Arg3Arg4Arg5ResultThrowsException()
		{
			var provider = new InlineCompiledQueryProvider();

			provider.Add<DataContext, int, int, int, int, string, IQueryable<TestResult>>(null);
		}

		[TestMethod]
		public void AddingWithContextResultAddsItemOK()
		{
			var dict = new Dictionary<string, object>();
			var provider = new InlineCompiledQueryProvider(dict);

			provider.Add<DataContext, IQueryable<TestResult>>(c => new TestResult[] { }.AsQueryable());

			Assert.IsNotNull(dict["_DataContext_IQueryable`1_"]);
		}

		[TestMethod]
		public void AddingWithContextArg1ResultAddsItemOK()
		{
			var dict = new Dictionary<string, object>();
			var provider = new InlineCompiledQueryProvider(dict);

			provider.Add<DataContext, int, IQueryable<TestResult>>((c, a1) => new TestResult[] { }.AsQueryable());
				

			Assert.IsNotNull(dict["_DataContext_Int32_IQueryable`1_"]);
		}

		[TestMethod]
		public void AddingWithContextArg1Arg2ResultAddsItemOK()
		{
			var dict = new Dictionary<string, object>();
			var provider = new InlineCompiledQueryProvider(dict);

			provider.Add<DataContext, int, string, IQueryable<TestResult>>((c, a1, a2) => new TestResult[] { }.AsQueryable());

			Assert.IsNotNull(dict["_DataContext_Int32_String_IQueryable`1_"]);
		}

		[TestMethod]
		public void AddingWithContextArg1Arg2Arg3ResultAddsItemOK()
		{
			var dict = new Dictionary<string, object>();
			var provider = new InlineCompiledQueryProvider(dict);

			provider.Add<DataContext, int, string, long, IQueryable<TestResult>>((c, a1, a2, a3) => new TestResult[] { }.AsQueryable());

			Assert.IsNotNull(dict["_DataContext_Int32_String_Int64_IQueryable`1_"]);
		}

		[TestMethod]
		public void AddingWithContextArg1Arg2Arg3Arg4ResultAddsItemOK()
		{
			var dict = new Dictionary<string, object>();
			var provider = new InlineCompiledQueryProvider(dict);

			provider.Add<DataContext, int, string, long, DateTime, IQueryable<TestResult>>((c, a1, a2, a3, a4) => new TestResult[] { }.AsQueryable());

			Assert.IsNotNull(dict["_DataContext_Int32_String_Int64_DateTime_IQueryable`1_"]);
		}

		[TestMethod]
		public void AddingWithContextArg1Arg2Arg3Arg4Arg5ResultAddsItemOK()
		{
			var dict = new Dictionary<string, object>();
			var provider = new InlineCompiledQueryProvider(dict);

			provider.Add<DataContext, int, string, long, int, int, IQueryable<TestResult>>((c, a1, a2, a3, a4, a5) => new TestResult[] { }.AsQueryable());

			Assert.IsNotNull(dict["_DataContext_Int32_String_Int64_Int32_Int32_IQueryable`1_"]);
		}

		[TestMethod]
		public void CreatingWithEmptyConstructorWorksOK()
		{
			new InlineCompiledQueryProvider();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullConstructorThrowsException()
		{
			new InlineCompiledQueryProvider(null);
		}

		[TestMethod]
		public void CreatingWithParameterizedConstructorWorksOK()
		{
			var dict = new Dictionary<string, object>();
			new InlineCompiledQueryProvider(dict);
		}

		#endregion
	}
}
