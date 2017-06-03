using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.ObjectModel;
using Nucleo.Views;
using Nucleo.TestingTools;


namespace Nucleo.Presentation
{
	[TestClass]
	public partial class BasePresenterTest
	{
		#region " Test Classes "

		public class TestModel : AttributedObject
		{
			public string Name
			{
				get { return base.GetValue<string>("Name"); }
				set { base.AddOrUpdateValue("Name", value); }
			}

			public string City
			{
				get { return base.GetValue<string>("City"); }
				set { base.AddOrUpdateValue("City", value); }
			}
		}

		public interface ITestView : IView
		{
			string Name { get; set; }
			string City { get; set; }
		}

		public class TestView : View, ITestView
		{
			public TestModel Model { get; set; }

			public string Name { get; set; }

			public string City { get; set; }
		}

		//Must be public to fake
		public interface ITestModelView : IView<TestModel>
		{
			
		}

		public class TestModelView : View<TestModel>, ITestModelView
		{

		}

		public class TestPresenter : BasePresenter
		{
			public TestPresenter(ITestView view) 
				: base(view) { }
		}

		public class TestPresenter2 : BasePresenter<ITestView>
		{
			public TestPresenter2(ITestView view)
				: base(view) { }
		}

		public class TestPresenter3 : BasePresenter<ITestModelView>
		{
			public TestPresenter3(ITestModelView view)
				: base(view) { }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingSubPresentersWorksOK()
		{
			//Arrange
			var presenter1 = Isolate.Fake.Instance<TestPresenter>(Members.CallOriginal, ConstructorWillBe.Ignored);
			var presenter2 = Isolate.Fake.Instance<TestPresenter2>(Members.CallOriginal, ConstructorWillBe.Ignored);

			//Act
			presenter1.Subpresenters.Add(presenter2);
			
			//Assert
			Assert.AreEqual(1, presenter1.Subpresenters.Count);
		}

		[TestMethod]
		public void CreatingPresenterContextWorksOK()
		{
			//Arrange
			var presenter = Isolate.Fake.Instance<TestPresenter>(Members.CallOriginal, ConstructorWillBe.Ignored);

			//Act
			var hasContext1 = presenter.HasCurrentContext;
			var context = presenter.CurrentContext;
			var hasContext2 = presenter.HasCurrentContext;

			//Assert
			Assert.IsFalse(hasContext1);
			Assert.IsNotNull(context.EventRegistry);
			Assert.IsTrue(hasContext2);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingWithViewWorksOK()
		{
			//Arrange
			var view = new TestView();

			//Act
			var presenter = new TestPresenter(view);

			//Assert
			Assert.AreEqual(view, presenter.View);
		}

		[TestMethod]
		public void CreatingWithGenericViewWorksOK()
		{
			//Arrange
			var view = new TestView();

			//Act
			var presenter = new TestPresenter2(view);

			//Assert
			Assert.AreEqual(view, presenter.View);
		}

		[TestMethod]
		public void CreatingWithGenericViewAndModelWorksOK()
		{
			//Arrange
			var view = Isolate.Fake.Instance<ITestModelView>();

			//Act
			var presenter = new TestPresenter3(view);

			//Assert
			Assert.AreEqual(view, presenter.View);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingAndSettingPropsWorksOK()
		{
			//Arrange
			var presenter = Isolate.Fake.Instance<BasePresenter>(Members.CallOriginal);
			var ctx = new PresenterContext();

			//Act
			presenter.CurrentContext = ctx;

			//Assert
			Assert.AreEqual(ctx, presenter.CurrentContext);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingCurrentContextReturnsHasCurrentContextAsTrue()
		{
			//Arrange
			var presenter = Isolate.Fake.Instance<BasePresenter>(Members.CallOriginal);

			//Act
			var original = presenter.HasCurrentContext;
			presenter.CurrentContext = new PresenterContext();
			var final = presenter.HasCurrentContext;

			//Assert
			Assert.IsFalse(original);
			Assert.IsTrue(final);

			Isolate.CleanUp();
		}

		#endregion
	}
}
