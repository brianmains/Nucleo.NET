using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.Web.ListControls
{
	[TestClass]
	public class PageableListTest
	{
		#region " Tests "

		[TestMethod]
		public void CreatingPageableListWorksOK()
		{
			//Arrange
			var list = new PageableList();

			//Act
			list.Orientation = Orientation.Horizontal;
			list.PagingOptions.LeftImageUrl = "pagel.png";
			list.PagingOptions.RightImageUrl = "pager.png";
			list.CurrentIndex = 1;
			list.VisibleItemCount = 5;

			//Assert
			Assert.AreEqual(Orientation.Horizontal, list.Orientation);
			Assert.AreEqual("pagel.png", list.PagingOptions.LeftImageUrl);
			Assert.AreEqual("pager.png", list.PagingOptions.RightImageUrl);
			Assert.AreEqual(1, list.CurrentIndex);
			Assert.AreEqual(5, list.VisibleItemCount);
		}

		[TestMethod]
		public void GettingMaximumItemCountWorksOK()
		{
			//Arrange
			var listFake = Isolate.Fake.Instance<PageableList>();
			Isolate.WhenCalled(() => listFake.TotalItemCount).WillReturn(100);
			Isolate.WhenCalled(() => listFake.VisibleItemCount).WillReturn(10);
			Isolate.WhenCalled(() => listFake.MaximumIndex).CallOriginal();

			//Act
			var max = listFake.MaximumIndex;

			//Assert
			Assert.AreEqual(90, max, "Max isn't 90");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PagingLeftByOneWorksOK()
		{
			//Arrange
			var list = new PageableList();
			list.CurrentIndex = 5;

			//Act
			list.PageLeft();

			//Assert
			Assert.AreEqual(4, list.CurrentIndex);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void PagingRightByOneWorksOK()
		{
			//Arrange
			var list = Isolate.Fake.Instance<PageableList>(Members.CallOriginal);
			Isolate.WhenCalled(() => list.MaximumIndex).WillReturn(10);
			list.CurrentIndex = 5;

			//Act
			list.PageRight();

			//Assert
			Assert.AreEqual(6, list.CurrentIndex);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RaisingPostbackEventToNotPageWorksOK()
		{
			//Arrange
			var listFake = Isolate.Fake.Instance<PageableList>(Members.CallOriginal);
			Isolate.WhenCalled(() => listFake.ID).WillReturn("id");

			//Act
			ControlTestingUtility.SimulatePostbackEvent(listFake, "SomeEvent");

			//Assert
			Isolate.Verify.WasNotCalled(() => listFake.PageLeft());
			Isolate.Verify.WasNotCalled(() => listFake.PageRight());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RaisingPostbackEventToPageLeftWorksOK()
		{
			//Arrange
			var listFake = Isolate.Fake.Instance<PageableList>(Members.CallOriginal);
			Isolate.WhenCalled(() => listFake.ID).WillReturn("id");

			//Act
			ControlTestingUtility.SimulatePostbackEvent(listFake, PageableList.PageLeftCommandName);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => listFake.PageLeft());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RaisingPostbackEventToPageRightWorksOK()
		{
			//Arrange
			var listFake = Isolate.Fake.Instance<PageableList>(Members.CallOriginal);
			listFake.ID = "id";

			//Act
			ControlTestingUtility.SimulatePostbackEvent(listFake, PageableList.PageRightCommandName);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => listFake.PageRight());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingVisibleItemCountToNegativeNumberThrowsException()
		{
			//Arrange
			var list = new PageableList();

			//Act
			
			//Assert
			ExceptionTester.CheckException(true, (src) => { list.VisibleItemCount = -1; }, "The visible count property doesn't throw exception on negative numbers");
		}

		[TestMethod]
		public void SettingVisibleItemCountWhenTotalCountIsZeroAssignsOK()
		{
			//Arrange
			var listFake = Isolate.Fake.Instance<PageableList>(Members.CallOriginal);
			Isolate.WhenCalled(() => listFake.TotalItemCount).WillReturn(0);

			//Act
			listFake.VisibleItemCount = 10;

			//Assert
			Assert.AreEqual(10, listFake.VisibleItemCount);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingVisibleItemCountWhenTotalCountIsLessThanReassignsToThatValue()
		{
			//Arrange
			var listFake = Isolate.Fake.Instance<PageableList>(Members.CallOriginal);
			Isolate.WhenCalled(() => listFake.TotalItemCount).WillReturn(5);

			//Act
			listFake.VisibleItemCount = 10;

			//Assert
			Assert.AreEqual(5, listFake.VisibleItemCount);

			Isolate.CleanUp();
		}

		#endregion
	}
}
