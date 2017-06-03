using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Views
{
	[TestClass]
	public class ViewTest
	{
		#region " Test Classes "

		protected class TestView : View 
		{
			public void CallInit()
			{
				this.OnInitializing(EventArgs.Empty);
			}

			public void CallLoaded()
			{
				this.OnLoaded(EventArgs.Empty);
			}

			public void CallLoading()
			{
				this.OnLoading(EventArgs.Empty);
			}

			public void CallStarting()
			{
				this.OnStarting(EventArgs.Empty);
			}

			public void CallUnloading()
			{
				this.OnUnloading(EventArgs.Empty);
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void FiringInitEventWorksOK()
		{
			//Arrange
			var view = new TestView();
			var success = false;
			view.Initializing += delegate(object sender, EventArgs e)
			{
				success = true;
			};

			//Act
			view.CallInit();

			//Assert
			Assert.IsTrue(success);
		}

		[TestMethod]
		public void FiringLoadedEventWorksOK()
		{
			//Arrange
			var view = new TestView();
			var success = false;
			view.Loaded += delegate(object sender, EventArgs e)
			{
				success = true;
			};

			//Act
			view.CallLoaded();

			//Assert
			Assert.IsTrue(success);
		}

		[TestMethod]
		public void FiringLoadingEventWorksOK()
		{
			//Arrange
			var view = new TestView();
			var success = false;
			view.Loading += delegate(object sender, EventArgs e)
			{
				success = true;
			};

			//Act
			view.CallLoading();

			//Assert
			Assert.IsTrue(success);
		}

		[TestMethod]
		public void FiringStartingEventWorksOK()
		{
			//Arrange
			var view = new TestView();
			var success = false;
			view.Starting += delegate(object sender, EventArgs e)
			{
				success = true;
			};

			//Act
			view.CallStarting();

			//Assert
			Assert.IsTrue(success);
		}

		[TestMethod]
		public void FiringUnloadingEventWorksOK()
		{
			//Arrange
			var view = new TestView();
			var success = false;
			view.Unloading += delegate(object sender, EventArgs e)
			{
				success = true;
			};

			//Act
			view.CallUnloading();

			//Assert
			Assert.IsTrue(success);
		}

		#endregion
	}
}
