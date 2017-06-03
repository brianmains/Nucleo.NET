using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Configuration;
using Nucleo.Context;
using Nucleo.Context.Services;
using Nucleo.EventArguments;
using Nucleo.Logs;
using Nucleo.Reflection;
using Nucleo.TestingTools;
using Nucleo.Orm.Configuration;
using Nucleo.Orm.Triggers;


namespace Nucleo.Orm
{
	[TestClass]
	public class DataContextManagerTest
	{
		#region " Test Classes "

		protected class CustomDataContext : DataContext
		{
			public CustomDataContext()
				: base("NucleoDB") { }

			public CustomDataContext(string connection)
				: base(connection) { }
		}

		protected class TestChild
		{
			public string Name { get; set; }
			public string Value { get; set; }
		}

		protected class TestClass
		{
			public string Name { get; set; }
			public string Value { get; set; }

			public List<TestChild> Items { get; set; }
		}

		protected class MissingTestClass
		{
			public string Name { get; set; }
			public string Value { get; set; }
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingTheContextManagerFromConfigurationWithConnectionStringWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(ConfigurationManager));
			Isolate.WhenCalled(() => ConfigurationManager.ConnectionStrings["NucleoDB"].ConnectionString).WillReturn("Test");

			var settings = new DataContextSettingsSection();
			settings.ConnectionStringName = "NucleoDB";
			
			Isolate.Fake.StaticMethods(typeof(DataContextSettingsSection));
			Isolate.WhenCalled(() => DataContextSettingsSection.Instance).WillReturn(settings);

			//Act
			var mgr = DataContextManager<CustomDataContext>.Create();

			//Assert
			Assert.IsInstanceOfType(mgr.Context, typeof(CustomDataContext));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerFromConfigurationWithoutConnectionStringWorksOK()
		{
			//Arrange
			var settings = new DataContextSettingsSection();

			Isolate.Fake.StaticMethods(typeof(DataContextSettingsSection));
			Isolate.WhenCalled(() => DataContextSettingsSection.Instance).WillReturn(settings);

			//Act
			var mgr = DataContextManager<CustomDataContext>.Create();

			//Assert
			Assert.IsInstanceOfType(mgr.Context, typeof(CustomDataContext));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerWithContextWorksOK()
		{
			//Arrange
			var context = Isolate.Fake.Instance<CustomDataContext>();

			//Act
			var mgr = DataContextManager<CustomDataContext>.Create(context);

			//Assert
			Assert.IsNotNull(mgr);
			Assert.IsNotNull(mgr.Context);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerWithGenericsWithConnectionStringWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(ConfigurationManager));
			Isolate.WhenCalled(() => ConfigurationManager.ConnectionStrings["NucleoDB"].ConnectionString).WillReturn("Test");

			var mgr = default(DataContextManager<CustomDataContext>);

			//Act
			mgr = DataContextManager<CustomDataContext>.Create("NucleoDB");

			//Assert
			Assert.IsInstanceOfType(mgr.Context, typeof(CustomDataContext));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerWithGenericsWithoutConnectionStringWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(ConfigurationManager));
			Isolate.WhenCalled(() => ConfigurationManager.ConnectionStrings["NucleoDB"].ConnectionString).WillReturn("Test");

			var settings = new DataContextSettingsSection();
			settings.ConnectionStringName = "NucleoDB";

			Isolate.Fake.StaticMethods(typeof(DataContextSettingsSection));
			Isolate.WhenCalled(() => DataContextSettingsSection.Instance).WillReturn(settings);

			//Act
			var mgr = DataContextManager<CustomDataContext>.Create();

			//Assert
			Assert.IsInstanceOfType(mgr.Context, typeof(CustomDataContext));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerWithNullParamstThrowsException()
		{
			//Arrange

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { DataContextManager<CustomDataContext>.Create(default(CustomDataContext)); });
			ExceptionTester.CheckException(true, (src) => { DataContextManager<CustomDataContext>.Create(default(string)); });
		}

		[TestMethod]
		public void ExecutingQueryWorksOK()
		{
			//Arrange
			var query = new List<TestClass>
			{
				new TestClass { Name = "First", Value = "1" },
				new TestClass { Name = "Second", Value = "2" }
			};

			var mgr = Isolate.Fake.Instance<DataContextManager<CustomDataContext>>(Members.CallOriginal);

			//Act
			var results = mgr.Query(query.AsQueryable());

			//Assert
			Assert.AreEqual(2, results.Count());

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingTriggersThroughWrappingPushesUnderlyingValue()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(DataClassTriggers));
			Isolate.WhenCalled(() => DataClassTriggers.GetTriggers<TestClass>(null, TriggerAction.Insert)).WillReturn(null);

			var mgr = Isolate.Fake.Instance<DataContextManager<CustomDataContext>>(Members.CallOriginal);

			//Act
			var triggers = mgr.GetTriggers<TestClass>(TriggerAction.Insert);

			//Assert
			Assert.IsNull(triggers);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void QueuingDeleteWorksOK()
		{
			//Arrange
			var test = new TestClass
			{
				Name = "A",
				Value = "1",
				Items = new List<TestChild>
				{
					new TestChild { Name = "C1", Value = "C1 VAL" },
					new TestChild { Name = "C2", Value = "C2 VAL" }
				}
			};

			var trigger = new FakeTrigger(true, (o, a) => 
			{ 
				((TestClass)o).Items.Clear();
			});

			var mgr = Isolate.Fake.Instance<DataContextManager<CustomDataContext>>(Members.CallOriginal);
			Isolate.WhenCalled(() => mgr.GetTriggers<TestClass>(TriggerAction.Delete)).WillReturn(new TriggerCollection { trigger });
			Isolate.WhenCalled(() => mgr.Context.GetTable<TestClass>().DeleteOnSubmit(null)).IgnoreCall();

			//Act
			mgr.QueueDelete(test);

			//Assert
			Assert.AreEqual(0, test.Items.Count, "Items weren't deleted");

			Isolate.CleanUp();
		}

		[TestMethod]
		public void QueuingInsertWorksOK()
		{
			//Arrange
			var test = new TestClass { Name = "A", Value = "1" };
			var trigger = new FakeTrigger(true, (o, a) => { ((TestClass)o).Value = "NewVal"; });

			var mgr = Isolate.Fake.Instance<DataContextManager<CustomDataContext>>(Members.CallOriginal);
			Isolate.WhenCalled(() => mgr.GetTriggers<TestClass>(TriggerAction.Insert)).WillReturn(new TriggerCollection { trigger });
			Isolate.WhenCalled(() => mgr.Context.GetTable<TestClass>().InsertOnSubmit(null)).IgnoreCall();

			//Act
			mgr.QueueInsert(test);

			//Assert
			Assert.AreEqual("NewVal", test.Value);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SavingChangesToDatabaseWithErrorsFiresEvent()
		{
			//Arrange
			var context = Isolate.Fake.Instance<CustomDataContext>();
			Isolate.WhenCalled(() => context.SubmitChanges()).WillThrow(new Exception());

			var manager = Isolate.Fake.Instance<DataContextManager<CustomDataContext>>(Members.CallOriginal);
			Isolate.WhenCalled(() => manager.Context).WillReturn(context);

			bool fired = false;
			bool exception = false;

			//Act
			manager.ChangesSubmitted += delegate(object sender, DataContextManagerSubmitEventArgs e)
			{
				fired = true;
				exception = (e.Exception != null);
			};

			manager.SaveChangesToDatabase();

			//Assert
			Assert.IsTrue(fired);
			Assert.IsTrue(exception);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SavingChangesToDatabaseWithErrorsLogsThem()
		{
			//Arrange
			var context = Isolate.Fake.Instance<CustomDataContext>();
			Isolate.WhenCalled(() => context.SubmitChanges()).WillThrow(new Exception());

			var logger = new FakeLoggerService();

			var manager = Isolate.Fake.Instance<DataContextManager<CustomDataContext>>(Members.CallOriginal);
			Isolate.WhenCalled(() => manager.Context).WillReturn(context);
			Isolate.NonPublic.WhenCalled(manager, "GetLoggerService").WillReturn(logger);
			
			//Act
			bool result = manager.SaveChangesToDatabase(); 

			//Assert
			Assert.IsFalse(result);
			Assert.AreEqual(1, logger.Entries.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SavingChangesToDatabaseWorksOK()
		{
			//Arrange
			var context = Isolate.Fake.Instance<CustomDataContext>();
			var manager = DataContextManager<CustomDataContext>.Create(context);

			//Act
			bool result = manager.SaveChangesToDatabase();

			//Assert
			Assert.AreEqual(true, result);

			Isolate.CleanUp();
		}

		#endregion
	}
}
