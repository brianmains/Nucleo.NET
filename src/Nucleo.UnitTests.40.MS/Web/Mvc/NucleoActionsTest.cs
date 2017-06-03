using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TypeMock.ArrangeActAssert;

using Nucleo.Models;
using Nucleo.Web.Lookups;


namespace Nucleo.Web.Mvc
{
	public class NucleoActionsTest
	{
		#region " Test Classes "

		public class TestClass
		{
			public string Name { get; set; }
			public string Value { get; set; }
		}

		public class AnotherTestClass
		{
			public string Name { get; set; }
			public string Value { get; set; }
			public object Key { get; set; }
		}

		public class TestModel : BaseModel
		{
			public TestClass First
			{
				get { return base.GetValue<TestClass>("First"); }
				set { base.AddOrUpdateValue("First", value); }
			}

			public AnotherTestClass Second
			{
				get { return base.GetValue<AnotherTestClass>("Second"); }
				set { base.AddOrUpdateValue("Second", value); }
			}
		}

		#endregion



		#region " Tests "

		public void GettingViewResultWithModelInjectionWorksOK()
		{

		}

		public void RenderingPartialViewUsingMainModelMethodWithMatchingViewNameWorksOK()
		{
			//Arrange
			var viewDataDictionary = new ViewDataDictionary<TestModel>();
			viewDataDictionary.Model = new TestModel
			{
				First = new TestClass { Name = "Ford", Value = "Focus" },
				Second = new AnotherTestClass { Name = "Toyota", Value = "Corolla", Key = 123 }
			};

			HtmlHelper helper = Isolate.Fake.Instance<HtmlHelper>();
			Isolate.WhenCalled(() => helper.ViewData).WillReturn(viewDataDictionary);
			Isolate.WhenCalled(() => helper.RenderPartial(default(string), default(object))).IgnoreCall();

			//Act
			NucleoActions actions = new NucleoActions(helper);
			actions.RenderPartial("First");

			//Assert
			Isolate.Verify.WasCalledWithArguments(() => { helper.RenderPartial("First", viewDataDictionary.Model.First); });

			Isolate.CleanUp();
		}

		public void RenderingPartialViewUsingMainModelMethodWithModelViewNameWorksOK()
		{
			//Arrange
			var viewDataDictionary = new ViewDataDictionary<TestModel>();
			viewDataDictionary.Model = new TestModel
			{
				First = new TestClass { Name = "Ford", Value = "Focus" },
				Second = new AnotherTestClass { Name = "Toyota", Value = "Corolla", Key = 123 }
			};

			HtmlHelper helper = Isolate.Fake.Instance<HtmlHelper>();
			Isolate.WhenCalled(() => helper.ViewData).WillReturn(viewDataDictionary);
			Isolate.WhenCalled(() => helper.RenderPartial(default(string), default(object))).IgnoreCall();

			//Act
			NucleoActions actions = new NucleoActions(helper);
			actions.RenderPartial("Test", "First");

			//Assert
			Isolate.Verify.WasCalledWithArguments(() => { helper.RenderPartial("Test", viewDataDictionary.Model.First); });

			Isolate.CleanUp();
		}

		public void RenderingPartialViewUsingMainModelTypeWorksOK()
		{
			//Arrange
			var viewDataDictionary = new ViewDataDictionary<TestModel>();
			viewDataDictionary.Model = new TestModel
			{
				First = new TestClass { Name = "Ford", Value = "Focus" },
				Second = new AnotherTestClass { Name = "Toyota", Value = "Corolla", Key = 123 }
			};

			HtmlHelper helper = Isolate.Fake.Instance<HtmlHelper>();
			Isolate.WhenCalled(() => helper.ViewData).WillReturn(viewDataDictionary);
			Isolate.WhenCalled(() => helper.RenderPartial(default(string), default(object))).IgnoreCall();

			//Act
			NucleoActions actions = new NucleoActions(helper);
			actions.RenderPartial<AnotherTestClass>("Test");

			//Assert
			Isolate.Verify.WasCalledWithArguments(() => { helper.RenderPartial("Test", viewDataDictionary.Model.Second); });

			Isolate.CleanUp();
		}

		#endregion
	}
}
