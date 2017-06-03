using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Core
{
	[TestClass]
	public class WebSingletonManagerTest
	{
		#region " Tests "

		[TestMethod]
		public void CheckingEntryExistenceReturnsFalse()
		{
			//Arrange
			var mgr = Isolate.Fake.Instance<NucleoAjaxManager>();
			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.LocalStorage).WillReturn(new Dictionary<object, object>
			{
				{ typeof(NucleoAjaxManager), mgr }
			});

			Isolate.Fake.StaticMethods(typeof(WebContext));

			//Act
			var obj = (new WebSingletonManager(ctx)).HasEntry<Styles.StylesheetManager>();

			//Assert
			Assert.AreEqual(false, obj);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CheckingEntryExistenceReturnsTrue()
		{
			//Arrange
			var mgr = Isolate.Fake.Instance<NucleoAjaxManager>();
			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.LocalStorage).WillReturn(new Dictionary<object, object>
			{
				{ typeof(NucleoAjaxManager), mgr }
			});

			//Act
			var obj = (new WebSingletonManager(ctx)).HasEntry<NucleoAjaxManager>();

			//Assert
			Assert.AreEqual(true, obj);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingNewManagerWorksOK()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<IWebContext>();

			//Act
			NucleoAjaxManager mgr = Isolate.Fake.Instance<NucleoAjaxManager>();
			(new WebSingletonManager(ctx)).AddEntry<NucleoAjaxManager>(mgr);

			//Assert
			Isolate.Verify.WasCalledWithExactArguments(() => { ctx.LocalStorage.Add(typeof(NucleoAjaxManager), mgr); });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingEntriesWorksOK()
		{
			//Arrange
			var mgr = Isolate.Fake.Instance<NucleoAjaxManager>();
			Isolate.WhenCalled(() => mgr.ClientID).WillReturn("ct_Test");
			var ctx = Isolate.Fake.Instance<IWebContext>();
			Isolate.WhenCalled(() => ctx.LocalStorage).WillReturn(new Dictionary<object, object>
			{
				{ typeof(NucleoAjaxManager), mgr }
			});

			//Act
			var obj = (new WebSingletonManager(ctx)).GetEntry<NucleoAjaxManager>();

			//Assert
			Assert.IsNotNull(obj);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void UpdatingExistingManagerWorksOK()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<IWebContext>();
			var mgr = Isolate.Fake.Instance<NucleoAjaxManager>();
			Isolate.WhenCalled(() => mgr.ClientID).WillReturn("test");

			var results = new Dictionary<object, object>();
			results.Add(typeof(NucleoAjaxManager), new NucleoAjaxManager());

			Isolate.WhenCalled(() => ctx.LocalStorage).WillReturn(results);
			

			//Act
			(new WebSingletonManager(ctx)).AddOrUpdateEntry<NucleoAjaxManager>(mgr);
			
			//Assert
			Assert.AreEqual("test", ((NucleoAjaxManager)results[typeof(NucleoAjaxManager)]).ClientID);

			Isolate.CleanUp();
		}

		#endregion
	}
}
