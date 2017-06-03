using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Context.Services;


namespace Nucleo.Context
{
	[TestClass]
	public class INavigationServiceExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void NavigatingToUrlUsesNavigateTo()
		{
			//Arrange
			var service = Isolate.Fake.Instance<INavigationService>(Members.CallOriginal);
			Isolate.WhenCalled(() => service.NavigateTo(null)).IgnoreCall();

			//Act
			service.NavigateToUrl("myurl.aspx");

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => { service.NavigateTo(null); });
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void PassingEmptyUrlThrowsException()
		{
			//Arrange
			var service = Isolate.Fake.Instance<INavigationService>();

			//Act
			INavigationServiceExtensions.NavigateToUrl(service, string.Empty);

			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void PassingNullServiceThrowsException()
		{
			//Act
			INavigationServiceExtensions.NavigateToUrl(null, "Test.aspx");
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void PassingNullUrlThrowsException()
		{
			//Arrange
			var service = Isolate.Fake.Instance<INavigationService>();

			//Act
			INavigationServiceExtensions.NavigateToUrl(service, null);

			Isolate.CleanUp();
		}

		#endregion
	}
}
