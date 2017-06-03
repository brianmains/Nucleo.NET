using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock;
using TypeMock.ArrangeActAssert;

using Nucleo.Reflection;
using Nucleo.Web.Controls;
using Nucleo.Web.Pages;
using Nucleo.Web.ButtonControls.ClientSettings;


namespace Nucleo.Web.ButtonControls
{
	[TestClass]
	public class ButtonTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingClientEventsUsingScriptComponentsWorksOK()
		{
			//Arrange
			var button = new Button();
			button.ClientEvents.OnClientClicked = "Test";
			button.ButtonClientEvents.OnClientNeedPostback = "TestPostback";
			
			//Act
			button.NonPublic().Method("AddScriptComponents").Invoke();
			
			//Assert
			Assert.IsInstanceOfType(button.ScriptComponents.Last(), typeof(ButtonClientEvents));
		}

		[TestMethod]
		public void ClickEventFiresWhenRegisteredFromPostback()
		{
			//Arrange
			var button = new Button();
			bool success = false;

			button.Click += delegate(object sender, EventArgs e)
			{
				success = true;
			};

			//Act
			button.RaisePostBackEvent("click");

			//Assert
			Assert.AreEqual(true, success);
		}


		[TestMethod]
		public void CommandEventDoesFireWithCommandNameWhenRegisteredFromPostback()
		{
			//Arrange
			var button = new Button();
			button.CommandName = "A";
			bool success = false;

			button.Command += delegate(object sender, CommandEventArgs e)
			{
				success = true;
			};

			//Act
			button.RaisePostBackEvent("click");

			//Assert
			Assert.AreEqual(true, success);
		}

		[TestMethod]
		public void CommandEventDoesntFireWhenRegisteredFromPostback()
		{
			//Arrange
			var button = new Button();
			bool success = false;

			button.Command += delegate(object sender, CommandEventArgs e)
			{
				success = true;
			};

			//Act
			button.RaisePostBackEvent("click");

			//Assert
			Assert.AreEqual(false, success);
		}

		[TestMethod]
		public void GettingPostbackScriptInClientModeWithClientClickWorksOK()
		{
			//Arrange
			var button = Isolate.Fake.Instance<Button>(Members.CallOriginal);
			Isolate.WhenCalled(() => button.RenderingMode).WillReturn(RenderMode.ClientOnly);
			Isolate.WhenCalled(() => button.OnClientClick).WillReturn("Click();return false;");
			Isolate.NonPublic.WhenCalled(button, "GetPostBackEventReference").WillReturn("Test();");

			//Act
			string content = button.GetPostbackScript();

			//Assert
			Assert.AreEqual("Click();return false;", content);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingPostbackScriptInClientModeWithoutClientClickWorksOK()
		{
			//Arrange
			var button = Isolate.Fake.Instance<Button>();
			Isolate.WhenCalled(() => button.RenderingMode).WillReturn(RenderMode.ClientOnly);
			Isolate.WhenCalled(() => button.OnClientClick).WillReturn(null);
			Isolate.NonPublic.WhenCalled(button, "GetPostBackEventReference").WillReturn("Test();");

			//Act
			string content = button.GetPostbackScript();

			//Assert
			Assert.AreEqual(string.Empty, content);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingPostbackScriptInServerModeWorksOK()
		{
			//Arrange
			var button = Isolate.Fake.Instance<Button>(Members.CallOriginal);
			Isolate.WhenCalled(() => button.RenderingMode).WillReturn(RenderMode.ServerOnly);
			Isolate.WhenCalled(() => button.UseSubmitBehavior).WillReturn(true);

			Isolate.NonPublic.WhenCalled(button, "GetPostBackEventReference").WillReturn("Test();");

			//Act
			string content = button.GetPostbackScript();

			//Assert
			Assert.AreEqual("Test();", content);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void LoadingControlStateWorksOK()
		{
			//Arrange
			var button = new Button();

			//Act
			button.NonPublic().Method("LoadControlState").Invoke((object)new object[] { new object(), "Test" });

			//Assert
			Assert.AreEqual("Test", button.Text);
		}

		[TestMethod]
		public void SavingControlStateWorksOK()
		{
			//Arrange
			var button = new Button();
			button.Text = "Test";

			//Act
			var state = button.NonPublic().Method("SaveControlState").Invoke();

			//Assert
			Assert.IsNotNull(state);
			Assert.IsInstanceOfType(state, typeof(object[]));
			Assert.AreEqual("Test", ((object[])state)[1]);
		}

		[TestMethod]
		public void UseSubmitBehaviorEvaluatesToFalseWhenClientModeEnabled()
		{
			//Arrange
			var b1 = new Button();
			b1.RenderingMode = RenderMode.ClientAndServer;

			var b2 = new Button();
			b2.RenderingMode = RenderMode.ClientOnly;

			//Act
			var default1 = b1.UseSubmitBehavior;
			var default2 = b2.UseSubmitBehavior;

			//Assert
			Assert.AreEqual(false, default1);
			Assert.AreEqual(false, default2);
		}

		[TestMethod]
		public void UseSubmitBehaviorEvaluatesToTrueWhenClientModeEnabled()
		{
			//Arrange
			var button = new Button();
			button.RenderingMode = RenderMode.ClientAndServer;

			//Act
			var value = button.UseSubmitBehavior;

			//Assert
			Assert.AreEqual(false, value);
		}

		#endregion
	}
}
