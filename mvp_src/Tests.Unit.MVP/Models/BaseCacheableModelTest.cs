using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Core;
using Nucleo.Models.Cache;


namespace Nucleo.Models
{
	[TestClass]
	public class BaseCacheableModelTest
	{
		protected class TestModelCache : IModelCache
		{
			public Dictionary<string, object> Items = new Dictionary<string, object>();

			public object GetValueFromCache(ICacheableModel model, string key, ShareAccessLevel level)
			{
				var c = key + level.ToString();

				if (Items.ContainsKey(c))
					return Items[c];

				return null;
			}

			public void SetValueToCache(ICacheableModel model, string key, object value, ShareAccessLevel level)
			{
				var c = key + level.ToString();
				Items[c] = value;
			}
		}

		protected class TestModel : BaseCacheableModel
		{
			public string Name
			{
				get { return (string)this.GetValue("Name", ShareAccessLevel.None); }
				set { this.SetValue("Name", value, ShareAccessLevel.None); }
			}

			public string Text
			{
				get { return (string)this.GetValue("Text"); }
				set { this.SetValue("Text", value); }
			}

			public ArrayList Global
			{
				get { return (ArrayList)this.GetValue("Global", ShareAccessLevel.Global); }
				set { this.SetValue("Global", value, ShareAccessLevel.Global); }
			}

			public ArrayList States
			{
				get { return (ArrayList)this.GetValue("States", ShareAccessLevel.PerModel); }
				set { this.SetValue("States", value, ShareAccessLevel.PerModel); }
			}

			public object GetModelValue(string key)
			{
				return this.GetValue(key);
			}

			public object GetModelValue(string key, ShareAccessLevel cacheSettings)
			{
				return this.GetValue(key, cacheSettings);
			}

			public void SetModelValue(string key, object value)
			{
				this.SetValue(key, value);
			}

			public void SetModelValue(string key, object value, ShareAccessLevel cacheSettings)
			{
				this.SetValue(key, value, cacheSettings);
			}

			
		}

		[TestMethod]
		public void GettingAndSettingValueFromGlobalCacheablePropertyWorksOK()
		{
			var cache = new TestModelCache();

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.ModelCache).WillReturn(cache);

			var model = new TestModel();

			model.Global = new ArrayList
				{
					new { Name = "Pennsylvania", Code = "PA" },
					new { Name = "Maryland", Code = "MD" }
				};

			Assert.AreEqual(2, model.Global.Count);
			Assert.AreEqual(2, ((ArrayList)model.GetModelValue("Global", ShareAccessLevel.Global)).Count);
			Assert.IsNull(model.GetModelValue("Global", ShareAccessLevel.PerModel));
			Assert.IsNull(model.GetModelValue("Global", ShareAccessLevel.None));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingAndSettingValueFromPerModelCacheablePropertyWorksOK()
		{
			var cache = new TestModelCache();

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.ModelCache).WillReturn(cache);

			var model = new TestModel();

			model.States = new ArrayList
				{
					new { Name = "Pennsylvania", Code = "PA" },
					new { Name = "Maryland", Code = "MD" }
				};

			Assert.AreEqual(2, model.States.Count);
			Assert.AreEqual(2, ((ArrayList)model.GetModelValue("States", ShareAccessLevel.PerModel)).Count);
			Assert.IsNull(model.GetModelValue("States", ShareAccessLevel.Global));
			Assert.IsNull(model.GetModelValue("States", ShareAccessLevel.None));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingAndSettingValueFromNonCacheableMethodsWorksOK()
		{
			var cache = new TestModelCache();

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.ModelCache).WillReturn(cache);

			var model = new TestModel();

			model.Text = "XYZ";

			Assert.AreEqual("XYZ", model.Text);
			Assert.AreEqual("XYZ", model.GetModelValue("Text"));
			Assert.AreEqual("XYZ", model.GetModelValue("Text", ShareAccessLevel.None));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingAndSettingValueFromNonCacheablePropertyWorksOK()
		{
			var cache = new TestModelCache();

			Isolate.Fake.StaticMethods(typeof(FrameworkSettings));
			Isolate.WhenCalled(() => FrameworkSettings.ModelCache).WillReturn(cache);

			var model = new TestModel();

			model.Name = "XYZ";

			Assert.AreEqual("XYZ", model.Name);
			Assert.AreEqual("XYZ", model.GetModelValue("Name", ShareAccessLevel.None));
			Assert.IsNull(model.GetModelValue("Name", ShareAccessLevel.Global));
			Assert.IsNull(model.GetModelValue("Name", ShareAccessLevel.PerModel));

			Isolate.CleanUp();
		}
	}
}
