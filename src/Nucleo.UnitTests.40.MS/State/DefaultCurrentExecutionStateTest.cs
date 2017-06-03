using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nucleo.EventArguments;

namespace Nucleo.State
{
	[TestClass]
	public class DefaultCurrentExecutionStateTest
	{
		[TestMethod]
		public void GettingMissingValueReturnsNull()
		{
			var state = new DefaultCurrentExecutionState();

			Assert.AreEqual(null, state.Get("A"));
		}

		[TestMethod]
		public void GettingValueReturnsCorrectValue()
		{
			var state = new DefaultCurrentExecutionState();

			state.Set(new StateValue{ Key = "A", Value = 1 });

			Assert.AreEqual(1, state.Get("A").Value);
		}

		[TestMethod]
		public void HasValueReturnsTrue()
		{
			var state = new DefaultCurrentExecutionState();

			state.Set(new StateValue { Key = "A", Value = 1 });

			Assert.IsTrue(state.HasValue("A"));
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void PassingNullKeyToGetThrowsException()
		{
			var state = new DefaultCurrentExecutionState();

			state.Get(null);
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void PassingNullKeyToSetThrowsException()
		{
			var state = new DefaultCurrentExecutionState();

			state.Set(new StateValue { Key = null, Value = 13 });
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void PassingNullStateValueToSetThrowsException()
		{
			var state = new DefaultCurrentExecutionState();

			state.Set(null);
		}

		[TestMethod]
		public void SettingDifferentValueDoesFireEvent()
		{
			var state = new DefaultCurrentExecutionState();
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
			var state = new DefaultCurrentExecutionState();
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
			var state = new DefaultCurrentExecutionState();

			state.Set(new StateValue { Key = "A", Value = 1 });
			state.Set(new StateValue { Key = "A", Value = 2 });

			Assert.AreEqual(2, state.Get("A").Value);
		}

		[TestMethod]
		public void SettingSameValueDoesNotFireEvent()
		{
			var state = new DefaultCurrentExecutionState();
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
			var state = new DefaultCurrentExecutionState();

			state.Set(new StateValue { Key = "A", Value = 1 });

			Assert.AreEqual(1, state.Get("A").Value);
		}
	}
}
