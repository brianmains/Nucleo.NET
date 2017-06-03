using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Presentation;
using Nucleo.Web.Core;
using Nucleo.Web.Context;


namespace Nucleo.Web.CodeGeneration
{
	[TestClass]
	public class PresenterClassGeneratorTest
	{
		#region " Test Classes "

		protected class TestPresenter : BasePresenter
		{
			public TestPresenter() 
				: base(null) { }
		}

		#endregion



		[TestMethod]
		public void GeneratingProxyClassWithPropertiesWorksOK()
		{
			//Arrange
			var context = Isolate.Fake.Instance<IServicesContext>();
			Isolate.WhenCalled(() => context.Urls.GetClientBasedUrl(null)).WillReturn("PresenterAjax.Axd");

			var gen = new PresenterClassGenerator(context);
			var def = new ClassDefinition
			{
				SourceType = typeof(TestPresenter),
				Methods = new ClassMemberCollection
				{
					new ClassMethodMember 
					{ 
						Name = "DoThis", 
						Parameters = new MethodParameterCollection { "key", "name" }
					},
					new ClassMethodMember 
					{ 
						Name = "DoThat",
						Parameters = new MethodParameterCollection { "first", "second", "third" }
					}
				}
			};

			//Act
			var output = gen.Generate(def);

			//Assert
			StringAssert.Contains(output, "DoThis: function(key, name, successCallback, failedCallback) {");
			StringAssert.Contains(output, "DoThat: function(first, second, third, successCallback, failedCallback) {");
		}

		[TestMethod]
		public void GeneratingProxyClassWorksOK()
		{
			//Arrange
			var context = Isolate.Fake.Instance<IServicesContext>();
			Isolate.WhenCalled(() => context.Urls.GetClientBasedUrl(null)).WillReturn("PresenterAjax.Axd");

			var gen = new PresenterClassGenerator(context);
			var def = new ClassDefinition
			{
				SourceType = typeof(TestPresenter),
				Methods = new ClassMemberCollection
				{
					new ClassMethodMember { Name = "DoThis" },
					new ClassMethodMember { Name = "DoThat" }
				}
			};

			//Act
			var output = gen.Generate(def);

			//Assert
			StringAssert.Contains(output, "DoThis: function(successCallback, failedCallback) {");
			StringAssert.Contains(output, "DoThat: function(successCallback, failedCallback) {");
		}
	}
}
