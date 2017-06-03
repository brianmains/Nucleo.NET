using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Nucleo.Services
{
	[TestClass]
	public class ContextBasedServiceDictionaryTest
	{
		protected class TestService : NameValueCollectionService 
		{
			public NameValueCollection List = new NameValueCollection();


			protected override NameValueCollection GetUnderlyingCollection()
			{
				return List;
			}
		}



		[TestMethod]
		public void AddingItemsToListAddsOK()
		{
			var service = new TestService();

			service.Add("A", 1);
			service.Add("B", 2);

			Assert.AreEqual("1", service["A"]);
			Assert.AreEqual("2", service["B"]);
		}

		[TestMethod]
		public void AddingEmptyItemsToListAddsOK()
		{
			var service = new TestService();

			service.Add("A", string.Empty);

			Assert.AreEqual(string.Empty, service.List["A"]);
		}

		[TestMethod]
		public void AddingNullItemsToListAddsOK()
		{
			var service = new TestService();

			service.Add("A", null);

			Assert.AreEqual(null, service.List["A"]);
		}

		[TestMethod]
		public void ContainsDoesntReturnMatchingItem()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			Assert.IsFalse(service.Contains("B"));
		}

		[TestMethod]
		public void ContainsReturnsMatchingItem()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			Assert.IsTrue(service.Contains("A"));
		}

		[TestMethod]
		public void GettingCountReturnsCorrectValue()
		{
			var service = new TestService();
			service.List.Add("A", "1");
			service.List.Add("B", "2");

			Assert.AreEqual(2, service.Count);
		}

		[TestMethod]
		public void GettingItemByKeyDoesntReturnMatchingItem()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			Assert.AreEqual(null, service.Get("B"));
		}

		[TestMethod]
		public void GettingItemByKeyReturnsMatchingItem()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			Assert.AreEqual("1", service.Get("A"));
		}

		[TestMethod]
		public void GettingItemByIndexDoesntReturnMatchingItem()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			Assert.AreEqual(null, service.Get(1));
		}

		[TestMethod]
		public void GettingItemByIndexReturnsMatchingItem()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			Assert.AreEqual("1", service.Get(0));
		}

		[TestMethod]
		public void GettingThisReferenceToItemFindsMatchingItem()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			Assert.AreEqual("1", service["A"]);
		}

		[TestMethod]
		public void GettingThisReferenceToItemReturnsNull()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			Assert.AreEqual(null, service["B"]);
		}

		[TestMethod]
		public void RemoveItemFromCollectionAtIndexRemovesFromList()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			service.RemoveAt(0);

			Assert.IsNull(service.List["A"]);
		}

		[TestMethod]
		public void RemoveItemFromCollectionRemovesFromList()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			service.Remove("A");

			Assert.IsNull(service.List["A"]);
		}

		[TestMethod]
		public void SettingByKeyWhenUnderlyingValueIsNullSetsOK()
		{
			var service = new TestService();

			service["A"] = "1";

			Assert.AreEqual("1", service.List["A"]);
		}

		[TestMethod]
		public void SettingEmptyToCollectionAssignsOK()
		{
			var service = new TestService();

			service["A"] = string.Empty;

			Assert.AreEqual(string.Empty, service.List["A"]);
		}

		[TestMethod]
		public void SettingNullToCollectionAssignsOK()
		{
			var service = new TestService();

			service["A"] = null;

			Assert.AreEqual(null, service.List["A"]);
		}

		[TestMethod]
		public void SettingToOverrideOriginalValueAssignsOK()
		{
			var service = new TestService();
			service.List.Add("A", "1");

			service["A"] = "2";

			Assert.AreEqual("2", service.List["A"]);
		}
	}
}
