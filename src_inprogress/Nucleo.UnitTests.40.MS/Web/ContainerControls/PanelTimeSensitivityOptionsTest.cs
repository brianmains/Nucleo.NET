using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Web.ContainerControls
{
	[TestClass]
	public class PanelTimeSensitivityOptionsTest
	{
		#region " Tests "

		[TestMethod]
		public void FilteringDateRangesWithBeginDateSetWorksCorrectly()
		{
			//Arrange
			var panel = new PanelTimeSensitivityOptions();
			panel.FilterBeginDate = new DateTime(2007, 1, 1);
			Assert.AreEqual(true, panel.IsVisible);

			panel.FilterBeginDate = DateTime.Now.AddDays(2);
			Assert.AreEqual(false, panel.IsVisible);
		}

		[TestMethod]
		public void FilteringDateRangesWithBothDatesWorksCorrectly()
		{
			//Arrange
			var panel = new PanelTimeSensitivityOptions();

			//Act
			panel.FilterBeginDate = new DateTime(2007, 1, 1);
			panel.FilterEndDate = DateTime.Now.AddDays(20);

			//Assert
			Assert.AreEqual(true, panel.IsVisible);
		}

		[TestMethod]
		public void FilteringDateRangesWithEndDateSetWorksCorrectly()
		{
			//Arrange
			var panel = new PanelTimeSensitivityOptions();
			panel.FilterEndDate = DateTime.Now.AddDays(20);
			Assert.AreEqual(true, panel.IsVisible);

			panel.FilterEndDate = DateTime.Now.Subtract(TimeSpan.FromDays(3));
			Assert.AreEqual(false, panel.IsVisible);
		}

		#endregion
	}
}
