using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Web.UserControls
{
	[TestClass]
	public class UserControlBaseTest : UserControlBase
	{
		#region " Properties "

		public override bool Enabled
		{
			get
			{
				throw new Exception("The method or operation is not implemented.");
			}
			set
			{
				throw new Exception("The method or operation is not implemented.");
			}
		}

		public override bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				base.Visible = value;
			}
		}

		#endregion



		[TestMethod]
		public void TestUsingViewState()
		{
			int viewstateCount = ViewState.Count;
			ViewState["Value"] = "Some Value";
			ViewState["UserControlCount"] = 1;
			ViewState["Test"] = DateTime.Now;
			Assert.AreEqual(viewstateCount + 3, ViewState.Count);

			ViewState.Remove("Test");
			Assert.AreEqual(viewstateCount + 2, ViewState.Count);
		}
	}
}
