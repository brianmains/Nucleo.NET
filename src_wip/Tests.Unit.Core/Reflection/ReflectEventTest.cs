using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Reflection
{
	[TestClass]
	public class ReflectEventTest
	{
		#region " Test Classes "

		protected class TestEventInfo : EventInfo
		{
			public override EventAttributes Attributes
			{
				get { throw new NotImplementedException(); }
			}

			public override MethodInfo GetAddMethod(bool nonPublic)
			{
				throw new NotImplementedException();
			}

			public override MethodInfo GetRaiseMethod(bool nonPublic)
			{
				throw new NotImplementedException();
			}

			public override MethodInfo GetRemoveMethod(bool nonPublic)
			{
				throw new NotImplementedException();
			}

			public override Type DeclaringType
			{
				get { throw new NotImplementedException(); }
			}

			public override object[] GetCustomAttributes(Type attributeType, bool inherit)
			{
				throw new NotImplementedException();
			}

			public override object[] GetCustomAttributes(bool inherit)
			{
				throw new NotImplementedException();
			}

			public override bool IsDefined(Type attributeType, bool inherit)
			{
				throw new NotImplementedException();
			}

			public override string Name
			{
				get { throw new NotImplementedException(); }
			}

			public override Type ReflectedType
			{
				get { throw new NotImplementedException(); }
			}
		}

		#endregion



		#region " Tests "

		[TestMethod]
		public void AddingHandlersToEventWorksOK()
		{
			//Arrange
			var testEvent = new TestEventInfo();
			var evt = Isolate.Fake.Instance<ReflectEvent>(Members.CallOriginal);

			//Act
			

			//Assert

		}

		#endregion
	}
}
