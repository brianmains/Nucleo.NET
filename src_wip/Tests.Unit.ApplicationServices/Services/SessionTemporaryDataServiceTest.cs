using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Services
{
	[TestClass]
	public class SessionTemporaryDataServiceTest
	{
		[TestMethod]
		public void AddingItemsToSessionWorksOK()
		{
			//Arrange
			var context = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => context.Session.Add(null, null)).IgnoreCall();

			//Act
			var service = new SessionTemporaryDataService(context);
			service.AddItem("NewItem", 1);

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => context.Session.Add(null, null));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingItemsFromSessionWorksOK()
		{
			//Arrange
			var context = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => context.Session["NewItem"]).WithExactArguments().WillReturn(123);

			//Act
			var service = new SessionTemporaryDataService(context);
			var result = service.GetItem("NewItem");

			//Assert
			Assert.AreEqual(123, result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingItemsGenericallyFromSessionWorksOK()
		{
			//Arrange
			var context = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => context.Session["NewItem"]).WithExactArguments().WillReturn(123);

			//Act
			var service = new SessionTemporaryDataService(context);
			var result = service.GetItem<int>("NewItem");

			//Assert
			Assert.AreEqual(123, result);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RemovingItemsFromSessionWorksOK()
		{
			//Arrange
			var context = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => context.Session.Remove(null)).IgnoreCall();

			//Act
			var service = new SessionTemporaryDataService(context);
			service.RemoveItem("NewItem");

			//Assert
			Isolate.Verify.WasCalledWithAnyArguments(() => context.Session.Remove(null));

			Isolate.CleanUp();
		}
	}
}
