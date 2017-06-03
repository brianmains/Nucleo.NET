using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nucleo.Collections;


namespace Nucleo.Reflection
{
	[TestClass]
	public class BaseReflectMemberTest : BaseReflectMember
	{
		#region " Test Classes "

		[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
		public class RepeatableTestAttribute : Attribute
		{
			public string Name { get; set; }
		}

		protected class TestClass
		{
			[
			Browsable(true),
			Bindable(true)
			]
			public object Value
			{
				get;
				set;
			}
		}

		protected class TestDerivedClass : TestClass
		{
			[
			DefaultValue("Name"),
			RepeatableTestAttribute(Name = "1"),
			RepeatableTestAttribute(Name = "2"),
			RepeatableTestAttribute(Name = "3")
			]
			public string Name
			{
				get;
				set;
			}
		}

		#endregion



		#region " Constructors "

		public BaseReflectMemberTest()
			: base("Test", null, false) { }

		public BaseReflectMemberTest(string name, object target, bool isPrivate)
			: base(name, target, isPrivate) { }

		#endregion



		#region " Methods "

		public override MemberInfo GetMember()
		{
			return base.Target.GetType().GetProperty(base.Name);
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void GettingAttributesUsingGenericsWorksOK()
		{
			//Arrange
			var obj = new TestDerivedClass { Name = "123", Value = 234 };
			var member = new BaseReflectMemberTest("Name", obj, false);

			//Act
			var attributes1 = member.GetAttributes<RepeatableTestAttribute>(false);
			var attributes2 = member.GetAttributes<RepeatableTestAttribute>(true);

			//Assert
			Assert.AreEqual(3, attributes1.Length);
			Assert.AreEqual(3, attributes2.Length);
		}

		[TestMethod]
		public void GettingAttributeUsingGenericsWorksOK()
		{
			//Arrange
			var obj = new TestClass { Value = 123 };
			var member = new BaseReflectMemberTest("Value", obj, false);

			//Act
			var attribute1 = member.GetAttribute<BindableAttribute>(false);
			var attribute2 = member.GetAttribute<BindableAttribute>(true);

			//Assert
			Assert.IsNotNull(attribute1);
			Assert.IsNotNull(attribute2);
		}

		[TestMethod]
		public void GettingAttributeUsingGenericsAndInheritanceWorksOK()
		{
			//Arrange
			var obj = new TestDerivedClass { Name = "1", Value = 123 };
			var member = new BaseReflectMemberTest("Value", obj, false);

			//Act
			var attribute1 = member.GetAttribute<BrowsableAttribute>(false);
			var attribute2 = member.GetAttribute<BrowsableAttribute>(true);

			//Assert
			Assert.IsNotNull(attribute1);
			Assert.IsNotNull(attribute2);
		}

		[TestMethod]
		public void GettingAttributesUsingTypeWorksOK()
		{
			//Arrange
			var obj = new TestDerivedClass { Name = "123", Value = 234 };
			var member = new BaseReflectMemberTest("Name", obj, false);

			//Act
			var attributes1 = member.GetAttributes(typeof(RepeatableTestAttribute), false);
			var attributes2 = member.GetAttributes(typeof(RepeatableTestAttribute), true);

			//Assert
			Assert.AreEqual(3, attributes1.Length);
			Assert.IsTrue(attributes1.IsInstanceOf<object, RepeatableTestAttribute>(i => i), "Object isn't repeatable test attribute");
			Assert.AreEqual(3, attributes2.Length);
			Assert.IsTrue(attributes2.IsInstanceOf<object, RepeatableTestAttribute>(i => i), "Object isn't repeatable test attribute");
		}

		[TestMethod]
		public void GettingAttributeUsingTypeWorksOK()
		{
			//Arrange
			var obj = new TestClass { Value = 123 };
			var member = new BaseReflectMemberTest("Value", obj, false);

			//Act
			var attribute1 = member.GetAttribute(typeof(BindableAttribute), false);
			var attribute2 = member.GetAttribute(typeof(BindableAttribute), true);

			//Assert
			Assert.IsNotNull(attribute1);
			Assert.IsInstanceOfType(attribute1, typeof(BindableAttribute));
			Assert.IsNotNull(attribute2);
			Assert.IsInstanceOfType(attribute2, typeof(BindableAttribute));
		}

		[TestMethod]
		public void GettingAttributeUsingTypeAndInheritanceWorksOK()
		{
			//Arrange
			var obj = new TestDerivedClass { Name = "1", Value = 123 };
			var member = new BaseReflectMemberTest("Value", obj, false);

			//Act
			var attribute1 = member.GetAttribute<BrowsableAttribute>(false);
			var attribute2 = member.GetAttribute<BrowsableAttribute>(true);

			//Assert
			Assert.IsNotNull(attribute1);
			Assert.IsNotNull(attribute2);
		}

		#endregion
	}
}
