using System;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.TestingTools;
using Nucleo.Exceptions;


namespace Nucleo.Web.Pages
{
	[TestClass]
	public class PageBaseTest : PageBase
	{

		#region " Tests "

		[TestMethod]
		public void TestUsingCacheFailures()
		{
			try
			{
				Cache.Add("Value", "Some Value", null, DateTime.Now.AddMilliseconds(5), TimeSpan.MaxValue, System.Web.Caching.CacheItemPriority.Default, null);
				Assert.Fail();
			}
			catch (UnitTestAssertException ex) { Assert.Fail(); }
			catch { }
		}

		[TestMethod]
		public void TestUsingSessionFailures()
		{
			try
			{
				Session["Value"] = "New Value";
				Assert.Fail();
			}
			catch (UnitTestAssertException ex) { Assert.Fail(); }
			catch { }
		}

		[TestMethod]
		public void TestUsingViewState()
		{
			int viewstateCount = this.ViewState.Count;
			ViewState["Name"] = "PageBaseTest";
			ViewState["PageCount"] = 1;
			ViewState["TestDate"] = DateTime.Now;
			Assert.AreEqual(viewstateCount + 3, this.ViewState.Count);

			ViewState.Remove("TestDate");
			Assert.AreEqual(viewstateCount + 2, this.ViewState.Count);
		}

		#endregion
	}
}
