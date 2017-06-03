using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;
using System.Collections.Generic;


namespace Nucleo.Web.Unity
{
	[TestClass]
	public class HttpContextLifetimeManagerTest
	{
		[TestMethod]
		public void CreatingWithHttpContextWorksAsExpected()
		{
			var ctx = Isolate.Fake.Instance<HttpContextWrapper>();
			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.Swap.NextInstance<HttpContextWrapper>().With(ctx);

			//Act
			var mgr = new HttpContextLifetimeManager<object>();

			//Assert
			//Should pass
		}

		[TestMethod]
		public void GettingValueReturnsCorrectInstance()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			var obj = new object();
			Isolate.WhenCalled(() => ctx.Items[typeof(object)]).WillReturn(obj);

			//Act
			var mgr = new HttpContextLifetimeManager<object>(ctx);
			var value = mgr.GetValue();

			//Assert
			Assert.AreEqual(obj, value);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void PassingNullContextThrowsException()
		{
			//Arrange
			//Act
			new HttpContextLifetimeManager<object>(null);
		}

		[TestMethod]
		public void RemovingValueRemovesInstance()
		{
			//Arrange
			var obj = new object();
			var dict = new Dictionary<object, object>();
			dict.Add(typeof(object), obj);
			
			var ctx = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => ctx.Items).WillReturn(dict);

			//Act
			var mgr = new HttpContextLifetimeManager<object>(ctx);
			mgr.RemoveValue();

			//Assert
			Assert.IsFalse(dict.ContainsKey(typeof(object)));
		}

		[TestMethod]
		public void SettingValueUpdatesCorrectInstance()
		{
			//Arrange
			var items = new Dictionary<object, object>();
			var ctx = Isolate.Fake.Instance<HttpContextBase>();
			Isolate.WhenCalled(() => ctx.Items).WillReturn(items);

			var obj = new object();

			//Act
			var mgr = new HttpContextLifetimeManager<object>(ctx);
			mgr.SetValue(obj);

			//Assert
			Assert.AreEqual(obj, ctx.Items[typeof(object)]);
		}
	}
}
