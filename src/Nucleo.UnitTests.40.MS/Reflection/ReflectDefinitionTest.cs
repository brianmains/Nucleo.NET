using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Nucleo.Reflection
{
	[TestClass]
	public class ReflectDefinitionTest : ReflectDefinition
	{
		#region " Test Classes "

		protected class TestClass
		{
			public event EventHandler Clicked;
			public event EventHandler Selected;

			public string Name { get; set; }
			public string Value { get; set; }

			public string GetName() { return this.Name; }
			public string GetValue() { return this.Value; }
		}

		#endregion



		#region " Constructors "

		public ReflectDefinitionTest()
			: base(null, true) { }

		public ReflectDefinitionTest(object target, bool isPrivate)
			: base(target, isPrivate) { }

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingEventWorksOK()
		{
			//Arrange
			var obj = new TestClass { Value = "123" };
			var member = new ReflectDefinitionTest(obj, false);

			//Act
			var memberInfo = member.Event("Clicked");

			//Assert
			Assert.IsNotNull(memberInfo);
			Assert.AreEqual("Clicked", memberInfo.Name);
		}

		[TestMethod]
		public void GettingEventsWorksOK()
		{
			//Arrange
			var obj = new TestClass { Value = "123" };
			var member = new ReflectDefinitionTest(obj, false);

			//Act
			var memberInfos = member.Events();
			
			//Assert
			Assert.IsNotNull(memberInfos);
		}

		[TestMethod]
		public void GettingMethodWorksOK()
		{
			//Arrange
			var obj = new TestClass { Value = "123" };
			var member = new ReflectDefinitionTest(obj, false);

			//Act
			var memberInfo = member.Method("GetValue");

			//Assert
			Assert.IsNotNull(memberInfo);
			Assert.AreEqual("GetValue", memberInfo.Name);
		}

		[TestMethod]
		public void GettingMethodsWorksOK()
		{
			//Arrange
			var obj = new TestClass { Value = "123" };
			var member = new ReflectDefinitionTest(obj, false);

			//Act
			var memberInfo = member.Methods();

			//Assert
			Assert.IsNotNull(memberInfo);
		}

		[TestMethod]
		public void GettingPropertiesWorksOK()
		{
			//Arrange
			var obj = new TestClass { Value = "123" };
			var member = new ReflectDefinitionTest(obj, false);

			//Act
			var memberInfo = member.Properties();

			//Assert
			Assert.IsNotNull(memberInfo);
		}

		[TestMethod]
		public void GettingPropertyWorksOK()
		{
			//Arrange
			var obj = new TestClass { Value = "123" };
			var member = new ReflectDefinitionTest(obj, false);

			//Act
			var memberInfo = member.Property("Value");

			//Assert
			Assert.IsNotNull(memberInfo);
			Assert.AreEqual("Value", memberInfo.Name);
		}

		[TestMethod]
		public void GettingTypeWorksOK()
		{
			//Arrange
			var obj = new TestClass { Value = "123" };
			var member = new ReflectDefinitionTest(obj, false);

			//Act
			var memberInfo = member.Type();

			//Assert
			Assert.IsNotNull(memberInfo);
			Assert.AreEqual(typeof(TestClass).Name, memberInfo.Name);
		}

		#endregion
	}
}
