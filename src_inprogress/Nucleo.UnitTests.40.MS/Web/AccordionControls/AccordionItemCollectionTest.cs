using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TypeMock.ArrangeActAssert;

using Nucleo.Collections;
using Nucleo.TestingTools;


namespace Nucleo.Web.AccordionControls
{
	[TestClass]
	public class AccordionItemCollectionTest
	{
		#region " Tests "

		[TestMethod]
		public void AddingInvalidItemsAtIndexThrowsException()
		{
			//Arrange
			var accordion = Isolate.Fake.Instance<Accordion>();
			var list = new AccordionItemCollection(accordion);

			//Act


			//Assert
			ExceptionTester.CheckException(true, (src) => { list.AddAt(0, new Panel()); });
		}

		[TestMethod]
		public void AddingInvalidItemsThrowsException()
		{
			//Arrange
			var accordion = Isolate.Fake.Instance<Accordion>();
			var list = new AccordionItemCollection(accordion);

			//Act


			//Assert
			ExceptionTester.CheckException(true, (src) => { list.Add(new Panel()); });
		}

		[TestMethod]
		public void ClearingSelectionWorksOK()
		{
			//Arrange
			var accordion = Isolate.Fake.Instance<Accordion>();
			var list = new AccordionItemCollection(accordion);
			list.Add(new AccordionItem { IsSelected = true });
			list.Add(new AccordionItem());

			//Act
			list.ClearSelection();

			//Assert
			Assert.IsTrue(list.Cast<AccordionItem>().IsAll(i => i.IsSelected, ValidationIsAllCheck.False), "One is selected");
		}

		#endregion
	}
}
