using System;
using System.Web.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;


namespace Nucleo.Web.Description
{
	[TestClass]
	public class ExtenderDescriptionCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingEmptyScriptReturnsEmpty()
		{
			//Arrange
			var extenders = new ExtenderDescriptionCollection();

			//Act
			var script = extenders.GetScript();

			//Assert
			Assert.AreEqual("{}", script);
		}

		[TestMethod]
		public void GettingScriptWithCustomFormatterWorksOK()
		{
			//Arrange
			var control1 = Isolate.Fake.Instance<ExtenderControl>();
			Isolate.WhenCalled(() => control1.ClientID).WillReturn("LoginNameControl");
			var control2 = Isolate.Fake.Instance<ExtenderControl>();
			Isolate.WhenCalled(() => control2.ClientID).WillReturn("PasswordControl");

			var extenders = new ExtenderDescriptionCollection();
			extenders.Add("loginName", control1);
			extenders.Add("password", control2);

			//Act
			var script = extenders.GetScript(new CustomScriptIDFormatter("$(", ")"));

			//Assert
			Assert.AreEqual("{ loginName:$(LoginNameControl), password:$(PasswordControl) }", script);
		}

		[TestMethod]
		public void GettingScriptWithNullFormatterThrowsException()
		{
			//Arrange
			var extenders = new ExtenderDescriptionCollection();

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { extenders.GetScript(null); });
		}

		[TestMethod]
		public void GettingScriptWorksOK()
		{
			//Arrange
			var control1 = Isolate.Fake.Instance<ExtenderControl>();
			Isolate.WhenCalled(() => control1.ClientID).WillReturn("control1");
			var control2 = Isolate.Fake.Instance<ExtenderControl>();
			Isolate.WhenCalled(() => control2.ClientID).WillReturn("control2");

			var extenders = new ExtenderDescriptionCollection();
			extenders.Add("Login", control1);
			extenders.Add("Pwd", control2);

			//Act
			var script = extenders.GetScript();

			//Assert
			Assert.AreEqual("{ Login:$find(\"control1\"), Pwd:$find(\"control2\") }", script);

			Isolate.CleanUp();
		}

		#endregion
	}
}
