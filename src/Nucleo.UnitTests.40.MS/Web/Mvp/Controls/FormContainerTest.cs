using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Web.Core;
using Nucleo.Web.Pages.Testing;


namespace Nucleo.Web.Mvp.Controls
{
	[TestClass]
	public class FormContainerTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingAndSettingPropertiesWorksOK()
		{
			//Arrange
			var container = new FormContainer();

			//Act
			container.RegionName = "X";

			//Assert
			Assert.AreEqual("X", container.RegionName);
		}

		[TestMethod]
		public void GettingExistingFormContainerWorksOK()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.LocalStorage[typeof(FormContainer)]).WithExactArguments()
				.WillReturn(new Dictionary<string, FormContainer>
				{
					{ "Test", new FormContainer() }
				});

			//Act
			var container = FormContainer.GetContainer(ctx, "Test");
			
			//Assert
			Assert.IsNotNull(container);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingNonExistingFormContainerReturnsNull()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.LocalStorage[typeof(FormContainer)]).WithExactArguments()
				.WillReturn(new Dictionary<string, FormContainer>
				{
					{ "Test2", new FormContainer() }
				});

			//Act
			var container = FormContainer.GetContainer(ctx, "Test");

			//Assert
			Assert.IsNull(container);

			Isolate.CleanUp();
		}

		#endregion
	}
}
