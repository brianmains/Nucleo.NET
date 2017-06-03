using System;
using System.Configuration;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;
using Nucleo.Orm.Configuration;


namespace Nucleo.Orm
{
	[TestClass]
	public class ObjectContextManagerTest
	{
		#region " Test Classes "

		protected class CustomObjectContext : ObjectContext
		{
			public CustomObjectContext()
				: base("NucleoDB") { }

			public CustomObjectContext(string connection)
				: base(connection) { }
		}

		protected class TestClass : EntityObject
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

			var ctx = Isolate.Fake.Instance<CustomObjectContext>();
			Isolate.Swap.NextInstance<CustomObjectContext>().With(ctx);

			var settings = new ObjectContextSettingsSection();
			settings.ConnectionStringName = "NucleoDB";

			Isolate.Fake.StaticMethods(typeof(ObjectContextSettingsSection));
			Isolate.WhenCalled(() => ObjectContextSettingsSection.Instance).WillReturn(settings);

			//Act
			var mgr = ObjectContextManager<CustomObjectContext>.Create();

			//Assert
			Assert.IsInstanceOfType(mgr.Context, typeof(CustomObjectContext));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerFromConfigurationWithoutConnectionStringWorksOK()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<CustomObjectContext>();
			Isolate.Swap.NextInstance<CustomObjectContext>().With(ctx);

			var settings = new ObjectContextSettingsSection();
			Isolate.Fake.StaticMethods(typeof(ObjectContextSettingsSection));
			Isolate.WhenCalled(() => ObjectContextSettingsSection.Instance).WillReturn(settings);

			settings.ConnectionStringName = "NucleoDB";

			//Act
			var mgr = ObjectContextManager<CustomObjectContext>.Create();

			//Assert
			Assert.IsInstanceOfType(mgr.Context, typeof(CustomObjectContext));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerFromEntityConnectionBuilderWorksOK()
		{
			//Arrange
			var ctx = Isolate.Fake.Instance<CustomObjectContext>();
			Isolate.Swap.NextInstance<CustomObjectContext>().With(ctx);

			var builder = Isolate.Fake.Instance<EntityConnectionStringBuilder>();

			//Act
			var mgr = ObjectContextManager<CustomObjectContext>.Create(builder);

			//Assert
			Assert.IsInstanceOfType(mgr.Context, typeof(CustomObjectContext));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerWithContextWorksOK()
		{
			//Arrange
			var context = Isolate.Fake.Instance<CustomObjectContext>();

			//Act
			var mgr = ObjectContextManager<CustomObjectContext>.Create(context);

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

			var ctx = Isolate.Fake.Instance<CustomObjectContext>();
			Isolate.Swap.NextInstance<CustomObjectContext>().With(ctx);

			//Act
			var mgr = ObjectContextManager<CustomObjectContext>.Create("NucleoDB");

			//Assert
			Assert.IsInstanceOfType(mgr.Context, typeof(CustomObjectContext));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerWithGenericsWithoutConnectionStringWorksOK()
		{
			//Arrange
			Isolate.Fake.StaticMethods(typeof(ConfigurationManager));
			Isolate.WhenCalled(() => ConfigurationManager.ConnectionStrings["NucleoDB"].ConnectionString).WillReturn("Test");

			var ctx = Isolate.Fake.Instance<CustomObjectContext>();
			Isolate.Swap.NextInstance<CustomObjectContext>().With(ctx);

			var settings = new ObjectContextSettingsSection();
			settings.ConnectionStringName = "NucleoDB";

			Isolate.Fake.StaticMethods(typeof(ObjectContextSettingsSection));
			Isolate.WhenCalled(() => ObjectContextSettingsSection.Instance).WillReturn(settings);

			//Act
			var mgr = ObjectContextManager<CustomObjectContext>.Create();

			//Assert
			Assert.IsInstanceOfType(mgr.Context, typeof(CustomObjectContext));

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingTheContextManagerWithNullParamstThrowsException()
		{
			//Arrange

			//Act

			//Assert
			ExceptionTester.CheckException(true, (src) => { ObjectContextManager<CustomObjectContext>.Create(default(CustomObjectContext)); });
			ExceptionTester.CheckException(true, (src) => { ObjectContextManager<CustomObjectContext>.Create(default(string)); });
		}

		#endregion
	}
}
