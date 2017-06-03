using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;


namespace Nucleo.Extensions
{
	[TestClass]
	public class ListViewExtensionsTest
	{
		#region " Tests "

		[TestMethod]
		public void GettingDataKeyValuesWorksOK()
		{
			//Arrange
			var grid = Isolate.Fake.Instance<ListView>(Members.CallOriginal);
			Isolate.WhenCalled(() => grid.DataKeys[0]).WillReturn(new DataKey(new OrderedDictionary { { "A", 1 } }));

			var row = Isolate.Fake.Instance<ListViewDataItem>();
			Isolate.WhenCalled(() => row.DataItemIndex).WillReturn(0);
			Isolate.WhenCalled(() => row.Parent).WillReturn(grid);

			//Act
			var key0 = row.GetDataKeyValues();

			//Assert
			Assert.AreEqual(1, key0.Count);
			Assert.AreEqual(1, key0[0]);
			//Assert.AreEqual("A", key0[1]);

			Isolate.CleanUp();
		}

		[TestMethod]
		public void GettingDataKeyValueWorksOK()
		{
			//Arrange
			var list = new ArrayList();
			list.Add(1);

			var grid = Isolate.Fake.Instance<ListView>(Members.CallOriginal);
			Isolate.WhenCalled(() => grid.DataKeys[0]).WillReturn(new DataKey(new OrderedDictionary { { "A", 1 } }));

			var row = Isolate.Fake.Instance<ListViewDataItem>();
			Isolate.WhenCalled(() => row.DataItemIndex).WillReturn(0);
			Isolate.WhenCalled(() => row.Parent).WillReturn(grid);

			//Act
			var key0 = row.GetDataKeyValue();

			//Assert
			Assert.AreEqual(1, key0);

			Isolate.CleanUp();
		}

		#endregion
	}
}
