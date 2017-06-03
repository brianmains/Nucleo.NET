using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Pages;
using Nucleo.EventArguments;


namespace Nucleo.Web.Pages.Testing
{
	[TestClass]
	public class PageRunnerTest
	{
		#region " Test Classes "

		public class FakeAjaxControl : BaseAjaxControl
		{
			#region " Properties "

			public bool InitializingFired { get; set; }

			public bool LoadingFired { get; set; }

			public bool PrepareToRenderFired { get; set; }

			public bool RenderedFired { get; set; }

			public bool RenderingFired { get; set; }

			public bool StartupFired { get; set; }

			public bool ValidateStateFired { get; set; }

			public bool UnloadingFired { get; set; }

			#endregion



			#region " Methods "

			protected override void OnInitializing(EventArgs e)
			{
				base.OnInitializing(e);

				InitializingFired = true;
			}			

			protected override void OnLoading(EventArgs e)
			{
				base.OnLoading(e);
				
				LoadingFired = true;
			}

			protected override void OnStartup(EventArgs e)
			{
				base.OnStartup(e);

				StartupFired = true;
			}

			protected override void OnValidateState(ValidateEventArgs e)
			{
				base.OnValidateState(e);

				ValidateStateFired = true;
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingControlWorksOK()
		{
			//Arrange
			var runner = new PageRunner();

			//Act
			runner.AddControl(new FakeAjaxControl());

			//Assert
			Assert.AreEqual(1, runner.Controls.Count);
			Assert.IsInstanceOfType(runner.Controls[0], typeof(FakeAjaxControl));
		}

		[TestMethod]
		public void AddingMultipleControlsWorksOK()
		{
			//Arrange
			var runner = new PageRunner();

			//Act
			runner.AddControls(new Control[]
			{
				new FakeAjaxControl(),
				new FakeAjaxControl()
			});

			//Assert
			Assert.AreEqual(2, runner.Controls.Count);
			Assert.IsInstanceOfType(runner.Controls[0], typeof(FakeAjaxControl));
			Assert.IsInstanceOfType(runner.Controls[1], typeof(FakeAjaxControl));
		}

		[TestMethod]
		public void FiringCustomEventWorksOK()
		{
			//Arrange
			var runner = new PageRunner();
			bool runBefore = false, runAfter = false;

			runner.Startup += delegate(object sender, EventArgs e)
			{
				runAfter = true;
			};
			runner.ValidateState += delegate(object sender, ValidateEventArgs e)
			{
				runBefore = true;
			};

			//Act
			runner.FireEvent(PageControllerEvent.Startup);
			runner.FireEvent(PageControllerEvent.ValidateState);

			//Assert
			Assert.IsTrue(runBefore, "Startup event didn't fire");
			Assert.IsTrue(runAfter, "Validate event didn't fire");
		}

		[TestMethod]
		public void FiringInitializeEventFiresForChildrenToo()
		{
			//Arrange
			var runner = new PageRunner();
			var ctl = new FakeAjaxControl();
			runner.AddControl(ctl);

			//Act
			runner.FireEvent(PageControllerEvent.Initializing);

			//Assert
			Assert.IsTrue(ctl.InitializingFired);
		}

		[TestMethod]
		public void FiringInitializeEventWorksOK()
		{
			//Arrange
			var runner = new PageRunner();
			bool runBefore = false;

			runner.Initializing += delegate(object sender, EventArgs e)
			{
				runBefore = true;
			};

			//Act
			runner.FireEvent(PageControllerEvent.Initializing);

			//Assert
			Assert.IsTrue(runBefore, "Before event didn't fire");
		}

		[TestMethod]
		public void FiringLoadEventFiresForChildrenToo()
		{
			//Arrange
			var runner = new PageRunner();
			var ctl = new FakeAjaxControl();
			runner.AddControl(ctl);

			//Act
			runner.FireEvent(PageControllerEvent.Loading);

			//Assert
			Assert.IsTrue(ctl.LoadingFired);
		}

		[TestMethod]
		public void FiringLoadEventWorksOK()
		{
			//Arrange
			var runner = new PageRunner();
			bool runBefore = false;

			runner.Loading += delegate(object sender, EventArgs e)
			{
				runBefore = true;
			};

			//Act
			runner.FireEvent(PageControllerEvent.Loading);

			//Assert
			Assert.IsTrue(runBefore, "Before event didn't fire");
		}

		[TestMethod]
		public void FiringRenderEventWorksOK()
		{
			//Arrange
			var runner = new PageRunner();
			bool runBefore = false, runAfter = false;

			runner.Rendered += delegate(object sender, RenderEventArgs e)
			{
				runAfter = true;
			};
			runner.Rendering += delegate(object sender, RenderEventArgs e)
			{
				runBefore = true;
			};

			//Act
			runner.FireEvent(PageControllerEvent.Rendered);
			runner.FireEvent(PageControllerEvent.Rendering);

			//Assert
			Assert.IsTrue(runBefore, "Before event didn't fire");
			Assert.IsTrue(runAfter, "After event didn't fire");
		}

		[TestMethod]
		public void FiringUnloadEventWorksOK()
		{
			//Arrange
			var runner = new PageRunner();
			bool runBefore = false;

			runner.Unloading += delegate(object sender, EventArgs e)
			{
				runBefore = true;
			};

			//Act
			runner.FireEvent(PageControllerEvent.Unloading);

			//Assert
			Assert.IsTrue(runBefore, "Before event didn't fire");
		}

		[TestMethod]
		public void StartupEventDoesNotFireWhenInitialLoadIsTrue()
		{
			//Arrange
			var runner = Isolate.Fake.Instance<PageRunner>(Members.CallOriginal);
			Isolate.WhenCalled(() => runner.IsInitialLoad).WillReturn(false);

			//Act
			runner.FireEventsTo(PageControllerEvent.Initializing);

			//Assert
			Isolate.Verify.NonPublic.WasNotCalled(runner, "OnStartup");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void StartupEventFiresWhenInitialLoadIsTrue()
		{
			//Arrange
			var runner = Isolate.Fake.Instance<PageRunner>(Members.CallOriginal);
			Isolate.WhenCalled(() => runner.IsInitialLoad).WillReturn(true);
			
			//Act
			runner.FireEventsTo(PageControllerEvent.Initializing);

			//Assert
			Isolate.Verify.NonPublic.WasCalled(runner, "OnStartup");

			Isolate.CleanUp();
		}

		#endregion
	}
}
