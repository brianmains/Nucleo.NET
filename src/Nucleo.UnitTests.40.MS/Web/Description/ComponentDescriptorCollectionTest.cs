using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Web.Description
{
	[TestClass]
	public class ComponentDescriptorCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void FindingByDetailsWorksOK()
		{
			//Arrange
			var list = new ComponentDescriptorCollection();
			list.Add(new ComponentDescriptor("A"));
			list.Add(new ComponentDescriptor("B"));

			var details = Isolate.Fake.Instance<ComponentDescriptionRequestDetails>();
			Isolate.WhenCalled(() => { return details.ClientTypeName; }).WillReturn("A");
			var details2 = Isolate.Fake.Instance<ComponentDescriptionRequestDetails>();
			Isolate.WhenCalled(() => { return details2.ClientTypeName; }).WillReturn("C");

			//Act
			var entry = list.GetByDetails(details);
			var entry2 = list.GetByDetails(details2);

			//Assert
			Assert.AreEqual("A", entry.ClientType);
			Assert.IsNull(entry2);
		}

		#endregion
	}
}
