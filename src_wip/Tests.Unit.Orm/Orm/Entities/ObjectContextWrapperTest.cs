using System;
using System.Data.Common;
using System.Data.Objects;
using System.Data.Metadata.Edm;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;
using System.Data.Objects.DataClasses;
using System.Data;
using System.Collections;


namespace Nucleo.Orm.Entities
{
	[TestClass]
	public class ObjectContextWrapperTest
	{
		protected const string EntitySetName = "TestClass";

		protected class TestClass { }



		[TestMethod]
		public void CallingAcceptAllChangesCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.AcceptAllChanges();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.AcceptAllChanges());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingAddObjectCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.AddObject(EntitySetName, typeof(TestClass));

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.AddObject(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingApplyCurrentValuesCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.ApplyCurrentValues(EntitySetName, new TestClass());

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.ApplyCurrentValues<TestClass>(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingApplyOriginalValuesCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.ApplyOriginalValues(EntitySetName, new TestClass());

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.ApplyOriginalValues<TestClass>(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingAttachCallsContextMethod()
		{
			var entity = Isolate.Fake.Instance<IEntityWithKey>();
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.Attach(entity);

			Isolate.Verify.WasCalledWithExactArguments(() => ctx.Attach(entity));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingAttachToCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.AttachTo(EntitySetName, new TestClass());

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.AttachTo(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingCreateDatabaseCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.CreateDatabase();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.CreateDatabase());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingCreateDatabaseScriptCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.CreateDatabaseScript();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.CreateDatabaseScript());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingCreateEntityKeyCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.CreateEntityKey(EntitySetName, new TestClass());

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.CreateEntityKey(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingCreateObjectCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.CreateObject<TestClass>();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.CreateObject<TestClass>());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingCreateObjectSetCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.CreateObjectSet<TestClass>();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.CreateObjectSet<TestClass>());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingCreateObjectSet2CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.CreateObjectSet<TestClass>(EntitySetName);

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.CreateObjectSet<TestClass>(null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingCreateProxyTypesCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.CreateProxyTypes(new Type[] { typeof(TestClass) });

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.CreateProxyTypes(null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingCreateQueryCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.CreateQuery<TestClass>("", new ObjectParameter[] { });

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.CreateQuery<TestClass>(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingDatabaseExistsCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.DatabaseExists();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.DatabaseExists());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingDeleteDatabaseCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.DeleteDatabase();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.DeleteDatabase());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingDeleteObjectCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.DeleteObject(new TestClass());

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.DeleteObject(null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingDetachCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.Detach(new TestClass());

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.Detach(null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingDetectChangesCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.DetectChanges();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.DetectChanges());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingDisposeCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.Dispose();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.Dispose());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingExecuteFunctionCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.ExecuteFunction("", new ObjectParameter[] { });

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.ExecuteFunction(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingExecuteFunction2CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.ExecuteFunction<TestClass>("", new ObjectParameter[] { });

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.ExecuteFunction<TestClass>(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingExecuteFunction3CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.ExecuteFunction<TestClass>("", MergeOption.PreserveChanges, new ObjectParameter[] { });

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.ExecuteFunction<TestClass>(null, MergeOption.PreserveChanges, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingExecuteStoreCommandCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.ExecuteStoreCommand("", new ObjectParameter[] { });

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.ExecuteStoreCommand(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingExecuteStoreQueryCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.ExecuteStoreQuery<TestClass>("", new ObjectParameter[] { });

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.ExecuteStoreQuery<TestClass>(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingExecuteStoreQuery2CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.ExecuteStoreQuery<TestClass>("", MergeOption.PreserveChanges, new ObjectParameter[] { });

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.ExecuteStoreQuery<TestClass>(null, MergeOption.PreserveChanges, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingGetObjectByKeyCallsContextMethod()
		{
			var key = Isolate.Fake.Instance<EntityKey>();
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.GetObjectByKey(key);

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.GetObjectByKey(key));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingLoadPropertyCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.LoadProperty(new TestClass(), "A");

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.LoadProperty(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingLoadProperty2CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.LoadProperty<TestClass>(new TestClass(), i => i);

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.LoadProperty<TestClass>(null, null));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingLoadProperty3CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.LoadProperty(new TestClass(), "A", MergeOption.PreserveChanges);

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.LoadProperty(null, null, MergeOption.PreserveChanges));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingLoadProperty4CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.LoadProperty<TestClass>(new TestClass(), i => i, MergeOption.PreserveChanges);

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.LoadProperty<TestClass>(null, null, MergeOption.PreserveChanges));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingRefreshCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.Refresh(RefreshMode.StoreWins, new[] { new TestClass(), new TestClass() });

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.Refresh(RefreshMode.StoreWins, default(IEnumerable)));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingRefresh2CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.Refresh(RefreshMode.StoreWins, new TestClass());

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.Refresh(RefreshMode.StoreWins, default(object)));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingSaveChangesCallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx); ;

			wrapper.SaveChanges();

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.SaveChanges());
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingSaveChanges2CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.SaveChanges(true);

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.SaveChanges(true));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingSaveChanges3CallsContextMethod()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.SaveChanges(SaveOptions.AcceptAllChangesAfterSave));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingTranslateCallsContextMethod()
		{
			var reader = Isolate.Fake.Instance<DbDataReader>();
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.Translate<TestClass>(reader);

			Isolate.Verify.WasCalledWithExactArguments(() => ctx.Translate<TestClass>(reader));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingTranslate2CallsContextMethod()
		{
			var reader = Isolate.Fake.Instance<DbDataReader>();
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.Translate<TestClass>(reader, EntitySetName, MergeOption.PreserveChanges);

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.Translate<TestClass>(null, null, MergeOption.PreserveChanges));
			Isolate.CleanUp();
		}

		[TestMethod]
		public void CallingTryGetObjectByKeyCallsContextMethod()
		{
			var key = Isolate.Fake.Instance<EntityKey>();
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			object output;

			wrapper.TryGetObjectByKey(key, out output);

			Isolate.Verify.WasCalledWithAnyArguments(() => ctx.TryGetObjectByKey(null, out output));
			Isolate.CleanUp();
		}

		[
		TestMethod,
		ExpectedException(typeof(ArgumentNullException))
		]
		public void CreatingWrapperThrowsExceptionWhenContextIsNull()
		{
			new ObjectContextWrapper(null);
		}

		[TestMethod]
		public void CreatingWrapperWorksOK()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			new ObjectContextWrapper(ctx);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingConnectionReturnsCorrectObject()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			var output = wrapper.Connection;

			Isolate.Verify.WasCalledWithAnyArguments(() => wrapper.Connection);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingContextOptionsReturnsCorrectObject()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			var output = wrapper.ContextOptions;

			Isolate.Verify.WasCalledWithAnyArguments(() => wrapper.ContextOptions);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingMetadataWorkspaceReturnsCorrectObject()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			var output = wrapper.MetadataWorkspace;

			Isolate.Verify.WasCalledWithAnyArguments(() => wrapper.MetadataWorkspace);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingObjectStateManagerReturnsCorrectObject()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			var output = wrapper.ObjectStateManager;

			Isolate.Verify.WasCalledWithAnyArguments(() => wrapper.ObjectStateManager);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingCommandTimeoutAssignsOK()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.CommandTimeout = 300;

			Isolate.Verify.WasCalledWithExactArguments(() => { ctx.CommandTimeout = 300; });

			Isolate.CleanUp();
		}

		[TestMethod]
		public void SettingDefaultContainerAssignsOK()
		{
			var ctx = Isolate.Fake.Instance<ObjectContext>();
			var wrapper = Isolate.Fake.Instance<ObjectContextWrapper>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.WhenCalled(() => wrapper.OriginalContext).WillReturn(ctx);

			wrapper.DefaultContainerName = "AGBC";

			Isolate.Verify.WasCalledWithExactArguments(() => { ctx.DefaultContainerName = "AGBC"; });

			Isolate.CleanUp();
		}
	}
}
