using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.IO;


namespace Nucleo.Services
{
	[TestClass]
	public class InMemoryPostedFilesServiceTest
	{
		[TestMethod]
		public void AddingFilesAddsOK()
		{
			var p1 = Isolate.Fake.Instance<PostedFile>();
			var p2 = Isolate.Fake.Instance<PostedFile>();

			var service = new InMemoryPostedFilesService();
			service.Add(p1);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingEmptyWorksOK()
		{
			new InMemoryPostedFilesService();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWithNullListThrowsException()
		{
			new InMemoryPostedFilesService(null);
		}

		[TestMethod]
		public void CreatingWithValidListWorksOK()
		{
			var p1 = Isolate.Fake.Instance<PostedFile>();
			var p2 = Isolate.Fake.Instance<PostedFile>();

			new InMemoryPostedFilesService(new List<PostedFile> { p1, p2 });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingByIndexWorksOK()
		{
			var p1 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p1.FileName).WillReturn("test.txt");
			var p2 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p2.FileName).WillReturn("old.txt");

			var service = new InMemoryPostedFilesService(new List<PostedFile> { p1, p2 });

			var file = service.Get(0);

			Assert.AreEqual(p1.FileName, file.FileName);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingByMissingNameReturnsNull()
		{
			var p1 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p1.FileName).WillReturn("test.txt");
			var p2 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p2.FileName).WillReturn("old.txt");

			var service = new InMemoryPostedFilesService(new List<PostedFile> { p1, p2 });

			var file = service.Get("test14notfound.txt");

			Assert.IsNull(file);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingByNameWorksOK()
		{
			var p1 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p1.FileName).WillReturn("test.txt");
			var p2 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p2.FileName).WillReturn("old.txt");

			var service = new InMemoryPostedFilesService(new List<PostedFile> { p1, p2 });

			var file = service.Get("test.txt");

			Assert.AreEqual(p1.FileName, file.FileName);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void RemovingAnItemByIndexWorksOK()
		{
			var p1 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p1.FileName).WillReturn("test.txt");
			var p2 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p2.FileName).WillReturn("old.txt");
			var list = new List<PostedFile> { p1, p2 };

			var service = new InMemoryPostedFilesService(list);

			service.RemoveAt(1);

			Assert.AreEqual(1, list.Count);
			Assert.IsFalse(list.Contains(p2));
		}

		[TestMethod]
		public void RemovingAnItemByReferenceWorksOK()
		{
			var p1 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p1.FileName).WillReturn("test.txt");
			var p2 = Isolate.Fake.Instance<PostedFile>();
			Isolate.WhenCalled(() => p2.FileName).WillReturn("old.txt");
			var list = new List<PostedFile> { p1, p2 };

			var service = new InMemoryPostedFilesService(list);

			service.Remove(p2);

			Assert.AreEqual(1, list.Count);
			Assert.IsFalse(list.Contains(p2));
		}
	}
}
