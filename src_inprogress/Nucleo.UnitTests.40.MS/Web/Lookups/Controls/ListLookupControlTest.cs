using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.TestingTools;
using Nucleo.Lookups;


namespace Nucleo.Web.Lookups.Controls
{
	[TestClass]
	public class ListLookupControlTest
	{
		#region " Test Classes "

		public class TestRepository : ILookupRepository
		{
			private LookupCriteria _criteria = null;
			private LookupCollection _results = null;



			#region " Properties "

			public LookupCriteria Criteria
			{
				get { return _criteria; }
			}

			public string Name { get; set; }

			#endregion



			#region " Constructors "

			public TestRepository(LookupCollection results)
			{
				_results = results;
			}

			#endregion



			#region " Methods "

			public LookupCollection GetAllValues(LookupCriteria criteria)
			{
				_criteria = criteria;
				return _results;
			}

			#endregion
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void BindingNullResultsWorksOK()
		{
			//Arrange
			var repos = new TestRepository(new LookupCollection
			{
				new Lookup { Name = "1", Value = "1" },
				new Lookup { Name = "2", Value = "2" },
				new Lookup { Name = "3", Value = "3" }
			});

			var ctl = new DropDownList();
			var control = Isolate.Fake.Instance<ListLookupControl>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.NonPublic.WhenCalled(control, "GetRepository").WillReturn(repos);
			Isolate.WhenCalled(() => { return control.Control; }).WillReturn(ctl);

			//Act
			control.BindValues(null);

			//Assert
			Assert.IsNull(repos.Criteria);
			Assert.AreEqual(3, control.Control.Items.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void BindingValidCriteriaResultsWorksOK()
		{
			//Arrange
			var repos = new TestRepository(new LookupCollection
			{
				new Lookup { Name = "1", Value = "1" },
				new Lookup { Name = "2", Value = "2" },
				new Lookup { Name = "3", Value = "3" }
			});

			var ctl = new DropDownList();
			var control = Isolate.Fake.Instance<ListLookupControl>(Members.CallOriginal, ConstructorWillBe.Ignored);
			Isolate.NonPublic.WhenCalled(control, "GetRepository").WillReturn(repos);
			Isolate.WhenCalled(() => { return control.Control; }).WillReturn(ctl);

			var criteria = new LookupCriteria(DateTime.Now);

			//Act
			control.BindValues(criteria );

			//Assert
			Assert.AreEqual(criteria, repos.Criteria);
			Assert.AreEqual(3, control.Control.Items.Count);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void CreatingListControlWithNullsThrowsException()
		{


			//Assert
			ExceptionTester.CheckException(true, (src) => { new ListLookupControl(null, "Test"); });
			ExceptionTester.CheckException(true, (src) => { new ListLookupControl(new DropDownList(), null); });
			ExceptionTester.CheckException(true, (src) => { new ListLookupControl(new DropDownList(), string.Empty); });
		}


		[TestMethod]
		public void CreatingListControlWorksOK()
		{
			//Arrange
			var wrapper = default(ListLookupControl);
			var control = new DropDownList();

			//Act
			wrapper = new ListLookupControl(control, "Test");

			//Assert
			Assert.AreEqual(control, wrapper.Control);
			Assert.AreEqual("Test", wrapper.LookupName);
		}

		#endregion
	}
}
