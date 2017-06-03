using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Views;
using Nucleo.Web.Views;


namespace Nucleo.Web.Mvp.DataSourceControls
{
	[TestClass]
	public class ViewDataSourceTest
	{
		#region " Test Classes "

		protected class VDSTest : ViewDataSource
		{
			public IView FindViewParent()
			{
				return base.FindParentView();
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void FindingAViewFindsCorrectControl()
		{
			//Arrange
			var parent = new FakeViewControl();
			var vds = new VDSTest();
			parent.Controls.Add(vds);

			//Act
			var hostView = vds.FindViewParent();

			//Assert
			Assert.AreEqual(parent, hostView);
		}

		[TestMethod]
		public void FindingAViewFindsCorrectPage()
		{
			//Arrange
			var parent = new FakeViewPage();
			var vds = new VDSTest();
			parent.Controls.Add(vds);

			//Act
			var hostView = vds.FindViewParent();

			//Assert
			Assert.AreEqual(parent, hostView);
		}

		#endregion
	}
}
