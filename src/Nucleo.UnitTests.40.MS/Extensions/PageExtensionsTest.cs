using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Reflection;


namespace Nucleo.Extensions
{
	[TestClass]
	public class PageExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingProfileValueWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Profile.GetPropertyValue("Test"))
				.WithExactArguments().WillReturn("X");			

			//Act
			var page = new Page();
			var val = page.GetProfileValue<string>("Test");

			//Assert
			Assert.AreEqual("X", val);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SavingProfileValueWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Profile.SetPropertyValue("Test", "Y")).IgnoreCall();

			//Act
			var page = new Page();
			page.SaveProfileValue("Test", "Y");

			//Assert
			Isolate.Verify.WasCalledWithExactArguments(() => { HttpContext.Current.Profile.SetPropertyValue("Test", "Y"); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingDefaultButtonUsesUniqueID()
		{
			//Arrange
			var button = Isolate.Fake.Instance<Button>();
			Isolate.WhenCalled(() => button.ClientID).WillReturn("uniqueid");
			Isolate.WhenCalled(() => button.UniqueID).WillReturn("ct100$uniqueid");

			var page = new Page();
			page.NonPublic().Method("SetForm").Invoke(new HtmlForm());

			//Act
			page.SetDefaultButton(button);

			//Assert
			Assert.AreEqual("ct100$uniqueid", page.Form.DefaultButton);

			Isolate.CleanUp();
		}

		#endregion
	}
}
