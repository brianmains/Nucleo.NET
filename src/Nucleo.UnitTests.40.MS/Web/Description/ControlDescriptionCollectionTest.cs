using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.Web.Description
{
	[TestClass]
	public class ControlDescriptionCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingEmptyScriptReturnsEmpty()
		{
			//Arrange
			var controls = new ControlDescriptionCollection();

			//Act
			var script = controls.GetScript();

			//Assert
			Assert.AreEqual("{}", script);
		}

		[TestMethod]
		public void GettingScriptWithCustomFormatterWorksOK()
		{
			//Arrange
			var control1 = Isolate.Fake.Instance<ScriptControl>();
			Isolate.WhenCalled(() => control1.ClientID).WillReturn("LoginNameControl");
			var control2 = Isolate.Fake.Instance<ScriptControl>();
			Isolate.WhenCalled(() => control2.ClientID).WillReturn("PasswordControl");

			var controls = new ControlDescriptionCollection();
			controls.Add("loginName", control1);
			controls.Add("password", control2);

			//Act
			var script = controls.GetScript(new CustomScriptIDFormatter("$(", ")"));

			//Assert
			Assert.AreEqual("{ loginName:$(LoginNameControl), password:$(PasswordControl) }", script);
		}

		[TestMethod]
		public void GettingScriptWithNullFormatterThrowsException()
		{
			//Arrange
			var controls = new ControlDescriptionCollection();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { controls.GetScript(null); });
		}

		[TestMethod]
		public void GettingScriptWorksOK()
		{
			//Arrange
			var control1 = Isolate.Fake.Instance<ScriptControl>();
			Isolate.WhenCalled(() => control1.ClientID).WillReturn("control1");
			var control2 = Isolate.Fake.Instance<ScriptControl>();
			Isolate.WhenCalled(() => control2.ClientID).WillReturn("control2");

			var controls = new ControlDescriptionCollection();
			controls.Add("Login", control1);
			controls.Add("Pwd", control2);

			//Act
			var script = controls.GetScript();

			//Assert
			Assert.AreEqual("{ Login:$find(\"control1\"), Pwd:$find(\"control2\") }", script);

			Isolate.CleanUp();
		}

		#endregion
	}
}
