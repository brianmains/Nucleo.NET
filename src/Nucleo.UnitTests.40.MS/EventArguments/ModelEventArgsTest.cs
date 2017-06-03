using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.EventArguments
{
	[TestClass]
	public class ModelEventArgsTest
	{
		#region " Test Classes "

		public class TestModel { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void CreatingModelEventArgsWorksOK()
		{
			//Arrange
			
			//Act
			var arg1 = new ModelEventArgs<TestModel>();
			var arg2 = new ModelEventArgs<TestModel>(new TestModel());

			//Assert
			Assert.IsNull(arg1.Model, "Arg should be null");
			Assert.IsNotNull(arg2.Model, "Arg should be not null");
		}

		[TestMethod]
		public void GettingAndSettingModelWorksOK()
		{
			//Arrange
			var args = new ModelEventArgs<TestModel>();
			var model = new TestModel();

			//Act
			args.Model = model;

			//Assert
			Assert.AreEqual(model, args.Model);
		}

		#endregion
	}
}
