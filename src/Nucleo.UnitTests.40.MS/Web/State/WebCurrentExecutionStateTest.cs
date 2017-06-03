using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.EventArguments;
using Nucleo.State;


namespace Nucleo.Web.State
{
	[TestClass]
	public class WebCurrentExecutionStateTest
	{
		[TestMethod]
		public void GettingMissingValueReturnsNull()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());

			var state = new WebCurrentExecutionState(context);

			Assert.AreEqual(null, state.Get("A"));
		}

		[TestMethod]
		public void GettingValueReturnsCorrectValue()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());
			var state = new WebCurrentExecutionState(context);

			state.Set(new StateValue { Key = "A", Value = 1 });

			Assert.AreEqual(1, state.Get("A").Value);
		}

		[TestMethod]
		public void HasValueReturnsTrue()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());
			var state = new WebCurrentExecutionState(context);

			state.Set(new StateValue { Key = "A", Value = 1 });

			Assert.IsTrue(state.HasValue("A"));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void PassingNullKeyToGetThrowsException()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());
			var state = new WebCurrentExecutionState(context);

			state.Get(null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void PassingNullKeyToSetThrowsException()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());
			var state = new WebCurrentExecutionState(context);

			state.Set(new StateValue { Key = null, Value = 13 });
		}

		[TestMethod]
		public void SettingDifferentValueDoesFireEvent()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());
			var state = new WebCurrentExecutionState(context);
			state.Set(new StateValue { Key = "A", Value = 1 });

			bool fired = false;
			state.ValueChanged += delegate(object sender, StateValueChangedEventArgs e)
			{
				fired = true;
			};

			state.Set(new StateValue { Key = "A", Value = 2 });

			Assert.IsTrue(fired);
		}

		[TestMethod]
		public void SettingFirstValueDoesNotFireEvent()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());
			var state = new WebCurrentExecutionState(context);
			bool fired = false;
			state.ValueChanged += delegate(object sender, StateValueChangedEventArgs e)
			{
				fired = true;
			};

			state.Set(new StateValue { Key = "A", Value = 2 });

			Assert.IsFalse(fired);
		}

		[TestMethod]
		public void SettingMultipleValuesOverridesOriginalEntries()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());
			var state = new WebCurrentExecutionState(context);

			state.Set(new StateValue { Key = "A", Value = 1 });
			state.Set(new StateValue { Key = "A", Value = 2 });

			Assert.AreEqual(2, state.Get("A").Value);
		}

		[TestMethod]
		public void SettingSameValueDoesNotFireEvent()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());
			var state = new WebCurrentExecutionState(context);
			state.Set(new StateValue { Key = "A", Value = 1 });

			bool fired = false;
			state.ValueChanged += delegate(object sender, StateValueChangedEventArgs e)
			{
				fired = true;
			};

			state.Set(new StateValue { Key = "A", Value = 1 });

			Assert.IsFalse(fired);
		}

		[TestMethod]
		public void SettingValueAddsToDictionary()
		{
			var context = Isolate.Fake.Instance<HttpContextBase>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => context.Items).WillReturn(new Dictionary<object, object>());
			var state = new WebCurrentExecutionState(context);

			state.Set(new StateValue { Key = "A", Value = 1 });

			Assert.AreEqual(1, state.Get("A").Value);
		}
	}
}
