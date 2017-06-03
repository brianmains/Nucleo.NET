using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Web.Pages;


namespace Nucleo.Web
{
	[TestClass]
	public class BaseAjaxExtenderTest : FakePage
	{
		#region " Supporting Classes "

		protected class FakeAjaxExtender : BaseAjaxExtender
		{
			protected override void GetAjaxScriptDescriptors(IContentRegistrar registrar, Control control)
			{

			}

			protected override void GetAjaxScriptReferences(IContentRegistrar registrar)
			{

			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void InitializingControlWithoutAjaxManagerDoesntThrowException()
		{
			try
			{
				FakeAjaxExtender control = new FakeAjaxExtender();
				this.Controls.Add(control);

				this.FireEvent(PageEvent.Init);
			}
			catch (Exception ex)
			{
				Assert.Fail("The init event threw an exception, possibly because itrequired an AjaxManager to be on the page");
			}
		}

		#endregion
	}
}