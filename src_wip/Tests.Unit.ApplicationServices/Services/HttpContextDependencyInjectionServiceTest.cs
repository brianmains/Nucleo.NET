using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Services
{
	[TestClass]
	public class HttpContextDependencyInjectionServiceTest
	{
		protected class FoundItem { }

		protected class NotFoundItem { }



		[TestMethod]
		public void GettingResolvedItemByGenericTypeReturnsItem()
		{
			var item = new FoundItem();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ typeof(FoundItem), item }
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve<FoundItem>();

			Assert.IsNotNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingResolvedItemByGenericTypeReturnsNull()
		{
			var item = new FoundItem();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ typeof(FoundItem), item }
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve<NotFoundItem>();

			Assert.IsNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingResolvedItemByTypeReturnsItem()
		{
			var item = new FoundItem();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ typeof(FoundItem), item }
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve(typeof(FoundItem));

			Assert.IsNotNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingResolvedItemByTypeReturnsNull()
		{
			var item = new FoundItem();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ typeof(FoundItem), item }
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve(typeof(NotFoundItem));

			Assert.IsNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingResolvedKeyedItemByGenericTypeReturnsItem()
		{
			var item = new FoundItem();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ 
					typeof(FoundItem), new Dictionary<string, object>
					{
						{ "A", new FoundItem() }
					}
				}
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve<FoundItem>("A");

			Assert.IsNotNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingResolvedKeyedItemByGenericTypeReturnsNull()
		{
			var item = new FoundItem();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ 
					typeof(FoundItem), new Dictionary<string, object>
					{
						{ "A", new FoundItem() }
					}
				}
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve<NotFoundItem>("A");

			Assert.IsNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingResolvedKeyedItemByGenericTypeReturnsNullWithKeyMismatch()
		{
			var item = new FoundItem();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ 
					typeof(FoundItem), new Dictionary<string, object>
					{
						{ "A", new FoundItem() }
					}
				}
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve<FoundItem>("B");

			Assert.IsNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingResolvedKeyedItemByTypeReturnsItem()
		{
			var item = new FoundItem();
			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items[typeof(FoundItem)]).WithExactArguments()
				.WillReturn(new Dictionary<string, object> { { "A", new FoundItem() } });

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve(typeof(FoundItem), "A");

			Assert.IsNotNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingResolvedKeyedItemByTypeReturnsNull()
		{
			var item = new FoundItem();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ 
					typeof(FoundItem), new Dictionary<string, object>
					{
						{ "A", new FoundItem() }
					}
				}
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve(typeof(NotFoundItem), "A");

			Assert.IsNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingResolvedKeyedItemByTypeReturnsNullWithKeyMismatch()
		{
			var item = new FoundItem();

			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ 
					typeof(FoundItem), new Dictionary<string, object>
					{
						{ "A", new FoundItem() }
					}
				}
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve(typeof(FoundItem), "B");

			Assert.IsNull(output);
			Isolate.CleanUp();
		}

		[TestMethod]
		public void InvalidFormatInHttpContextReturnsNull()
		{
			Isolate.Fake.StaticMethods(typeof(HttpContext));
			Isolate.WhenCalled(() => HttpContext.Current.Items).WillReturn(new Dictionary<object, object>
			{
				{ typeof(FoundItem), new object() }
			});

			var service = new HttpContextDependencyInjectionService();
			var output = service.Resolve(typeof(FoundItem), "A");

			Assert.IsNull(output);
			Isolate.CleanUp();
		}
	}
}
